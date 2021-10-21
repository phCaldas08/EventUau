using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Endereco.Core.Enderecos.Commands.CadastrarEndereco;
using MediatR;

namespace Event.Uau.Endereco.Core.Helpers.DadosFakes
{
    public static class DadosEnderecos
    {
        public static async Task CarregarDadosEnderecos(this IMediator mediator)
        {
            var commands = new List<CadastrarEnderecoCommand>
            {
                //Endereços de usuários
                new CadastrarEnderecoCommand
                {
                    Cep = "08599030",
                    Numero = "123",
                    Complemento = "Casa",
                    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "usuarios"},
                    Latitude = "-23.4673938",
                    Longitude = "-46.3452799",
                    IdUsuarioLogado = 1,
                    IdExterno = 1
                },
                new CadastrarEnderecoCommand
                {
                    Cep = "17212383",
                    Numero = "234",
                    Complemento = "Casa",
                    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "usuarios"},
                    Latitude = "-22.2940659",
                    Longitude = "-48.5596513",
                    IdUsuarioLogado = 1,
                    IdExterno = 2
                },
                new CadastrarEnderecoCommand
                {
                    Cep = "04289130",
                    Numero = "345",
                    Complemento = "Casa",
                    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "usuarios"},
                    Latitude = "-23.6065124",
                    Longitude = "-46.6156176",
                    IdUsuarioLogado = 1,
                    IdExterno = 3
                },
                new CadastrarEnderecoCommand
                {
                    Cep = "02147060",
                    Numero = "456",
                    Complemento = "Casa",
                    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "usuarios"},
                    Latitude = "-23.4975673",
                    Longitude = "-46.5658289",
                    IdUsuarioLogado = 1,
                    IdExterno = 4
                },
                //new CadastrarEnderecoCommand
                //{
                //    Cep = "05324090",
                //    Numero = "567",
                //    Complemento = "Casa",
                //    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "usuarios"},
                //    Latitude = "-23.5422527",
                //    Longitude = "-46.7564836",
                //    IdUsuarioLogado = 1,
                //    IdExterno = 5
                //}
                new CadastrarEnderecoCommand
                {
                    Cep = "02147060",
                    Numero = "456",
                    Complemento = "Quinto endereço",
                    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "usuarios"},
                    Latitude = "-23.4975673",
                    Longitude = "-46.5658289",
                    IdUsuarioLogado = 1,
                    IdExterno = 4
                }

                //Endereços de eventos
                //new CadastrarEnderecoCommand
                //{
                //    Cep = "13420001",
                //    Numero = "987",
                //    Complemento = "Casa",
                //    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "eventos"},
                //    Latitude = "-22.7229237",
                //    Longitude = "-47.6201630",
                //    IdUsuarioLogado = 1,
                //    IdExterno = 1
                //},
                //new CadastrarEnderecoCommand
                //{
                //    Cep = "13212510",
                //    Numero = "789",
                //    Complemento = "Casa",
                //    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "eventos"},
                //    Latitude = "-23.1443538",
                //    Longitude = "-47.0013523",
                //    IdUsuarioLogado = 1,
                //    IdExterno = 2
                //},
                //new CadastrarEnderecoCommand
                //{
                //    Cep = "08630035",
                //    Numero = "879",
                //    Complemento = "Casa",
                //    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "eventos"},
                //    Latitude = "-23.6577794",
                //    Longitude = "-46.3331031",
                //    IdUsuarioLogado = 1,
                //    IdExterno = 3
                //},
                //new CadastrarEnderecoCommand
                //{
                //    Cep = "09380677",
                //    Numero = "897",
                //    Complemento = "Casa",
                //    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "eventos"},
                //    Latitude = "-23.6464950",
                //    Longitude = "-46.5122166",
                //    IdUsuarioLogado = 1,
                //    IdExterno = 4
                //},
                //new CadastrarEnderecoCommand
                //{
                //    Cep = "05086120",
                //    Numero = "777",
                //    Complemento = "Local de evento",
                //    TipoEndereco = new ViewModel.Endereco.TipoEnderecoViewModel() {Descricao = "eventos"},
                //    Latitude = "-23.5249463",
                //    Longitude = "-46.7234792",
                //    IdUsuarioLogado = 1,
                //    IdExterno = 5
                //}
            };

            foreach (var command in commands)
            {
                Thread.Sleep(1000);
                await mediator.Send(command);
            }
        }
    }
}
