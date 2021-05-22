using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Persistence;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Commands.Update
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Domain.Entities.Event>
    {
        private readonly EventUauDbContext eventUauDbContext;

        public UpdateEventCommandHandler(EventUauDbContext eventUauDbContext)
        {
            this.eventUauDbContext = eventUauDbContext;
        }

        public async Task<Domain.Entities.Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
