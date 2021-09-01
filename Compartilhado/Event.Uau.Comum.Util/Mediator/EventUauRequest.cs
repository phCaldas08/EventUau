using System;
using MediatR;

namespace Event.Uau.Comum.Util.Mediator
{
    public class EventUauRequest<T> : IRequest<T>
    {
        public string Token { get; set; }
    }
}
