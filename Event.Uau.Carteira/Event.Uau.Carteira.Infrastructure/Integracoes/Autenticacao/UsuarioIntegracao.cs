using System;
using System.Threading.Tasks;
using Flurl.Http;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;

namespace Event.Uau.Carteira.Infrastructure.Integracoes.Autenticacao
{
    public class UsuarioIntegracao : IUsuarioIntegracao
    {
        private readonly string url;

        public UsuarioIntegracao(string url)
        {
            this.url = url;
        }

        public async Task<bool> VerificarIdExistente(int idUsuario, string token)
        {
            var requestResult = await $"{url}/usuario/{idUsuario}"
                .WithOAuthBearerToken(token)
                .GetAsync();

            return requestResult.StatusCode == 200;
        }
    }
}
