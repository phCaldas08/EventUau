using System;
using System.Text.Json.Serialization;

namespace Event.Uau.Evento.ViewModel.Evento
{
    public class FuncionarioEventoViewModel
    {
        public decimal Salario { get; set; }

        public bool Contratado { get; set; }

        public Autenticacao.UsuarioViewModel Funcionario { get; set; }

        [JsonIgnore]
        public int IdUsuario { get; set; }

    }
}
