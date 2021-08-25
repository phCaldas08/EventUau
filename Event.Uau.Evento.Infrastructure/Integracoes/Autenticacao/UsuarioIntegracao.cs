using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Evento.ViewModel.Autenticacao;
using Flurl;
using Flurl.Http;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Autenticacao
{
    public class UsuarioIntegracao : Interfaces.IUsuarioIntegracao
    {
        public async Task<UsuarioViewModel> BuscaUsuarioPorId(int idUsuario, string token)
        {
            UsuarioViewModel usuario = null;

            var flurlResult = await $"https://localhost:6001/api/usuario/{idUsuario}"
                .WithOAuthBearerToken(token)
                .GetAsync();


            if(flurlResult.StatusCode == 200)
                usuario = await flurlResult.GetJsonAsync<UsuarioViewModel>();

            return usuario;
        }

        public async Task<IEnumerable<UsuarioViewModel>> BuscaUsuariosPorIds(IEnumerable<int> idsUsuarios, string token)
        {
            throw new NotImplementedException();
        }
    }
}
