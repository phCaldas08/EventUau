using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiroPorIdUsuario;

namespace Event.Uau.Autenticacao.Core.Parceiro.Commands.CadastrarParceiro
{
    public class CadastrarParceiroCommandHandler : IRequestHandler<CadastrarParceiroCommand, ParceiroViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly CadastrarParceiroCommandValidator validator;

        public CadastrarParceiroCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new CadastrarParceiroCommandValidator(context);
        }

        public async Task<ParceiroViewModel> Handle(CadastrarParceiroCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var usuario = await context.Usuarios.FirstOrDefaultAsync(i => i.Id == request.IdUsuarioLogado);

            usuario.Parceiro = mapper.Map<Domain.Entities.Parceiro>(request);

            await context.SaveChangesAsync(cancellationToken);

            var query = new BuscarParceiroPorIdUsuarioQuery
            {
                IdUsuario = request.IdUsuarioLogado,
                IdUsuarioLogado = request.IdUsuarioLogado,
                Token = request.Token
            };

            return await mediator.Send(query);

        }
    }
}
