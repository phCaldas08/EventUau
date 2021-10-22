using System;
namespace Event.Uau.Evento.ViewModel.Autenticacao
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal ValorPorHora { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Idade {
            get
            {
                var dataIniversario = DateTime.Today - DataNascimento;

                int idade = Convert.ToInt32(dataIniversario.TotalDays / 365);

                return idade;
            }
        }
    }
}
