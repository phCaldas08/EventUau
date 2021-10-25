using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.CancelarEvento
{
    public class CancelarEventoCommand : EventUauRequest<bool>
    {
        public int IdEvento { get; set; }
    }
}
