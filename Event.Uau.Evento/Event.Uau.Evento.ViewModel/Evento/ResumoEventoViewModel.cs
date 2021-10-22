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
        public StatusViewModel Status { get; set; }
        public string Endereco { get; set; }
        public List<FuncionarioEventoViewModel> Funcionarios { get; set; }
        public string StatusLabel
        {
            get
            {
                if ((Status.Id.Equals("CRIADO", StringComparison.CurrentCultureIgnoreCase) || Status.Id.Equals("CONTRATANDO", StringComparison.CurrentCultureIgnoreCase)) && DataInicio <= DateTime.Now)
                    return "Em Andamento";
                else
                    return Status.Descricao;
            }
        }

    }
}
