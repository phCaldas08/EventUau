using System;
using System.Threading.Tasks;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Interfaces
{
    public interface IParceiroIntegracao
    {
        public Task<ViewModel.Autenticacao.ParceiroViewModel> BuscarParceiroPorIdUsuario(int idUsuario, string token);
    }
}
