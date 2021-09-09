using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using FluentValidation;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Especialidade.Commands.CadastrarEspecialidade
{
    public class CadastrarEspecialidadeCommandHandler : IRequestHandler<CadastrarEspecialidadeCommand, ViewModel.Especialidade.EspecialidadeViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;

        public CadastrarEspecialidadeCommandHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ViewModel.Especialidade.EspecialidadeViewModel> Handle(CadastrarEspecialidadeCommand request, CancellationToken cancellationToken)
        {
            var especialidade = mapper.Map<Domain.Entities.Especialidade>(request);

            await context.Especialidades.AddAsync(especialidade);

            await context.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<ViewModel.Especialidade.EspecialidadeViewModel>(especialidade);

            return result;
        }
    }
}
