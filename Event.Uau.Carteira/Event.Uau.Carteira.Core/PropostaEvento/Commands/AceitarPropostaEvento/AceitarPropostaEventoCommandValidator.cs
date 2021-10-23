using System;
using System.Linq;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Carteira.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.AceitarPropostaEvento
{
    public class AceitarPropostaEventoCommandValidator : AbstractValidator<AceitarPropostaEventoCommand>
    {
        public AceitarPropostaEventoCommandValidator(EventUauDbContext context, IEventoIntegracao eventoIntegracao)
        {
            RuleFor(i => new { i.IdEvento, i.Token })
                .MustAsync((obj, c) => eventoIntegracao.VerificarIdExistente(obj.IdEvento, obj.Token))
                .WithMessage("Evento não encontrado.");

            RuleFor(i => i)
                .Must(request => context.OperacoesEventos.Any(i => i.Recebimento.IdUsuario == request.IdUsuarioLogado && i.IdEvento == request.IdEvento))
                .WithMessage("Proposta não encontrada na carteira.");

        }
    }
}
