using System;
using Event.Uau.Carteira.ViewModel.Carteira;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Carteira.Core.Operacao.Commands.RealizarOperacao
{
    public class RealizarOperacaoCommand : EventUauRequest<OperacaoViewModel>
    {
        public decimal Valor { get; set; }
        public string TipoOperacao { get; set; }
        
    }
}
