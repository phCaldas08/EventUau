using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Persistence;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Domain.Entities.Event>
    {
        private readonly EventUauDbContext eventUauDbContext;

        public GetByIdQueryHandler(EventUauDbContext eventUauDbContext)
        {
            this.eventUauDbContext = eventUauDbContext;
        }

        public async Task<Domain.Entities.Event> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
