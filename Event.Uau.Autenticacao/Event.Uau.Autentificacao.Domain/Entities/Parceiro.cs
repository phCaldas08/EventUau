using System;
using System.Collections.Generic;

namespace Event.Uau.Autenticacao.Domain.Entities
{
    public class Parceiro
    {
        public int IdUsuario { get; set; }

        public decimal ValorHora { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual List<Especialidade> Especialidades { get; set; }

        public virtual List<ParceiroEspecialidade> ParceiroEspecialidades { get; set; }
    }
}
