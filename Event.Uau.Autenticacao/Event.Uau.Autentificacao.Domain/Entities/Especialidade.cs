using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Uau.Autenticacao.Domain.Entities
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual List<Parceiro> Parceiros { get; set; }

        public virtual List<ParceiroEspecialidade> ParceiroEspecialidades { get; set; }
    }
}
