using System;
using System.Threading.Tasks;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Interfaces
{
    public interface IPropostaIntegracao
    {
        public Task<bool> EnviarPropostaParaCarteira(int idEvento, int idParceiro, decimal valor, string token);

        public Task<bool> FinalizarPropostasEvento(int idEvento, string token);

        public Task<bool> AceitarPropostaEvento(int idEvento, string token);
    }
}
