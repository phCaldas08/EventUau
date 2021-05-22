using System;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Commands.Create
{
    public class CreateEventCommand : IRequest<Domain.Entities.Event>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get => DateTime.Now; }
    }
}
