using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Evento.Core.StatusContratacao.Commands.CadastrarStatusContratacao;
using MediatR;

namespace Event.Uau.Evento.Core.Helpers.DadosFakes
{
    public static class DadosStatusContratacao
    {
        public static async Task CarregarDadosStatusContratacao(this IMediator mediator)
        {
            var commands = new List<CadastrarStatusContratacaoCommand>
            {
                new CadastrarStatusContratacaoCommand
                {
                    Id = "PEN",
                    Descricao = "Pendente",
                    EhRecusado = false
                },
                new CadastrarStatusContratacaoCommand
                {
                    Id = "AC",
                    Descricao = "Aceito",
                    EhRecusado = false

                },
                new CadastrarStatusContratacaoCommand
                {
                    Id = "REC",
                    Descricao = "Recusado",
                    EhRecusado = true
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }
    }
}
