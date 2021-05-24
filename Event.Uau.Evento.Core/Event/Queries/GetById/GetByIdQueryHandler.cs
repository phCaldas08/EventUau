using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Event.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Domain.Entities.Event>
    {
        private readonly EventUauDbContext eventUauDbContext;
        private readonly GetByIdQueryValidator validator;

        public GetByIdQueryHandler(EventUauDbContext eventUauDbContext)
        {
            this.eventUauDbContext = eventUauDbContext;
            this.validator = new GetByIdQueryValidator();
        }

        public async Task<Domain.Entities.Event> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var @event = await this.eventUauDbContext.Events.FirstOrDefaultAsync(e => e.Key == request.Key);

            return @event;
        }
    }
}
