using System;
namespace Event.Uau.Endereco.ViewModel.Endereco
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Cep { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Logradouro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Bairro { get; set; }

        public TipoEnderecoViewModel TipoEndereco { get; set; }
    }
}
