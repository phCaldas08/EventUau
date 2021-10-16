using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Persistence;
using Event.Uau.Carteira.ViewModel.Carteira;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.Operacao.Queries.BuscarOperacaoPorId
{
    public class BuscarOperacaoPorIdQueryHandler : IRequestHandler<BuscarOperacaoPorIdQuery, OperacaoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarOperacaoPorIdQueryValidator validator;

        public BuscarOperacaoPorIdQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscarOperacaoPorIdQueryValidator(context);
        }

        public async Task<OperacaoViewModel> Handle(BuscarOperacaoPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var operacao = await context.Operacoes.FirstOrDefaultAsync(i => i.Id == request.IdOperacao && i.IdUsuario == request.IdUsuarioLogado);

            var operacaoViewModel = mapper.Map<OperacaoViewModel>(operacao);

            return operacaoViewModel;
        }
    }
}
