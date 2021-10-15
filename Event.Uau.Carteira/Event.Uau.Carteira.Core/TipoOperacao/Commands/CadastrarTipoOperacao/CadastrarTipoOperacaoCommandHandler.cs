using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Core.TipoOperacao.Queries.BuscarTipoOperacaoPorId;
using Event.Uau.Carteira.Persistence;
using Event.Uau.Carteira.ViewModel.Carteira;
using FluentValidation;
using MediatR;

namespace Event.Uau.Carteira.Core.TipoOperacao.Commands.CadastrarTipoOperacao
{
    public class CadastrarTipoOperacaoCommandHandler : IRequestHandler<CadastrarTipoOperacaoCommand, TipoOperacaoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly CadastrarTipoOperacaoCommandValidator validator;

        public CadastrarTipoOperacaoCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new CadastrarTipoOperacaoCommandValidator(context);
        }

        public async Task<TipoOperacaoViewModel> Handle(CadastrarTipoOperacaoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var tipoOperacao = mapper.Map<Domain.Entities.TipoOperacao>(request);

            await context.TiposOperacoes.AddAsync(tipoOperacao);

            await context.SaveChangesAsync();

            var query = new BuscarTipoOperacaoPorIdQuery { IdTipoOperacao = request.Id };

            return await mediator.Send(query);

        }
    }
}
