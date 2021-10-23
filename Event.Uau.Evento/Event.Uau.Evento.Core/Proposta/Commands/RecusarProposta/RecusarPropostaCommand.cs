using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Evento.Core.Proposta.Commands.RecusarProposta
{
    public class RecusarPropostaCommand : EventUauRequest<bool>
    {
        public int IdEvento { get; set; }
    }
}
