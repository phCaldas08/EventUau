using System;
using System.Collections.Generic;

namespace Event.Uau.Evento.Domain.Entities
{
    public class Status
    {
        public string Id { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
