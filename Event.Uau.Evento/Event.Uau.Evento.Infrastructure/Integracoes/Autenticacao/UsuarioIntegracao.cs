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
        private readonly string url;

        public UsuarioIntegracao(string url)
        {
            this.url = url;
        }

        public async Task<UsuarioViewModel> BuscaUsuarioPorId(int idUsuario, string token)
        {
            UsuarioViewModel usuario = null;

            try
            {
                var flurlResult = await $"{url}/usuario/{idUsuario}"
                    .WithOAuthBearerToken(token)
                    .GetAsync();


                if (flurlResult.StatusCode == 200)
                    usuario = await flurlResult.GetJsonAsync<UsuarioViewModel>();
            }
            catch
            {
                usuario = null;
            }

            return usuario;
        }

        public async Task<IEnumerable<UsuarioViewModel>> BuscaUsuariosPorIds(IEnumerable<int> idsUsuarios, string token)
        {
            throw new NotImplementedException();
        }
    }
}
