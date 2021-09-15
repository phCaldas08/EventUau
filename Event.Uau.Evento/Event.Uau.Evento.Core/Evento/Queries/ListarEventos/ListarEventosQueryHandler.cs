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

namespace Event.Uau.Evento.Core.Evento.Queries.ListarEventos
{
    public class ListarEventosQueryHandler : IRequestHandler<ListarEventosQuery, ListaEventoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IUsuarioIntegracao usuarioIntegracao;

        public ListarEventosQueryHandler(EventUauDbContext context, IMapper mapper, IUsuarioIntegracao usuarioIntegracao)
        {
            this.context = context;
            this.mapper = mapper;
            this.usuarioIntegracao = usuarioIntegracao;
        }

        public async Task<ListaEventoViewModel> Handle(ListarEventosQuery request, CancellationToken cancellationToken)
        {
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
        }

        private async Task BuscarFuncionarios(List<ResumoEventoViewModel> eventos, string token)
        {
            foreach (var e in eventos)
                if(e.Funcionarios?.Any() ?? false)
                    foreach (var f in e.Funcionarios)
                        f.Funcionario = await usuarioIntegracao.BuscaUsuarioPorId(f.IdUsuario, token);
        }
    }
}
