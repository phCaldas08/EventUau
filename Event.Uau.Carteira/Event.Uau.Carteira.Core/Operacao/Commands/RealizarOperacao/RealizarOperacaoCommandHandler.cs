using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Persistence;
using Event.Uau.Carteira.ViewModel.Carteira;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.Operacao.Commands.RealizarOperacao
{
    public class RealizarOperacaoCommandHandler : IRequestHandler<RealizarOperacaoCommand, OperacaoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly RealizarOperacaoCommandValidator validator;

        public RealizarOperacaoCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new RealizarOperacaoCommandValidator(context, mapper);
        }

        public async Task<OperacaoViewModel> Handle(RealizarOperacaoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var operacao = mapper.Map<Domain.Entities.Operacao>(request);

            var tipoOperacao = await context.TiposOperacoes
                .FirstOrDefaultAsync(i => i.Descricao.Equals(request.TipoOperacao, StringComparison.CurrentCultureIgnoreCase));

            operacao.TipoOperacao = tipoOperacao;

            await context.Operacoes.AddAsync(operacao);

            await context.SaveChangesAsync();

            var query = new Queries.BuscarOperacaoPorId.BuscarOperacaoPorIdQuery
            {
                IdOperacao = operacao.Id,
                IdUsuarioLogado = request.IdUsuarioLogado
            };

            return await mediator.Send(query);
        }
    }
}
