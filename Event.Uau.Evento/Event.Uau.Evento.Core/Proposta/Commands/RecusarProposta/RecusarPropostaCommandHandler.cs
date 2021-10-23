using System;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Proposta.Commands.RecusarProposta
{
    public class RecusarPropostaCommandHandler : IRequestHandler<RecusarPropostaCommand, bool>
    {
        private readonly EventUauDbContext context;
        private readonly IPropostaIntegracao propostaIntegracao;
        private readonly RecusarPropostaCommandValidator validator;

        public RecusarPropostaCommandHandler(EventUauDbContext context, IPropostaIntegracao propostaIntegracao)
        {
            this.context = context;
            this.propostaIntegracao = propostaIntegracao;
            this.validator = new RecusarPropostaCommandValidator(context);
        }

        public async Task<bool> Handle(RecusarPropostaCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var funcionario = await context.Funcionarios.FirstOrDefaultAsync(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado);
            var statusAntigo = funcionario.IdStatusContratacao;

            funcionario.StatusContratacao = await context.StatusContratacoes.FirstOrDefaultAsync(i => i.Id.Equals("REC", StringComparison.CurrentCultureIgnoreCase));

            await context.SaveChangesAsync();

            try
            {
                await propostaIntegracao.RecusarPropostaEvento(request.IdEvento, request.Token);
            }
            catch
            {
                funcionario.IdStatusContratacao = statusAntigo;

                await context.SaveChangesAsync();

                throw;
            }

            return true;
        }
    }
}
