using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Evento.Core.Evento.Commands.CriarEvento
{
    public class CriarEventoCommand : EventUauRequest<ViewModel.Evento.EventoViewModel>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get => DateTime.Now; }
    }
}
