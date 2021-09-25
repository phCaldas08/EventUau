using System;
using System.Collections.Generic;

namespace Event.Uau.Endereco.Domain.Entities
{
    public class TipoEndereco
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }
    }
}
