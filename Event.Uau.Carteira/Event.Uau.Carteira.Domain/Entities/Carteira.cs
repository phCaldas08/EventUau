using System;
using System.Collections.Generic;

namespace Event.Uau.Carteira.Domain.Entities
{
    public class Carteira
    {
        public int IdUsuario { get; set; }

        public virtual List<Operacao> Operacoes { get; set; }
    }
}
