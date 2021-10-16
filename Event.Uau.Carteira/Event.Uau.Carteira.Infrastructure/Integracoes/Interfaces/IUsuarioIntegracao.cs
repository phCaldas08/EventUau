using System;
using System.Threading.Tasks;

namespace Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces
{
    public interface IUsuarioIntegracao
    {
        public Task<bool> VerificarIdExistente(int idUsuario, string token);
    }
}
