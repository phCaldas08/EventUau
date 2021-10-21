using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.StatusContratacao.Commands.CadastrarStatusContratacao
{
    public class CadastrarStatusContratacaoCommandHandler : IRequestHandler<CadastrarStatusContratacaoCommand, StatusContratacaoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly CadastrarStatusContratacaoCommandValidator validator;

        public CadastrarStatusContratacaoCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new CadastrarStatusContratacaoCommandValidator(context);
        }

        public async Task<StatusContratacaoViewModel> Handle(CadastrarStatusContratacaoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var status = mapper.Map<Domain.Entities.StatusContratacao>(request);

            await context.StatusContratacoes.AddAsync(status);

            await context.SaveChangesAsync();

            var query = new Queries.BuscarStatusContratacaoPorId.BuscarStatusContratacaoPorIdQuery { Id = request.Id };

            return await mediator.Send(query);
        }
    }
}
