using System;
namespace Event.Uau.Endereco.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }

        public int IdTipoEndereco { get; set; }

        public int IdExterno { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Cep { get; set; }

        public string Nome { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public virtual TipoEndereco TipoEndereco { get; set; }

    }
}
