using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Carteira.Core.Carteira.Commads.CadastrarCarteira;
using MediatR;

namespace Event.Uau.Carteira.Core.Helpers.DadosFake
{
    public static class DadosCarteira
    {
        public static async Task CarregarDadosCarteira(this IMediator mediator)
        {
            var commands = new List<CadastrarCarteiraCommand>
            {
                new CadastrarCarteiraCommand
                {
                    IdUsuarioLogado = 1,
                },
                new CadastrarCarteiraCommand
                {
                    IdUsuarioLogado = 2,
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }
    }
}
