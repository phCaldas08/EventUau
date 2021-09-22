using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiros
{
    public class BuscarParceirosQueryHandler : IRequestHandler<BuscarParceirosQuery, ListaParceiroViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;

        public BuscarParceirosQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ListaParceiroViewModel> Handle(BuscarParceirosQuery request, CancellationToken cancellationToken)
        {
            var pular = request.Indice * request.TamanhoPagina;
            var tamanho = request.TamanhoPagina;

            var parceirosQuery = context.Parceiros.Where(i => i.IdUsuario != request.IdUsuarioLogado);

            var tamanhoTotal = parceirosQuery.Count();

            var parceirosOrdenados = OrdenarParceiros(parceirosQuery, request.ChaveOrdenacao, request.Ascendente);

            var parceiros = await parceirosQuery.Skip(pular)
                .Take(tamanho)
                .ToListAsync();

            var parceirosViewModel = mapper.Map<List<ParceiroResumoViewModel>>(parceiros);

            return new ListaParceiroViewModel
            {
                Indice = request.Indice,
                TamanhoPagina = parceirosViewModel.Count,
                Total = tamanhoTotal,
                Resultados = parceirosViewModel
            };
        }

        private IEnumerable<Domain.Entities.Parceiro> OrdenarParceiros(IQueryable<Domain.Entities.Parceiro> parceiros, string chaveOrdenacao, bool ascendente)
        {
            if (ascendente)
                return parceiros.OrderBy(BuscarParceirosQuerySettings.DicionarioOrdenacao[chaveOrdenacao]);
            else
                return parceiros.OrderByDescending(BuscarParceirosQuerySettings.DicionarioOrdenacao[chaveOrdenacao]);
        }
    }
}
