using System;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Carteira.Persistence;
using FluentValidation;

namespace Event.Uau.Carteira.Core.PropostaEvento.Commands.CancelarEvento
{
    public class CancelarEventoCommandValidator : AbstractValidator<CancelarEventoCommand>
    {
        public CancelarEventoCommandValidator(IEventoIntegracao eventoIntegracao)
        {
            RuleFor(i => i)
                .MustAsync((request, c) => eventoIntegracao.VerificarEventoCanceladoExistente(request.IdEvento, request.Token))
                .WithMessage("Evento cancelado não encontrado.");
        }
    }
}
