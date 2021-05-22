using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Persistence;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, IEnumerable<Domain.Entities.Event>>
    {
        private readonly EventUauDbContext eventUauDbContext;

        public GetListQueryHandler(EventUauDbContext eventUauDbContext)
        {
            this.eventUauDbContext = eventUauDbContext;
        }

        public async Task<IEnumerable<Domain.Entities.Event>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
