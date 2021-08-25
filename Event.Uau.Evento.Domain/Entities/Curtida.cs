using System;
namespace Event.Uau.Evento.Domain.Entities
{
    public class Curtida
    {
        public int IdEvento { get; set; }

        public int IdFuncionario { get; set; }

        public virtual Evento Evento { get; set; }
    }
}
