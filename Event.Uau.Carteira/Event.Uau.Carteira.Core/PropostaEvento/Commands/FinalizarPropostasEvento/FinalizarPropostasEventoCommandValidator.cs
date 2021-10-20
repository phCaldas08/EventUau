using System;
using System.Linq;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Carteira.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.FinalizarPropostasEvento
{
    public class FinalizarPropostasEventoCommandValidator : AbstractValidator<FinalizarPropostasEventoCommand>
    {
        public FinalizarPropostasEventoCommandValidator(EventUauDbContext context, IEventoIntegracao eventoIntegracao)
        {
            RuleFor(i => new { i.IdEvento, i.Token })
                .MustAsync((obj, c) => eventoIntegracao.VerificarEventoFinalizadoExistente(obj.IdEvento, obj.Token))
                .WithMessage("Evento não encontrado.");


        }
    }
}
