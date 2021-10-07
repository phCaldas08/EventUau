using System;
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
    }
}
