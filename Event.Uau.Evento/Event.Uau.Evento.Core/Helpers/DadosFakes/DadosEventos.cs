using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Event.Uau.Evento.Core.Helpers.DadosFakes
{
    public static class DadosEventos
    {
        public static async Task CarregarEventosAsync(this IMediator mediator)
        {
            var commands = new List<Evento.Commands.CriarEvento.CriarEventoCommand>
            {
                new Evento.Commands.CriarEvento.CriarEventoCommand()
                {
                    Nome = "Churrasco",
                    Numero = 1,
                    Descricao = "Churrasco de final de semana",
                    IdUsuarioLogado = 2,
                    DuracaoMinima = 5,
                    DuracaoMaxima = 12,
                    DataInicio = DateTime.Parse("2021-11-20T15:00:00.0000000-03:00"),
                    DataTermino = DateTime.Parse("2021-11-21T03:00:00.0000000-03:00")
                },
                new Evento.Commands.CriarEvento.CriarEventoCommand()
                {
                    Nome = "Rock in Rio",
                    IdUsuarioLogado = 3,
                    Numero = 2,
                    Descricao = "Rock in Rio 2022",
                    DuracaoMinima = 100,
                    DuracaoMaxima = 150,
                    DataInicio = DateTime.Parse("2022-11-2T10:00:00.0000000-03:00"),
                    DataTermino = DateTime.Parse("2022-11-11T12:00:00.0000000-03:00")
                },
                new Evento.Commands.CriarEvento.CriarEventoCommand()
                {
                    Nome = "Casamento",
                    Numero = 3,
                    IdUsuarioLogado = 4,
                    Descricao = "Casamento",
                    DuracaoMinima = 1,
                    DuracaoMaxima = 2,
                    DataInicio = DateTime.Parse("2021-11-11T14:00:00.0000000-03:00"),
                    DataTermino = DateTime.Parse("2021-11-11T16:00:00.0000000-03:00")
                },
                new Evento.Commands.CriarEvento.CriarEventoCommand()
                {
                    Nome = "Aniversário",
                    Numero = 4,
                    Descricao = "Aniversário de criança",
                    IdUsuarioLogado = 5,
                    DuracaoMinima = 2,
                    DuracaoMaxima = 5,
                    DataInicio = DateTime.Parse("2022-1-9T17:00:00.0000000-03:00"),
                    DataTermino = DateTime.Parse("2022-1-9T22:00:00.0000000-03:00")
                },
                new Evento.Commands.CriarEvento.CriarEventoCommand()
                {
                    Nome = "Formatura",
                    Numero = 5,
                    IdUsuarioLogado = 6,
                    Descricao = "Formatura do 4SIT",
                    DuracaoMinima = 5,
                    DuracaoMaxima = 7,
                    DataInicio = DateTime.Parse("2021-12-12T14:00:00.0000000-03:00"),
                    DataTermino = DateTime.Parse("2021-12-12T21:00:00.0000000-03:00")
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);


        }
    }
}