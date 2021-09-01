using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Usuario.Queries.BuscaUsuarioPorId
{
    public class BuscaUsuarioPorIdQueryHandler : IRequestHandler<BuscaUsuarioPorIdQuery, UsuarioViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscaUsuarioPorIdQueryValidator validator;

        public BuscaUsuarioPorIdQueryHandler(Persistence.EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscaUsuarioPorIdQueryValidator(context);
        }

        public async Task<UsuarioViewModel> Handle(BuscaUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var usuario = await context.Usuarios.FirstOrDefaultAsync(i => i.Id == request.IdUsuario);
            var usuarioViewModel = mapper.Map<UsuarioViewModel>(usuario);

            return usuarioViewModel;
        }
    }
}
