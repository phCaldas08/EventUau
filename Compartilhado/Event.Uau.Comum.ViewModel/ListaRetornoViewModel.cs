using System;
using System.Collections.Generic;

namespace Event.Uau.Comum.ViewModel
{
    public abstract class ListaRetornoViewModel<T>
    {
        public int Indice { get; set; }

        public int TamanhoPagina { get; set; }

        public int Total { get; set; }

        public List<T> Resultados { get; set; }

    }
}
