using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Domain.Enums;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Evento.Commands.AlterarStatusEvento
{
    public class AlterarStatusEventoCommandHandler : IRequestHandler<AlterarStatusEventoCommand, EventoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly AlterarStatusEventoCommandValidator validator;

        public AlterarStatusEventoCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new AlterarStatusEventoCommandValidator(context);
        }

        public async Task<EventoViewModel> Handle(AlterarStatusEventoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var evento = await context.Eventos.FirstOrDefaultAsync(i => i.Id == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado);
            var codStatus = Enum.GetName(typeof(StatusEnum), request.Status);

            evento.Status = await context.Status.FirstOrDefaultAsync(i => i.Id.Equals(codStatus, StringComparison.CurrentCultureIgnoreCase));

            await context.SaveChangesAsync();

            var query = new Queries.BuscaEventoPorId.BuscaEventoPorIdQuery { IdEvento = request.IdEvento, IdUsuarioLogado = request.IdUsuarioLogado, Token = request.Token };

            return await mediator.Send(query);
        }
    }
}
