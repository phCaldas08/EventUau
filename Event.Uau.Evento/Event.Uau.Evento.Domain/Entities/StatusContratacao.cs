using System;
using System.Collections.Generic;

namespace Event.Uau.Evento.Domain.Entities
{
    public class StatusContratacao
    {
        public string Id { get; set; }

        public string Descricao { get; set; }

        public bool EhRecusada { get; set; }

        public virtual List<FuncionarioEvento> Funcionarios { get; set; }
    }
}
