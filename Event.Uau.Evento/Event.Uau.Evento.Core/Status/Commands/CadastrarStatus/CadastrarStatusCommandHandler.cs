using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.Status.Commands.CadastrarStatus
{
    public class CadastrarStatusCommandHandler : IRequestHandler<CadastrarStatusCommand, StatusViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly CadastrarStatusCommandValidator validator;

        public CadastrarStatusCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new CadastrarStatusCommandValidator(context);
        }

        public async Task<StatusViewModel> Handle(CadastrarStatusCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var status = mapper.Map<Domain.Entities.Status>(request);

            await context.Status.AddAsync(status);

            await context.SaveChangesAsync();

            var query = new Queries.BuscarStatusPorId.BuscarStatusPorIdQuery { Id = request.Id };

            return await mediator.Send(query);
        }
    }
}
