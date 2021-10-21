using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.FinalizarPropostasEvento
{
    public class FinalizarPropostasEventoCommand : EventUauRequest<bool>
    {
        public int IdEvento { get; set; }
    }
}
