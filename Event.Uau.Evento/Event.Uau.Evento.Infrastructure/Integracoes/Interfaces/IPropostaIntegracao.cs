using System;
using System.Threading.Tasks;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Interfaces
{
    public interface IPropostaIntegracao
    {
        public Task<bool> EnviarPropostaParaCarteira(int idEvento, int idParceiro, decimal valor, string token); 
    }
}
