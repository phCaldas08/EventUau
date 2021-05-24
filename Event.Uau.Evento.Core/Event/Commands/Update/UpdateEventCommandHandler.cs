using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Persistence;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Commands.Update
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Domain.Entities.Event>
    {
        private readonly EventUauDbContext eventUauDbContext;
        private readonly IMapper mapper;
        private readonly UpdateEventCommandValidator validator;

        public UpdateEventCommandHandler(EventUauDbContext eventUauDbContext, IMapper mapper)
        {
            this.eventUauDbContext = eventUauDbContext;
            this.mapper = mapper;
            this.validator = new UpdateEventCommandValidator();
        }

        public async Task<Domain.Entities.Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var updatedEvent = mapper.Map<Domain.Entities.Event>(request);

            eventUauDbContext.Events.Update(updatedEvent);

            await eventUauDbContext.SaveChangesAsync(cancellationToken);

            return updatedEvent;
        }
    }
}
