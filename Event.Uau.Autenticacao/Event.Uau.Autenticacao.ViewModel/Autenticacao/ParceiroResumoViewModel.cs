using System;
using System.Collections.Generic;

namespace Event.Uau.Autenticacao.ViewModel.Autenticacao
{
    public class ParceiroResumoViewModel
    {
        public UsuarioViewModel Usuario { get; set; }
        public decimal ValorHora { get; set; }
        public List<EspecialidadeViewModel> Especialidades { get; set; }
    }
}
