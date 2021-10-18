using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.Proposta.Queries.BuscarPropostasParceiro
{
    public class BuscarPropostasParceiroQuery : EventUauPaginacaoRequest<ListaPropostaEventoViewModel>
    {
        public string StatusContratacao { get; set; }
    }
}
