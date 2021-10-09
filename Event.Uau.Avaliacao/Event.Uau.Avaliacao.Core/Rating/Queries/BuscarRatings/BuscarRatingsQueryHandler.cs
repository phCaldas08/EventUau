using AutoMapper;
using Event.Uau.Avaliacao.Persistence;
using Event.Uau.Rating.ViewModel.Rating;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Avaliacao.Core.Rating.Queries.BuscarRatings
{
    public class BuscarRatingsQueryHandler : IRequestHandler<BuscarRatingsQuery, List<RatingViewModel>>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;

        public BuscarRatingsQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<RatingViewModel>> Handle(BuscarRatingsQuery request, CancellationToken cancellationToken)
        {
            var ratings = await context.Ratings.ToListAsync();

            var ratingsViewModel = mapper.Map<List<RatingViewModel>>(ratings);

            return ratingsViewModel;
        }
    }
}
