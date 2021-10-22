using System;
namespace Event.Uau.Evento.Domain.Entities
{
    public class FuncionarioEvento
    { 
        public int IdEvento { get; set; }

        public int IdUsuario { get; set; }

        public decimal Salario { get; set; }

        public string IdStatusContratacao { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual StatusContratacao StatusContratacao { get; set; }
    }
}
