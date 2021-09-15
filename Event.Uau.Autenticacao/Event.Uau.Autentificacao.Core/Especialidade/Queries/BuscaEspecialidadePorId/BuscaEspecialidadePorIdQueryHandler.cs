using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Especialidade;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Especialidade.Queries.BuscaEspecialidadePorId
{
    public class BuscaEspecialidadePorIdQueryHandler : IRequestHandler<BuscaEspecialidadePorIdQuery, EspecialidadeViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarEspecialidadePorIdValidator validation;

        public BuscaEspecialidadePorIdQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validation = new BuscarEspecialidadePorIdValidator(context);
        }

        public async Task<EspecialidadeViewModel> Handle(BuscaEspecialidadePorIdQuery request, CancellationToken cancellationToken)
        {
            validation.ValidateAndThrow(request);

            var especialidade = await context.Especialidades.FirstOrDefaultAsync(e => e.Id == request.IdEspecialidade);

            var especialidadeViewModel = mapper.Map<EspecialidadeViewModel>(especialidade);

            return especialidadeViewModel;
        }

    }
}
