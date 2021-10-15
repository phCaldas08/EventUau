using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Core.Operacao.Queries.BuscarOperacaoPorId;
using Event.Uau.Carteira.Persistence;
using Event.Uau.Carteira.ViewModel.Carteira;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.Operacao.Commands.CriarOperacaoEvento
{
    public class CriarOperacaoEventoCommandHandler : IRequestHandler<CriarOperacaoEventoCommand, OperacaoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMediator mediator;

        public CriarOperacaoEventoCommandHandler(EventUauDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<OperacaoViewModel> Handle(CriarOperacaoEventoCommand request, CancellationToken cancellationToken)
        {
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
                    Valor = request.Valor
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
    }
}
