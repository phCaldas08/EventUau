using System;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Commands.Update
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(x => x.Date)
                .GreaterThan(DateTime.Now);

            RuleFor(x => x.Key)
                .NotNull()
                .When(x => x.Key != new Guid());

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
