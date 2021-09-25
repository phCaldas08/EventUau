using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Endereco.ViewModel.Endereco;

namespace Event.Uau.Endereco.Core.TiposEnderecos.Queries.BuscarTipoEnderecoPorId
{
    public class BuscarTipoEnderecoPorIdQuery : EventUauRequest<TipoEnderecoViewModel>
    {
        public int IdTipoEndereco { get; set; }
    }
}
