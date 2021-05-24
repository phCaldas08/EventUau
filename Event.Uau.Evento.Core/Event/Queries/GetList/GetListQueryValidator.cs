using System;
using FluentValidation;

namespace Event.Uau.Evento.Core.Event.Queries.GetList
{
    public class GetListQueryValidator : AbstractValidator<GetListQuery>
    {
        public GetListQueryValidator()
        {
            RuleFor(x => x.StartDate)
                .NotNull()
                .When(x => x.EndDate.HasValue && x.StartDate <= x.EndDate);

            RuleFor(x => x.Index)
                .NotNull()
                .When(x => x.Index >= 0);

            RuleFor(x => x.PageSize)
                .NotNull()
                .When(x => x.Index >= 0);
        }
    }
}
