using System;
using System.Text.Json.Serialization;

namespace Event.Uau.Evento.ViewModel.Evento
{
    public class FuncionarioEventoViewModel
    {
        public decimal Salario { get; set; }

        public Autenticacao.UsuarioViewModel Funcionario { get; set; }

        [JsonIgnore]
        public int IdUsuario { get; set; }

        public StatusContratacaoViewModel StatusContratacao { get; set; }

        [JsonIgnore]
        public int IdEspecialidade { get; set; }

        public Autenticacao.EspecialidadeViewModel Especialidade { get; set; }

    }
}
