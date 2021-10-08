using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Especialidade.Queries.BuscarEspecialidades
{
    public class BuscarEspecialidadesQueryHandler : IRequestHandler<BuscarEspecialidadesQuery, List<EspecialidadeViewModel>>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;

        public BuscarEspecialidadesQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<EspecialidadeViewModel>> Handle(BuscarEspecialidadesQuery request, CancellationToken cancellationToken)
        {
            var especialidades = await context.Especialidades.ToListAsync();

            var especialidadesViewModel = mapper.Map<List<EspecialidadeViewModel>>(especialidades);

            return especialidadesViewModel;
        }
    }
}
