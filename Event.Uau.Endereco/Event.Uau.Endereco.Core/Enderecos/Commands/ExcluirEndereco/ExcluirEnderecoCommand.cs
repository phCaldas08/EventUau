using System;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.ExcluirEndereco
{
    public class ExcluirEnderecoCommand : EventUauRequest<bool>
    {
        public int IdEndereco { get; set; }
        public int IdExterno { get; set; }
        public string TipoEndereco { get; set; }
    }
}
