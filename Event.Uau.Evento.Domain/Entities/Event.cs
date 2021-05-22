using System;
namespace Event.Uau.Evento.Domain.Entities
{
    public class Event
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Description { get; set; }

    }
}
