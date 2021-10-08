using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using FluentValidation;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Especialidade.Commands.CadastrarEspecialidade
{
    public class CadastrarEspecialidadeCommandHandler : IRequestHandler<CadastrarEspecialidadeCommand, ViewModel.Autenticacao.EspecialidadeViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly CadastrarEspecialidadeCommandValidator validation;

        public CadastrarEspecialidadeCommandHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validation = new CadastrarEspecialidadeCommandValidator(context);
        }

        public async Task<ViewModel.Autenticacao.EspecialidadeViewModel> Handle(CadastrarEspecialidadeCommand request, CancellationToken cancellationToken)
        {
            validation.ValidateAndThrow(request);

            var especialidade = mapper.Map<Domain.Entities.Especialidade>(request);

            await context.Especialidades.AddAsync(especialidade);

            await context.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<ViewModel.Autenticacao.EspecialidadeViewModel>(especialidade);

            return result;
        }
    }
}
