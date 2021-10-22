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
                    ValorHora = 10,
                    Especialidades = new List<ViewModel.Autenticacao.EspecialidadeViewModel>
                    {
                        new ViewModel.Autenticacao.EspecialidadeViewModel
                        {
                            Id = 1
                        }
                    }
                },
                new Parceiro.Commands.CadastrarParceiro.CadastrarParceiroCommand
                {
                    IdUsuarioLogado = 3,
                    ValorHora = 15,
                    Especialidades = new List<ViewModel.Autenticacao.EspecialidadeViewModel>
                    {
                        new ViewModel.Autenticacao.EspecialidadeViewModel
                        {
                            Id = 2
                        }
                    }
                },
                new Parceiro.Commands.CadastrarParceiro.CadastrarParceiroCommand
                {
                    IdUsuarioLogado = 4,
                    ValorHora = 20,
                    Especialidades = new List<ViewModel.Autenticacao.EspecialidadeViewModel>
                    {
                        new ViewModel.Autenticacao.EspecialidadeViewModel
                        {
                            Id = 3
                        }
                    }
                },
                new Parceiro.Commands.CadastrarParceiro.CadastrarParceiroCommand
                {
                    IdUsuarioLogado = 5,
                    ValorHora = 25,
                    Especialidades = new List<ViewModel.Autenticacao.EspecialidadeViewModel>
                    {
                        new ViewModel.Autenticacao.EspecialidadeViewModel
                        {
                            Id = 4
                        }
                    }
                },
                new Parceiro.Commands.CadastrarParceiro.CadastrarParceiroCommand
                {
                    IdUsuarioLogado = 6,
                    ValorHora = 30,
                    Especialidades = new List<ViewModel.Autenticacao.EspecialidadeViewModel>
                    {
                        new ViewModel.Autenticacao.EspecialidadeViewModel
                        {
                            Id = 5
                        }
                    }
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }

    }
}
