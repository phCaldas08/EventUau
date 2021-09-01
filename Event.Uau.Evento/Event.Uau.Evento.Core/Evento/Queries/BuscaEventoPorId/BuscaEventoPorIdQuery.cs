using System;
using Event.Uau.Comum.Util.Mediator;
using MediatR;

namespace Event.Uau.Evento.Core.Evento.Queries.BuscaEventoPorId
{
    public class BuscaEventoPorIdQuery : EventUauRequest<ViewModel.Evento.EventoViewModel>
    {
        public int IdEvento { get; set; }
    }
}
