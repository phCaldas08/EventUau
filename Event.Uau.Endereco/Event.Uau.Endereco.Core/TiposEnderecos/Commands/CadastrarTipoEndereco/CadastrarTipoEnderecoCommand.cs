using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Endereco.ViewModel.Endereco;

namespace Event.Uau.Endereco.Core.TiposEnderecos.Commands.CadastrarTipoEndereco
{
    public class CadastrarTipoEnderecoCommand : EventUauRequest<TipoEnderecoViewModel>
    {
        public string Descricao { get; set; }
    }
}
