using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Persistence;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.Evento.Commands.CriarEvento
{
    public class CriarEventoCommandHandler : IRequestHandler<CriarEventoCommand, ViewModel.Evento.EventoViewModel>
    {
        private readonly EventUauDbContext eventUauDbContext;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly CriarEventoCommandValidator validator;

        public CriarEventoCommandHandler(EventUauDbContext eventUauDbContext, IMapper mapper, IMediator mediator)
        {
            this.eventUauDbContext = eventUauDbContext;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new CriarEventoCommandValidator();
        }

        public async Task<ViewModel.Evento.EventoViewModel> Handle(CriarEventoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var newEvent = mapper.Map<Domain.Entities.Evento>(request);

            await eventUauDbContext.Eventos.AddAsync(newEvent, cancellationToken);

            await eventUauDbContext.SaveChangesAsync(cancellationToken);

            return await mediator.Send(new Queries.BuscaEventoPorId.BuscaEventoPorIdQuery {
                IdEvento = newEvent.Id,
                IdUsuarioLogado = request.IdUsuarioLogado,
                Token = request.Token
            });
        }
    }
}
