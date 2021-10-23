using System;
using System.Collections.Generic;

namespace Event.Uau.Carteira.Domain.Entities
{
    public class TipoOperacao
    {
        public string Id { get; set; }

        public string Descricao { get; set; }

        public int Multplicador { get; set; }

        public bool EhDisponivel { get; set; }

        public bool EhVisivel { get; set; }

        public virtual List<Operacao> Operacoes { get; set; }
    }
}
