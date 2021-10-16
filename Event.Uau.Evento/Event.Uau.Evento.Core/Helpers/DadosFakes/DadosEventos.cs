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
                    IdUsuarioLogado = 1,
                    DuracaoMinima = 5,
                    DuracaoMaxima = 12,
                    DataInicio = DateTime.Parse("20/11/2021 15:00:00"),
                    DataTermino = DateTime.Parse("21/11/2021 03:00:00")
                },
                new Evento.Commands.CriarEvento.CriarEventoCommand()
                {
                    Nome = "Rock in Rio",
                    IdUsuarioLogado = 2,
                    Numero = 2,
                    Descricao = "Rock in Rio 2022",
                    DuracaoMinima = 100,
                    DuracaoMaxima = 150,
                    DataInicio = DateTime.Parse("2/11/2022 10:00:00"),
                    DataTermino = DateTime.Parse("11/11/2022 12:00:00")
                },
                new Evento.Commands.CriarEvento.CriarEventoCommand()
                {
                    Nome = "Casamento",
                    Numero = 3,
                    IdUsuarioLogado = 3,
                    Descricao = "Casamento",
                    DuracaoMinima = 1,
                    DuracaoMaxima = 2,
                    DataInicio = DateTime.Parse("11/11/2021 14:00:00"),
                    DataTermino = DateTime.Parse("11/11/2021 16:00:00")
                },
                new Evento.Commands.CriarEvento.CriarEventoCommand()
                {
                    Nome = "Aniversário",
                    Numero = 4,
                    Descricao = "Aniversário de criança",
                    IdUsuarioLogado = 4,
                    DuracaoMinima = 2,
                    DuracaoMaxima = 5,
                    DataInicio = DateTime.Parse("9/1/2022 17:00:00"),
                    DataTermino = DateTime.Parse("9/1/2022 22:00:00")
                },
                new Evento.Commands.CriarEvento.CriarEventoCommand()
                {
                    Nome = "Formatura",
                    Numero = 5,
                    IdUsuarioLogado = 5,
                    Descricao = "Formatura do 4SIT",
                    DuracaoMinima = 5,
                    DuracaoMaxima = 7,
                    DataInicio = DateTime.Parse("12/12/2021 14:00:00"),
                    DataTermino = DateTime.Parse("12/12/2021 21:00:00")
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);


        }
    }
}