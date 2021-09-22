using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.Funcionario.Commands.EnviarPropostaFuncionario
{
    public class EnviarPropostaFuncionarioCommand : EventUauRequest<FuncionarioEventoViewModel>
    {
        public ViewModel.Autenticacao.UsuarioViewModel Usuario { get; set; }

        public decimal Salario { get; set; }

        public int IdEvento { get; set; }
    }
}
