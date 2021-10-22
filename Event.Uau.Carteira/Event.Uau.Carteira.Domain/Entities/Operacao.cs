using System;
namespace Event.Uau.Carteira.Domain.Entities
{
    public class Operacao
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public DateTime DataHora { get; set; }

        public string IdTipoOperacao { get; set; }

        public decimal Valor { get; set; }

        public virtual Carteira Carteira { get; set; }

        public virtual TipoOperacao TipoOperacao { get; set; }

        public virtual OperacaoEvento OperacaoEventoRecebedor { get; set; }

        public virtual OperacaoEvento OperacaoEventoPagador { get; set; }
    }
}
