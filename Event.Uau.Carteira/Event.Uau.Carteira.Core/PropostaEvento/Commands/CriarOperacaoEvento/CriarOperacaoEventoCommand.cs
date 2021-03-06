using System;
using Event.Uau.Carteira.ViewModel.Carteira;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Carteira.Core.ProspostaEvento.Commands.CriarOperacaoEvento
{
    public class CriarOperacaoEventoCommand : EventUauRequest<OperacaoViewModel>
    {
        public int IdEvento { get; set; }

        public int IdFuncionario { get; set; }

        public decimal Valor { get; set; }
    }
}
