using System;
using System.Text.Json.Serialization;

namespace Event.Uau.Evento.ViewModel.Evento
{
    public class EnderecoViewModel
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Cep { get; set; }

        public string Nome { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }
    }
}
