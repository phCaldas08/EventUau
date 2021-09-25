using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Endereco.ViewModel.Endereco;

namespace Event.Uau.Endereco.Core.Enderecos.Queries.BuscarEnderecoPorId
{
    public class BuscarEnderecoPorIdQuery : EventUauRequest<EnderecoViewModel>
    {
        public int IdEndereco { get; set; }
        public int IdExterno { get; set; }
        public TipoEnderecoViewModel TipoEndereco { get; set; }
    }
}
