using System;
using Event.Uau.Carteira.ViewModel.Carteira;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Carteira.Core.Operacao.Queries.BuscarOperacaoPorId
{
    public class BuscarOperacaoPorIdQuery : EventUauRequest<OperacaoViewModel>
    {
        public int IdOperacao { get; set; }
    }
}
