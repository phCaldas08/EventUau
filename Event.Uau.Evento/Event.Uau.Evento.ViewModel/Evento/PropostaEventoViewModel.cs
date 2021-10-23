using System;
using Event.Uau.Evento.ViewModel.Autenticacao;

namespace Event.Uau.Evento.ViewModel.Evento
{
    public class PropostaEventoViewModel
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public decimal DuracaoMinima { get; set; }

        public decimal DuracaoMaxima { get; set; }

        public string Observacao { get; set; }

        public decimal ValorProposta { get; set; }

        public StatusContratacaoViewModel StatusContratacao { get; set; }

        public StatusViewModel Status { get; set; }

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

        public EspecialidadeViewModel Especialidade { get; set; }
    }
}
