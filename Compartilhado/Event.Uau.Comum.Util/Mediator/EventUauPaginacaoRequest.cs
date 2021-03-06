using System;
using MediatR;

namespace Event.Uau.Comum.Util.Mediator
{
    public class EventUauPaginacaoRequest<T> : EventUauRequest<T>
    {
        public int Indice { get; set; } = 0;

        public int TamanhoPagina { get; set; } = 20;
    }
}
