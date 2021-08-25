using System;
namespace Event.Uau.Evento.Domain.Entities
{
    public class Endereco
    {
        public int IdEvento { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Cep { get; set; }

        public string Nome { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public virtual Evento Evento { get; set; }
    }
}
