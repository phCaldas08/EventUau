using System;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Autenticacao.Core.Usuario.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioCommand : EventUauRequest<UsuarioViewModel>
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
