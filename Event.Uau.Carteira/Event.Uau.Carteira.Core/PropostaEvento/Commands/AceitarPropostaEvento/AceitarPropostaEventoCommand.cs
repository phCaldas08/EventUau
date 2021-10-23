using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.AceitarPropostaEvento
{
    public class AceitarPropostaEventoCommand : EventUauRequest<bool>
    {
        public int IdEvento { get; set; }
    }
}
