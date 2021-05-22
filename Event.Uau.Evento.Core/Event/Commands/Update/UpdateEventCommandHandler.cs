using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Persistence;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Commands.Update
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Domain.Entities.Event>
    {
        private readonly EventUauDbContext eventUauDbContext;
        private readonly IMapper mapper;

        public UpdateEventCommandHandler(EventUauDbContext eventUauDbContext, IMapper mapper)
        {
            this.eventUauDbContext = eventUauDbContext;
            this.mapper = mapper;
        }

        public async Task<Domain.Entities.Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var updatedEvent = mapper.Map<Domain.Entities.Event>(request);

            eventUauDbContext.Events.Update(updatedEvent);

            await eventUauDbContext.SaveChangesAsync(cancellationToken);

            return updatedEvent;
        }
    }
}
