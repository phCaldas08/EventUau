using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Event.Uau.Carteira.ViewModel.Carteira
{
    public class TipoOperacaoViewModel
    {
        public string Id { get; set; }

        public string Descricao { get; set; }

        public int Multplicador { get; set; }

        public bool EhDisponivel { get; set; }

        [JsonIgnore]
        public bool EhVisivel { get; set; }
    }
}
