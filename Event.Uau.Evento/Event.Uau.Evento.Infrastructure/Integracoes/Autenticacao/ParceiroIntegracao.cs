using System;
using System.Threading.Tasks;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.ViewModel.Autenticacao;
using Flurl.Http;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Autenticacao
{
    public class ParceiroIntegracao : IParceiroIntegracao
    {
        private readonly string url;

        public ParceiroIntegracao(string url)
        {
            this.url = url;
        }

        public async Task<ParceiroViewModel> BuscarParceiroPorIdUsuario(int idUsuario, string token)
        {
            ParceiroViewModel parceiro = null;

            try
            {
                var result = await $"{url}/parceiros/{idUsuario}"
                    .WithOAuthBearerToken(token)
                    .GetAsync();

                if (result.StatusCode == 200)
                    parceiro = await result.GetJsonAsync<ParceiroViewModel>();

            }
            catch
            {
                parceiro = null;
            }

            return parceiro;
            
        }
    }
}
