using System;
using System.Text.Json.Serialization;

namespace Event.Uau.Carteira.ViewModel.Carteira
{
    public class OperacaoViewModel
    {
        public int Id { get; set; }

        public DateTime DataHora { get; set; }

        public int? IdEvento { get => OperacaoEventoPagador?.IdEvento ?? OperacaoEventoRecebedor?.IdEvento; }

        [JsonIgnore]
        public decimal ValorInicial { get; set; }

        public decimal Valor { get => ValorInicial * (TipoOperacao.Multplicador > 0 ? 1 : -1); }

        public TipoOperacaoViewModel TipoOperacao { get; set; }

        [JsonIgnore]
        public OperacaoEventoViewModel OperacaoEventoRecebedor { get; set; }

        [JsonIgnore]
        public OperacaoEventoViewModel OperacaoEventoPagador { get; set; }
    }
}
