using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.Status.Queries.BuscarStatusPorId
{
    public class BuscarStatusPorIdQuery : EventUauRequest<StatusViewModel>
    {
        public string Id { get; set; }
    }
}
