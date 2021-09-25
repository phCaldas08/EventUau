using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Endereco.Core.TiposEnderecos.Commands.CadastrarTipoEndereco;
using MediatR;

namespace Event.Uau.Endereco.Core.Helpers.DadosFakes
{
    public static class DadosTipoEndereco
    {
        public static async Task CarregarDadosTipoEndereco(this IMediator mediator)
        {
            var commands = new List<CadastrarTipoEnderecoCommand>
            {
                new CadastrarTipoEnderecoCommand
                {
                    Descricao = "Usuarios"
                },
                new CadastrarTipoEnderecoCommand
                {
                    Descricao = "Eventos"
                }
            };

            foreach (var command in commands)
                await mediator.Send(command);
        }
    }
}
