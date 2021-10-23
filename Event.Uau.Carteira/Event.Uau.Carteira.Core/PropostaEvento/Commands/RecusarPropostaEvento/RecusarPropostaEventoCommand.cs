using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.RecusarPropostaEvento
{
    public class RecusarPropostaEventoCommand : EventUauRequest<bool>
    {
        public int IdEvento { get; set; }
    }
}
