using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Helpers.DadosFakes
{
    public static class DadosParceiro
    {
        public static async Task CarregarParceirosAsync(this IMediator mediator)
        {
            var commands = new List<Parceiro.Commands.CadastrarParceiro.CadastrarParceiroCommand>
            {
                new Parceiro.Commands.CadastrarParceiro.CadastrarParceiroCommand
                {
                    IdUsuarioLogado = 2,
                    ValorHora = 10
                },
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }

    }
}
