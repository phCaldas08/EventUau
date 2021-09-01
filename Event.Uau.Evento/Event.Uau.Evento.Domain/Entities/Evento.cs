using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Event.Uau.Evento.Domain.Entities
{
    public class Evento
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public int Numero { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public decimal DuracaoMinima { get; set; }

        public decimal DuracaoMaxima { get; set; }

        public string Observacao { get; set; }

        public bool EstaVisivel { get; set; }

        public int IdStatus { get; set; }

        public virtual Status Status { get; set; }

        public virtual StatusContratacao StatusContratacao { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual List<FuncionarioEvento> Funcionarios { get; set; }

        public virtual List<Curtida> Curtidas { get; set; }
        
    }
}
