using System;
namespace Event.Uau.Carteira.Domain.Entities
{
    public class OperacaoEvento
    {
        public int IdEvento { get; set; }

        public int IdPagador { get; set; }

        public int IdRecebedor { get; set; }

        public virtual Operacao Pagamento { get; set; }

        public virtual Operacao Recebimento { get; set; }
    }
}
