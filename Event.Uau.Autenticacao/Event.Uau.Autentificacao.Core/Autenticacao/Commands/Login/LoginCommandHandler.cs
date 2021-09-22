using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Core.Helpers;
using Event.Uau.Autenticacao.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using AutoMapper;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;

namespace Event.Uau.Autenticacao.Core.Authentication.Autenticacao.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly LoginCommandValidator validations;

        public LoginCommandHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            validations = new LoginCommandValidator(context);
        }

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            validations.ValidateAndThrow(request);

            var usuario = await context.Usuarios.FirstOrDefaultAsync(i => i.Email.Equals(request.Email));

            var token = TokenService.GenerateToken(usuario);

            var usuarioViewModel = new LoginViewModel
            {
                Token = token,
                Usuario = mapper.Map<UsuarioViewModel>(usuario)
            };

            return usuarioViewModel;
        }
    }
}
