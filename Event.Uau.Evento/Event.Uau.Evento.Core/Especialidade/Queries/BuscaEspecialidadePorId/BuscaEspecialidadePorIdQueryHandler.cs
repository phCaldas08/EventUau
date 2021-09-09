using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Especialidade;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Especialidade.Queries.BuscaEspecialidadePorId
{
    public class BuscaEspecialidadePorIdQueryHandler : IRequestHandler<BuscaEspecialidadePorIdQuery, EspecialidadeViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IUsuarioIntegracao usuarioIntegracao;

        public BuscaEspecialidadePorIdQueryHandler(EventUauDbContext context, IMapper mapper, IUsuarioIntegracao usuarioIntegracao)
        {
            this.context = context;
            this.mapper = mapper;
            this.usuarioIntegracao = usuarioIntegracao;
        }

        public async Task<EspecialidadeViewModel> Handle(BuscaEspecialidadePorIdQuery request, CancellationToken cancellationToken)
        {
            var especialidade = await context.Especialidades.FirstOrDefaultAsync(e => e.Id == request.IdEspecialidade);

            var especialidadeViewModel = mapper.Map<EspecialidadeViewModel>(especialidade);

            return especialidadeViewModel;
        }

    }
}
