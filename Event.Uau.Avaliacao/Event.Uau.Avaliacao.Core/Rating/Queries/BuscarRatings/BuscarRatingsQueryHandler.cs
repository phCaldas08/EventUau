using AutoMapper;
using Event.Uau.Avaliacao.Persistence;
using Event.Uau.Avaliacao.ViewModel.Rating;
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
    public class BuscarRatingsQueryHandler : IRequestHandler<BuscarRatingsQuery, ListaRatingViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;

        public BuscarRatingsQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ListaRatingViewModel> Handle(BuscarRatingsQuery request, CancellationToken cancellationToken)
        {
            var pular = request.Indice * request.TamanhoPagina;
            var tamanho = request.TamanhoPagina;

            var ratingsQuery = await context.Ratings.ToListAsync();

            var tamanhoTotal = ratingsQuery.Count();

            var ratings = ratingsQuery.Skip(pular)
                .Take(tamanho)
                .ToList();

            var ratingsViewModel = mapper.Map<List<RatingViewModel>>(ratings);

            return new ListaRatingViewModel
            {
                Indice = request.Indice,
                TamanhoPagina = ratings.Count,
                Total = tamanhoTotal,
                Resultados = ratingsViewModel
            };
        }
    }
}
