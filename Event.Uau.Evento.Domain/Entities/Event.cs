using System;
using System.ComponentModel.DataAnnotations;

namespace Event.Uau.Evento.Domain.Entities
{
    public class Event
    {
        [Key]
        public Guid Key { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Description { get; set; }
        public decimal? Budget { get; set; }        
        
    }
}
