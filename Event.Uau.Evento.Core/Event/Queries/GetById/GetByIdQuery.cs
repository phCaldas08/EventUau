using System;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Queries.GetById
{
    public class GetByIdQuery : IRequest<Domain.Entities.Event>
    {
        public Guid Key { get; set; }
    }
}
