using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Evento.Commands.AlterarStatusEvento;
using Event.Uau.Evento.Core.Evento.Queries.BuscaEventoPorId;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Evento.Commands.CancelarEvento
{
    public class CancelarEventoCommandHandler : IRequestHandler<CancelarEventoCommand, EventoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMediator mediator;
        private readonly IPropostaIntegracao propostaIntegracao;
        private readonly CancelarEventoCommandValidator validator;

        public CancelarEventoCommandHandler(EventUauDbContext context, IMediator mediator, IPropostaIntegracao propostaIntegracao)
        {
            this.context = context;
            this.mediator = mediator;
            this.propostaIntegracao = propostaIntegracao;
            this.validator = new CancelarEventoCommandValidator(context);
        }

        public async Task<EventoViewModel> Handle(CancelarEventoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var evento = await context.Eventos.FirstOrDefaultAsync(i => i.Id == request.IdEvento);

            foreach (var funcionario in evento.Funcionarios)
                funcionario.StatusContratacao = await context.StatusContratacoes.FirstOrDefaultAsync(i => i.Id.Equals("REC", StringComparison.CurrentCultureIgnoreCase));

            await context.SaveChangesAsync();

            var eventoViewModel = await AlterarStatus(request, Domain.Enums.StatusEnum.CANCELADO);

            try
            {
                await propostaIntegracao.CancelarEvento(request.IdEvento, request.Token);
            }
            catch
            {
                await AlterarStatus(request, Domain.Enums.StatusEnum.CONTRATANDO);
                throw;
            }

            return eventoViewModel;
        }

        private async Task<EventoViewModel> AlterarStatus(CancelarEventoCommand request, Domain.Enums.StatusEnum status)
        {
            var atualizarCommand = new AlterarStatusEventoCommand
            {
                IdEvento = request.IdEvento,
                IdUsuarioLogado = request.IdUsuarioLogado,
                Token = request.Token,
                Status = status
            };

            return await mediator.Send(atualizarCommand);
        }
    }
}
