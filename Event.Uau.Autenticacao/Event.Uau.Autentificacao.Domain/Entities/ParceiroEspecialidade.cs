using System;
namespace Event.Uau.Autenticacao.Domain.Entities
{
    public class ParceiroEspecialidade
    {
        public int IdUsuario { get; set; }

        public int IdEspecialidade { get; set; }

        public virtual Especialidade Especialidade { get; set; }

        public virtual Parceiro Parceiro { get; set; }
    }
}
