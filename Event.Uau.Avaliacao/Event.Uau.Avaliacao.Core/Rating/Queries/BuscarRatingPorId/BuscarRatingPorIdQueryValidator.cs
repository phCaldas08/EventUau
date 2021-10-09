using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event.Uau.Avaliacao.Core.Rating.Queries.BuscarRatingPorId
{
    public class BuscarRatingPorIdQueryValidator : AbstractValidator<BuscarRatingPorIdQuery>
    {
        public BuscarRatingPorIdQueryValidator(Persistence.EventUauDbContext context)
        {
            RuleFor(x => x.IdRating)
                .Must(id => context.Ratings.Any(i => i.Id == id))
                .WithMessage("Rating (avaliação) não encontrado.");
        }
    }
}