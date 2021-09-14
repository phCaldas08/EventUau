using System;
using System.Collections.Generic;

namespace Event.Uau.Evento.ViewModel.Evento
{
    public class ResumoEventoViewModel
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Status { get; set; }
        public string Endereco { get; set; }
        public List<FuncionarioEventoViewModel> Funcionarios { get; set; }

    }
}
