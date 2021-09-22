using System;
using System.Collections.Generic;

namespace Event.Uau.Evento.ViewModel.Evento
{
    public class ResumoEventoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Status { get; set; }
        public string Endereco { get; set; }
        public List<FuncionarioEventoViewModel> Funcionarios { get; set; }

    }
}
