using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Core.Proposta.Queries.BuscarPropostaPorId;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Proposta.Commands.AceitarProposta
{
    public class AceitarPropostaCommandHandler : IRequestHandler<AceitarPropostaCommand, FuncionarioEventoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMediator mediator;
        private readonly IPropostaIntegracao propostaIntegracao;
        private readonly AceitarPropostaCommandValidator validator;

        public AceitarPropostaCommandHandler(EventUauDbContext context, IPropostaIntegracao propostaIntegracao, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
            this.propostaIntegracao = propostaIntegracao;
            this.validator = new AceitarPropostaCommandValidator(context);
        }

        public async Task<FuncionarioEventoViewModel> Handle(AceitarPropostaCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var proposta = await context.Funcionarios.FirstOrDefaultAsync(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado);

            proposta.StatusContratacao = await context.StatusContratacoes.FirstOrDefaultAsync(i => i.Id.Equals("AC", StringComparison.CurrentCultureIgnoreCase));
            await context.SaveChangesAsync();

            try
            {
                await propostaIntegracao.AceitarPropostaEvento(request.IdEvento, request.Token);
            }
            catch
            {
                proposta.StatusContratacao = await context.StatusContratacoes.FirstOrDefaultAsync(i => i.Id.Equals("PEN", StringComparison.CurrentCultureIgnoreCase));
                await context.SaveChangesAsync();

                throw;
            }

            var query = new BuscaProspostaPorIdQuery { IdEvento = request.IdEvento, IdUsuarioLogado = request.IdUsuarioLogado, Token = request.Token };

            return await mediator.Send(query);
        }
    }
}
