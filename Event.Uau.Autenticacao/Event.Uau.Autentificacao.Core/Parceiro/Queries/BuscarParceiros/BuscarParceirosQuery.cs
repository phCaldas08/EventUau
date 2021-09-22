using System;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Comum.ViewModel;

namespace Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiros
{
    public class BuscarParceirosQuery : EventUauPaginacaoRequest<ListaParceiroViewModel>
    {
        public string ChaveOrdenacao { get; set; } = "nome";
        public bool Ascendente { get; set; } = true;
    }
}
