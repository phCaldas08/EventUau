using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Interfaces
{
    public interface IUsuarioIntegracao
    {
        public Task<ViewModel.Autenticacao.UsuarioViewModel> BuscaUsuarioPorId(int idUsuario, string Token);

        public Task<IEnumerable<ViewModel.Autenticacao.UsuarioViewModel>> BuscaUsuariosPorIds(IEnumerable<int> idsUsuarios, string token);

    }
}
