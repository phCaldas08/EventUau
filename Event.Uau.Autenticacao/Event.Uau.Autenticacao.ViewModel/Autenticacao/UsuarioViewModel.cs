using System;
namespace Event.Uau.Autenticacao.ViewModel.Autenticacao
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string SobreMim { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Status { get; set; }

    }
}
