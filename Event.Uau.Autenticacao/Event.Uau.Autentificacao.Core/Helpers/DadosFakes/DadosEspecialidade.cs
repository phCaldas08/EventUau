using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Helpers.DadosFakes
{
    public static class DadosEspecialidade
    {
        public static async Task CarregarEspecialidadesAsync(this IMediator mediator)
        {
            var commands = new List<Especialidade.Commands.CadastrarEspecialidade.CadastrarEspecialidadeCommand>
            {
                new Especialidade.Commands.CadastrarEspecialidade.CadastrarEspecialidadeCommand
                {
                    Descricao = "Garçom"
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }
    }
}