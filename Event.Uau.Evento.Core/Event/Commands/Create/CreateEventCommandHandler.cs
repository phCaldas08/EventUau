using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Persistence;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Commands.Create
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Domain.Entities.Event>
    {
        private readonly EventUauDbContext eventUauDbContext;

        public CreateEventCommandHandler(EventUauDbContext eventUauDbContext)
        {
            this.eventUauDbContext = eventUauDbContext;
        }

        public async Task<Domain.Entities.Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
