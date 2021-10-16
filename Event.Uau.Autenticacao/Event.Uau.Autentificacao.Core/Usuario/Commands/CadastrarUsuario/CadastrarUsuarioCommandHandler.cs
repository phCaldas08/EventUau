using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Core.Helpers;
using Event.Uau.Autenticacao.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Autenticacao.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Usuario.Commands.CadastrarUsuario
{
    public class CadastrarUsuarioCommandHandler : IRequestHandler<CadastrarUsuarioCommand, ViewModel.Autenticacao.UsuarioViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly CadastrarUsuarioCommandValidator validation;

        public CadastrarUsuarioCommandHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validation = new CadastrarUsuarioCommandValidator(context);
        }

        public async Task<ViewModel.Autenticacao.UsuarioViewModel> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            validation.ValidateAndThrow(request);

            var user = mapper.Map<Domain.Entities.Usuario>(request);

            await context.Usuarios.AddAsync(user);

            await context.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<ViewModel.Autenticacao.UsuarioViewModel>(user);

            return result;
        }
    }
}
