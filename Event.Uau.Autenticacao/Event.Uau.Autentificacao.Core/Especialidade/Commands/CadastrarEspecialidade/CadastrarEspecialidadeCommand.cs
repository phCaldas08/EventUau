using System;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Especialidade.Commands.CadastrarEspecialidade
{
    public class CadastrarEspecialidadeCommand : IRequest<ViewModel.Autenticacao.UsuarioViewModel>
    {
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Senha { get; set; }

        public string ConfirmarSenha { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
