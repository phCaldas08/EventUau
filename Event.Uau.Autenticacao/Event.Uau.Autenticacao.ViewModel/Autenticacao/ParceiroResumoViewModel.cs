using System;
using System.Collections.Generic;

namespace Event.Uau.Autenticacao.ViewModel.Autenticacao
{
    public class ParceiroResumoViewModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string ValorHora { get; set; }
        public List<string> Especialidades;
    }
}
