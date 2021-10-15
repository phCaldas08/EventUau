using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Carteira.Core.Operacao.Commands.RealizarOperacao;
using MediatR;

namespace Event.Uau.Carteira.Core.Helpers.DadosFake
{
    public static class DadosOperacoes
    {

        public static async Task CarregarDadosOperacoes(this IMediator mediator)
        {
            var commands = new List<RealizarOperacaoCommand>
            {
                new RealizarOperacaoCommand
                {
                    IdUsuarioLogado = 1,
                    TipoOperacao = "DEPOSITO",
                    Valor = 100,

                },
                new RealizarOperacaoCommand
                {
                    IdUsuarioLogado = 1,
                    TipoOperacao = "DEPOSITO",
                    Valor = 50
                },
                new RealizarOperacaoCommand
                {
                    IdUsuarioLogado = 1,
                    TipoOperacao = "SAQUE",
                    Valor = 10
                },
                new RealizarOperacaoCommand
                {
                    IdUsuarioLogado = 1,
                    TipoOperacao = "RESERVA_PAGAMENTO",
                    Valor = 70,
                },
                new RealizarOperacaoCommand
                {
                    IdUsuarioLogado = 1,
                    TipoOperacao = "RESERVA_RECEBIMENTO",
                    Valor = 20
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }
    }
}
