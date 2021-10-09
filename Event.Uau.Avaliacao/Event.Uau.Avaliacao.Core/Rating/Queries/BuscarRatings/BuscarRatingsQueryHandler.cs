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
using Event.Uau.Avaliacao.ViewModel.Rating;

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


            /*
            var pular = request.Indice * request.TamanhoPagina;
            var tamanho = request.TamanhoPagina;

            var eventosQuery = context.Eventos.Where(i => i.IdUsuario == request.IdUsuarioLogado);

            var tamanhoTotal = eventosQuery.Count();

            var eventos = await eventosQuery.Skip(pular)
                .Take(tamanho)
                .ToListAsync();

            var eventosViewModel = mapper.Map<List<ResumoEventoViewModel>>(eventos);

            await BuscarFuncionarios(eventosViewModel, request.Token);

            return new ListaEventoViewModel
            {
                Indice = request.Indice,
                TamanhoPagina = eventos.Count,
                Total = tamanhoTotal,
                Resultados = eventosViewModel
            }; 
             */
        }
    }
}
