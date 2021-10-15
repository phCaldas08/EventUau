using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Persistence;
using Event.Uau.Carteira.ViewModel.Carteira;
using Event.Uau.Comum.Util.Mediator;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.TipoOperacao.Queries.BuscarTipoOperacaoPorId
{
    public class BuscarTipoOperacaoPorIdQueryHandler : IRequestHandler<BuscarTipoOperacaoPorIdQuery, TipoOperacaoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarTipoOperacaoPorIdQueryValidator validator;

        public BuscarTipoOperacaoPorIdQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscarTipoOperacaoPorIdQueryValidator(context);
        }

        public async Task<TipoOperacaoViewModel> Handle(BuscarTipoOperacaoPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var tipoOperacao = await context.TiposOperacoes.FirstOrDefaultAsync(i => i.Id.Equals(request.IdTipoOperacao, StringComparison.CurrentCultureIgnoreCase));

            var tipoOperacaoViewModel = mapper.Map<TipoOperacaoViewModel>(tipoOperacao);

            return tipoOperacaoViewModel;
        }
    }
}
