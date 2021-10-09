using AutoMapper;
using Event.Uau.Avaliacao.Persistence;
using Event.Uau.Avaliacao.ViewModel.Rating;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Event.Uau.Avaliacao.Core.Rating.Queries.BuscarRatingPorId
{
    public class BuscarRatingPorIdQueryHandler : IRequestHandler<BuscarRatingPorIdQuery, RatingViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarRatingPorIdQueryValidator validator;

        public BuscarRatingPorIdQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscarRatingPorIdQueryValidator(context);
        }

        public async Task<RatingViewModel> Handle(BuscarRatingPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var rating = await context.Ratings.FirstOrDefaultAsync(e => e.Id == request.IdRating);

            var ratingViewModel = mapper.Map<RatingViewModel>(rating);

            return ratingViewModel;
        }
    }
}
