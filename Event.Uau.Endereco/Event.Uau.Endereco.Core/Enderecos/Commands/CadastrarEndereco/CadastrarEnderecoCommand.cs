using System;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Endereco.ViewModel.Endereco;

namespace Event.Uau.Endereco.Core.Enderecos.Commands.CadastrarEndereco
{
    public class CadastrarEnderecoCommand : EventUauRequest<EnderecoViewModel>
    {
        public int IdExterno { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Cep { get; set; }

        public string Nome { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public TipoEnderecoViewModel TipoEndereco { get; set; }
    }
}
