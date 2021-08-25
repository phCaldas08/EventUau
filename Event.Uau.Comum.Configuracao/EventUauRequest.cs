using System;
using MediatR;

namespace Event.Uau.Comum.Configuracao
{
    public class EventUauRequest<T> : IRequest<T>
    {
        public string Token { get; set; }
    }
}
