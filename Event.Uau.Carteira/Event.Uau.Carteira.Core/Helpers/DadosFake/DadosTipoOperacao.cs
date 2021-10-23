using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Carteira.Core.TipoOperacao.Commands.CadastrarTipoOperacao;
using MediatR;

namespace Event.Uau.Carteira.Core.Helpers.DadosFake
{
    public static class DadosTipoOperacao
    {
        public static async Task CarregarTiposOperacoes(this IMediator mediator)
        {
            var commands = new List<CadastrarTipoOperacaoCommand>
            {
                new CadastrarTipoOperacaoCommand
                {
                    Descricao = "DEPOSITO",
                    Id = "DEP",
                    EhDisponivel = true,
                    EhVisivel = true,
                    Multplicador = 1,
                },
                new CadastrarTipoOperacaoCommand
                {
                    Descricao = "SAQUE",
                    Id = "SAQ",
                    EhDisponivel = true,
                    EhVisivel = true,
                    Multplicador = -1,
                },
                new CadastrarTipoOperacaoCommand
                {
                    Descricao = "RESERVA_PAGAMENTO",
                    Id = "RPAG",
                    EhDisponivel = true,
                    EhVisivel = true,
                    Multplicador = -1
                },
                new CadastrarTipoOperacaoCommand
                {
                    Descricao = "RESERVA_RECEBIMENTO",
                    Id = "RRE",
                    EhDisponivel = false,
                    EhVisivel = false,
                    Multplicador = 1
                },
                new CadastrarTipoOperacaoCommand
                {
                    Descricao = "RECEBIMENTO_PENDENTE",
                    Id = "RPE",
                    EhDisponivel = false,
                    EhVisivel = true,
                    Multplicador = 1
                },
                new CadastrarTipoOperacaoCommand
                {
                    Descricao = "PAGAMENTO",
                    Id = "PAG",
                    EhDisponivel = true,
                    EhVisivel = true,
                    Multplicador = -1
                },
                new CadastrarTipoOperacaoCommand
                {
                    Descricao = "RECEBIMENTO",
                    Id = "RE",
                    EhDisponivel = true,
                    EhVisivel = true,
                    Multplicador = 1
                },
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }
    }
}
