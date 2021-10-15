using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Persistence;
using FluentValidation;
using MediatR;

namespace Event.Uau.Carteira.Core.Carteira.Commads.CadastrarCarteira
{
    public class CadastrarCarteiraCommandHandler : IRequestHandler<CadastrarCarteiraCommand, int>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly CadastrarCarteiraCommandValidator validator;

        public CadastrarCarteiraCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new CadastrarCarteiraCommandValidator(context);
        }

        public async Task<int> Handle(CadastrarCarteiraCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var carteira = mapper.Map<Domain.Entities.Carteira>(request);

            await context.Carteiras.AddAsync(carteira);

            await context.SaveChangesAsync();

            return 0;
        }
    }
}
