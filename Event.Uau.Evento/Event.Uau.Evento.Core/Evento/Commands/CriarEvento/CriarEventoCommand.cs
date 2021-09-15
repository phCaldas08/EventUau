using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Evento.Core.Evento.Commands.CriarEvento
{
    public class CriarEventoCommand : EventUauRequest<ViewModel.Evento.EventoViewModel>
    {
        public int Numero { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get => DateTime.Now; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public decimal DuracaoMinima { get; set; }

        public decimal DuracaoMaxima { get; set; }
    }
}
