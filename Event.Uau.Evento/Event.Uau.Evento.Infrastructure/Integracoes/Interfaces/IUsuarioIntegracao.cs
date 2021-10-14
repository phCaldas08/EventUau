using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Evento.ViewModel.Autenticacao;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Interfaces
{
    public interface IUsuarioIntegracao
    {
        public Task<UsuarioViewModel> BuscaUsuarioPorId(int idUsuario, string Token);

        public Task<ListaUsuarioViewModel> BuscaUsuariosPorIds(IEnumerable<int> idsUsuarios, string token);

    }
}
