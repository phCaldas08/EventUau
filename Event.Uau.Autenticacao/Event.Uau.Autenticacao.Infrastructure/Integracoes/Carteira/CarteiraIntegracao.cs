using System;
using System.Threading.Tasks;
using Event.Uau.Autenticacao.Infrastructure.Integracoes.Interfaces;
using Flurl.Http;

namespace Event.Uau.Autenticacao.Infrastructure.Integracoes.Carteira
{
    public class CarteiraIntegracao : ICarteiraIntegracao
    {
        private readonly string url;

        public CarteiraIntegracao(string url)
        {
            this.url = url;
        }

        public async Task CadastrarCarteira(string token)
        {
            try
            {
                var result = await $"{url}/carteiras"
                    .WithOAuthBearerToken(token)
                    .GetAsync();
            }
            catch { }
        }
    }
}
