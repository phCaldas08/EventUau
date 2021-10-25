using System;
using System.Threading.Tasks;

namespace Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces
{
    public interface IEventoIntegracao
    {
        public Task<bool> VerificarIdExistente(int idEvento, string token);

        public Task<bool> VerificarEventoFinalizadoExistente(int idEvento, string token);

        public Task<bool> VerificarEventoCanceladoExistente(int idEvento, string token);
    }
}
