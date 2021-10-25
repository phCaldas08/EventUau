using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Core.Carteira.Commads.CadastrarCarteira;
using Event.Uau.Carteira.Core.Operacao.Queries.BuscarOperacaoPorId;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Carteira.Persistence;
using Event.Uau.Carteira.ViewModel.Carteira;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.ProspostaEvento.Commands.CriarOperacaoEvento
{
    public class CriarOperacaoEventoCommandHandler : IRequestHandler<CriarOperacaoEventoCommand, OperacaoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMediator mediator;
        private readonly CriarOperacaoEventoCommandValidator validator;

        public CriarOperacaoEventoCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator, IUsuarioIntegracao usuarioIntegracao, IEventoIntegracao eventoIntegracao)
        {
            this.context = context;
            this.mediator = mediator;
            this.validator = new CriarOperacaoEventoCommandValidator(context, mapper, usuarioIntegracao, eventoIntegracao);
        }

        public async Task<OperacaoViewModel> Handle(CriarOperacaoEventoCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            await CadastrarCarteiraParaFuncionario(request);

            var tipoPagamento = await context.TiposOperacoes.FirstOrDefaultAsync(i => i.Descricao.Equals("RESERVA_PAGAMENTO", StringComparison.CurrentCultureIgnoreCase));
            var tipoRecebimento = await context.TiposOperacoes.FirstOrDefaultAsync(i => i.Descricao.Equals("RESERVA_RECEBIMENTO", StringComparison.CurrentCultureIgnoreCase));

            var dataHora = DateTime.Now;

            var operacaoEvento = new Domain.Entities.OperacaoEvento
            {
                IdEvento = request.IdEvento,
                Pagamento = new Domain.Entities.Operacao
                {
                    IdUsuario = request.IdUsuarioLogado,
                    DataHora = dataHora,
                    Valor = request.Valor,
                    TipoOperacao = tipoPagamento
                },
                Recebimento = new Domain.Entities.Operacao
                {
                    IdUsuario = request.IdFuncionario,
                    DataHora = dataHora,
                    TipoOperacao = tipoRecebimento,
                    Valor = request.Valor * 0.87m
                }
            };

            await context.OperacoesEventos.AddAsync(operacaoEvento);

            await context.SaveChangesAsync();

            var query = new BuscarOperacaoPorIdQuery
            {
                IdOperacao = operacaoEvento.IdPagador,
                IdUsuarioLogado = request.IdUsuarioLogado
            };

            return await mediator.Send(query);

        }

        private async Task CadastrarCarteiraParaFuncionario(CriarOperacaoEventoCommand request)
        {
            if (!await context.Carteiras.AnyAsync(i => i.IdUsuario == request.IdFuncionario))
            {
                var cadastrarCarteiraCommand = new CadastrarCarteiraCommand { IdUsuarioLogado = request.IdFuncionario };
                await mediator.Send(cadastrarCarteiraCommand);
            }
        }
    }
}
