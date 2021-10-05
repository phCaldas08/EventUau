using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Usuario.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, UsuarioViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly AtualizarUsuarioCommandValidator validator;

        public AtualizarUsuarioCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new AtualizarUsuarioCommandValidator(context);
        }

        public async Task<UsuarioViewModel> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var usuario = await context.Usuarios.FirstOrDefaultAsync(i => i.Id == request.IdUsuarioLogado);

            usuario = mapper.Map(request, usuario);

            await context.SaveChangesAsync(cancellationToken);

            var query = new Queries.BuscaUsuarioPorId.BuscaUsuarioPorIdQuery
            {
                IdUsuario = request.IdUsuarioLogado,
                IdUsuarioLogado = request.IdUsuarioLogado,
                Token = request.Token
            };

            return await mediator.Send(query);
        }
    }
}
