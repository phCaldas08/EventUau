using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Evento.Queries.BuscaEventoPorId
{
    public class BuscaEventoPorIdQueryHandler : IRequestHandler<BuscaEventoPorIdQuery, EventoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IUsuarioIntegracao usuarioIntegracao;
        private readonly BuscaEventoPorIdQueryValidator validator;

        public BuscaEventoPorIdQueryHandler(EventUauDbContext context, IMapper mapper, IUsuarioIntegracao usuarioIntegracao)
        {
            this.context = context;
            this.mapper = mapper;
            this.usuarioIntegracao = usuarioIntegracao;
            this.validator = new BuscaEventoPorIdQueryValidator(context);
        }

        public async Task<EventoViewModel> Handle(BuscaEventoPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var evento = await context.Eventos.FirstOrDefaultAsync(e => e.Id == request.IdEvento);

            var eventoViewModel = mapper.Map<EventoViewModel>(evento);

            await BuscaUsuarios(eventoViewModel, evento, request.Token);

            return eventoViewModel;
        }

        private async Task BuscaUsuarios(EventoViewModel eventoViewModel, Domain.Entities.Evento evento, string token)
        {
            eventoViewModel.Usuario = await usuarioIntegracao.BuscaUsuarioPorId(evento.IdUsuario, token);

            foreach(var funcionario in await usuarioIntegracao.BuscaUsuariosPorIds(evento.Funcionarios.Select(i => i.IdFuncionario), token))
            {
                eventoViewModel.FuncionariosEvento.FirstOrDefault(i => i.IdUsuario == funcionario.Id).Funcionario = funcionario;
            }
        }
    }
}
