using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Persistence;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Commands.Create
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Domain.Entities.Event>
    {
        private readonly EventUauDbContext eventUauDbContext;
        private readonly IMapper mapper;

        public CreateEventCommandHandler(EventUauDbContext eventUauDbContext, IMapper mapper)
        {
            this.eventUauDbContext = eventUauDbContext;
            this.mapper = mapper;
        }

        public async Task<Domain.Entities.Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = mapper.Map<Domain.Entities.Event>(request);

            await eventUauDbContext.Events.AddAsync(newEvent, cancellationToken);

            await eventUauDbContext.SaveChangesAsync(cancellationToken);

            return newEvent;
        }
    }
}
