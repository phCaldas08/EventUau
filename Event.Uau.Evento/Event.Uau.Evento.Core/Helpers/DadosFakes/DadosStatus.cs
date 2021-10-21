using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.Status.Commands.CadastrarStatus;
using MediatR;

namespace Event.Uau.Evento.Core.Helpers.DadosFakes
{
    public static class DadosStatus
    {
        public async static Task CarregarDadosStatus(this IMediator mediator)
        {
            var commands = new List<CadastrarStatusCommand>
            {
                new CadastrarStatusCommand()
                {
                    Descricao = "Criado",
                    Id = "CRIADO",
                }, 
                new CadastrarStatusCommand()
                {
                    Descricao = "Contratando",
                    Id = "CONTRATANDO",
                },
                new CadastrarStatusCommand()
                {
                    Descricao = "Finalizado",
                    Id = "FINALIZADO"
                },
                new CadastrarStatusCommand()
                {
                    Descricao = "Cancelado",
                    Id = "CANCELADO"
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }
    }
}
