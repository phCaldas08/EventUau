using System;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Commands.Update
{
    public class UpdateEventCommand : IRequest<Domain.Entities.Event>
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Description { get; set; }
    }
}
