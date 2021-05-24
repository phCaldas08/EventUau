using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var startCount = (request.Index ?? 0) * (request.PageSize ?? 0);

            var events = await this.eventUauDbContext.Events
                .Where(e => (!request.StartDate.HasValue || request.StartDate <= e.Date)
                         && (!request.EndDate.HasValue   || request.EndDate >= e.Date)
                         && (string.IsNullOrEmpty(request.textSearch) || e.Description.Contains(request.textSearch, StringComparison.InvariantCultureIgnoreCase)
                                                                      || e.Name.Contains(request.textSearch, StringComparison.InvariantCultureIgnoreCase)))
                .Skip(startCount)
                .Take(request.PageSize ?? 20)
                .ToListAsync();

            return events;
        }


        private bool FilterEvent(Domain.Entities.Event @event, GetListQuery requestQuery)
        {
            bool result = true;

            if (requestQuery.StartDate.HasValue && requestQuery.StartDate < @event.Date)
                result = false;

            if (requestQuery.EndDate.HasValue && requestQuery.EndDate > @event.Date)
                result = false;

            if (!string.IsNullOrEmpty(requestQuery.textSearch)
                && !@event.Name.Contains(requestQuery.textSearch, StringComparison.InvariantCultureIgnoreCase)
                && !@event.Description.Contains(requestQuery.textSearch, StringComparison.InvariantCultureIgnoreCase))
                result = false;

            return result;

        }
    }
}
