using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.Evento.Commands.CancelarEvento
{
    public class CancelarEventoCommand : EventUauRequest<EventoViewModel>
    {
        public int IdEvento { get; set; }
    }
}
