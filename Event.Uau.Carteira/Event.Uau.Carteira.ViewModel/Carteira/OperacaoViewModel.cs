using System;
using System.Text.Json.Serialization;

namespace Event.Uau.Carteira.ViewModel.Carteira
{
    public class OperacaoViewModel
    {
        public int Id { get; set; }

        public DateTime DataHora { get; set; }

        public int? IdEvento { get; set; }

        [JsonIgnore]
        public decimal ValorInicial { get; set; }

        public decimal Valor { get => ValorInicial * (TipoOperacao.Multplicador > 0 ? 1 : -1); }

        [JsonIgnore]
        public TipoOperacaoViewModel TipoOperacao { get; set; }
    }
}
