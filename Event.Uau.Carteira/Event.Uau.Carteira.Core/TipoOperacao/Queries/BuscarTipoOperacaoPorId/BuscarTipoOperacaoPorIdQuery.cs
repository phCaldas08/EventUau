using System;
using Event.Uau.Carteira.ViewModel.Carteira;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Carteira.Core.TipoOperacao.Queries.BuscarTipoOperacaoPorId
{
    public class BuscarTipoOperacaoPorIdQuery : EventUauRequest<TipoOperacaoViewModel>
    {
        public string IdTipoOperacao { get; set; }
    }
}
