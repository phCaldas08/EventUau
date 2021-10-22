using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Evento.ViewModel.Evento;

namespace Event.Uau.Evento.Core.Evento.Commands.AlterarStatusEvento
{
    public class AlterarStatusEventoCommand : EventUauRequest<EventoViewModel>
    {
        public int IdEvento { get; set; }

        public Domain.Enums.StatusEnum Status { get; set; }
    }
}
