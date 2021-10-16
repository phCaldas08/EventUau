using System;
using System.Collections.Generic;

namespace Event.Uau.Carteira.ViewModel.Carteira
{
    public class OperacoesPorTipoViewModel
    {
        public TipoOperacaoViewModel TipoOperacao { get; set; }

        public List<OperacaoViewModel> Operacoes { get; set; }
    }
}
