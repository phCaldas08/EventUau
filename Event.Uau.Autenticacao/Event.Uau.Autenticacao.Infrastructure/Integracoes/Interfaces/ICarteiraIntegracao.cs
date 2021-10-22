using System;
using System.Threading.Tasks;

namespace Event.Uau.Autenticacao.Infrastructure.Integracoes.Interfaces
{
    public interface ICarteiraIntegracao
    {
        public Task CadastrarCarteira(string token);
    }
}
