using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.Proposta.Commands.EnviarPropostaFuncionario
{
    public class EnviarPropostaFuncionarioCommand : EventUauRequest<FuncionarioEventoViewModel>
    {
        public ViewModel.Autenticacao.UsuarioViewModel Usuario { get; set; }

        public decimal Salario { get; set; }

        public decimal SalarioComTaxa { get => Salario * 0.87m; }

        public int IdEvento { get; set; }

        public ViewModel.Autenticacao.EspecialidadeViewModel Especialidade { get; set; }
    }
}
