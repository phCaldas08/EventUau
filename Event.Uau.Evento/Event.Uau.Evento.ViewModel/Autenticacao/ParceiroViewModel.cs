using System;
using System.Collections.Generic;

namespace Event.Uau.Evento.ViewModel.Autenticacao
{
    public class ParceiroViewModel
    {
        public UsuarioViewModel Usuario { get; set; }

        public decimal ValorHora { get; set; }

        public List<EspecialidadeViewModel> Especialidades { get; set; }
    }
}
