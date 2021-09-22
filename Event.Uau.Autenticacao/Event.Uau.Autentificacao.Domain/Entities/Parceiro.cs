using System;
namespace Event.Uau.Autenticacao.Domain.Entities
{
    public class Parceiro
    {
        public int IdUsuario { get; set; }

        public decimal ValorHora { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
