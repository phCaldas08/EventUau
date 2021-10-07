using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Proposta.Queries.BuscarPropostasParceiro
{
    public class BuscarPropostasParceiroQueryHandler : IRequestHandler<BuscarPropostasParceiroQuery, ListaPropostaEventoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IParceiroIntegracao parceiroIntegracao;

        public BuscarPropostasParceiroQueryHandler(EventUauDbContext context,IMapper mapper ,IParceiroIntegracao parceiroIntegracao)
        {
            this.context = context;
            this.mapper = mapper;
            this.parceiroIntegracao = parceiroIntegracao;
        }

        public async Task<ListaPropostaEventoViewModel> Handle(BuscarPropostasParceiroQuery request, CancellationToken cancellationToken)
        {
            var parceiro = await parceiroIntegracao.BuscarParceiroPorIdUsuario(request.IdUsuarioLogado, request.Token);
            var pular = request.Indice * request.TamanhoPagina;
            var tamanho = request.TamanhoPagina;

            var propostasQuery = context.Funcionarios
                .Where(i => i.IdUsuario == request.IdUsuarioLogado && !i.Contratado && i.Evento.DataInicio > DateTime.Now)
                .OrderBy(i => i.Evento.DataInicio);

            var tamanhoTotal = propostasQuery.Count();

            var propostas = await propostasQuery.Skip(pular)
                .Take(tamanho)
                .ToListAsync();

            var propostasViewModel = new List<PropostaEventoViewModel>();

            propostas.ForEach(p =>
            {
                var vm = mapper.Map<PropostaEventoViewModel>(p);
                vm = mapper.Map(p.Evento, vm);

                propostasViewModel.Add(vm);
            });

            return new ListaPropostaEventoViewModel
            {
                Indice = request.Indice,
                TamanhoPagina = propostasViewModel.Count,
                Total = tamanhoTotal,
                Resultados = propostasViewModel
            };
        }
    }
}
