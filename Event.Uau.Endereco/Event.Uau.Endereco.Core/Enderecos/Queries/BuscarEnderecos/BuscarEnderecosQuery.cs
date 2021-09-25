using System;
using System.Collections.Generic;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Endereco.ViewModel.Endereco;

namespace Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecos
{
    public class BuscarEnderecosQuery : EventUauRequest<List<EnderecoViewModel>>
    {
        public int IdExterno { get; set; }

        public TipoEnderecoViewModel TipoEndereco { get; set; }
    }
}
