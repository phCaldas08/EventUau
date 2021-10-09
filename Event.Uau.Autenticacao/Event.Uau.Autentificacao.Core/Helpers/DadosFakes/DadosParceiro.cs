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
            var query = new Especialidade.Queries.BuscaEspecialidadePorId.BuscaEspecialidadePorIdQuery { IdEspecialidade = 1 };
            var result = await mediator.Send(query);

            var commands = new List<Parceiro.Commands.CadastrarParceiro.CadastrarParceiroCommand>
            {
                new Parceiro.Commands.CadastrarParceiro.CadastrarParceiroCommand
                {
                    IdUsuarioLogado = 2,
                    ValorHora = 10,
                    Especialidades = new List<ViewModel.Autenticacao.EspecialidadeViewModel>() {result}
                },
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }

    }
}
