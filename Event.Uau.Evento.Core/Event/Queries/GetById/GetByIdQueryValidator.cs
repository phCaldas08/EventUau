using System;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Queries.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(x => x.Key)
                .NotNull();
        }
    }
}
