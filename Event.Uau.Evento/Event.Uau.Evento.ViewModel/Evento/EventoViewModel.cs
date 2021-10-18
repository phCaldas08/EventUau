using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Event.Uau.Evento.ViewModel.Evento
{
    public class EventoViewModel
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public decimal DuracaoMinima { get; set; }

        public decimal DuracaoMaxima { get; set; }

        public string Observacao { get; set; }

        public bool EstaVisivel { get; set; }

        [JsonIgnore]
        public List<FuncionarioEventoViewModel> FuncionariosEvento { get; set; }

        public Autenticacao.UsuarioViewModel Usuario { get; set; }

        public StatusViewModel Status { get; set; }


        public List<FuncionarioEventoViewModel> FuncionariosContratados
        {
            get => FuncionariosEvento?.Where(i => i.StatusContratacao.Id.Equals("AC", StringComparison.CurrentCultureIgnoreCase)).ToList() ?? null;
        }

        public List<FuncionarioEventoViewModel> FuncionarioMatch
        {
            get => FuncionariosEvento?.Where(i => i.StatusContratacao.Id.Equals("PEN", StringComparison.CurrentCultureIgnoreCase)).ToList() ?? null;
        }
    }
}
