using System;
using System.Threading.Tasks;
using Flurl.Http;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;

namespace Event.Uau.Carteira.Infrastructure.Integracoes.Evento
{
    public class EventoIntegracao : IEventoIntegracao
    {
        private readonly string url;

        public EventoIntegracao(string url)
        {
            this.url = url;
        }

        public async Task<bool> VerificarEventoCanceladoExistente(int idEvento, string token)
        {
            var requestResult = await $"{url}/eventos/{idEvento}"
                .WithOAuthBearerToken(token)
                .GetAsync();

            if (requestResult.StatusCode == 200)
            {
                dynamic json = await requestResult.GetJsonAsync();

                return json.status.id == "CANCELADO";
            }
            else
                return false;
        }

        public async Task<bool> VerificarEventoFinalizadoExistente(int idEvento, string token)
        {
            var requestResult = await $"{url}/eventos/{idEvento}"
                .WithOAuthBearerToken(token)
                .GetAsync();

            if (requestResult.StatusCode == 200)
            {
                dynamic json = await requestResult.GetJsonAsync();

                return json.status.id == "FINALIZADO";
            }
            else
                return false;
        }

        public async Task<bool> VerificarIdExistente(int idEvento, string token)
        {
            var requestResult = await $"{url}/eventos/{idEvento}"
                .WithOAuthBearerToken(token)
                .GetAsync();

            return requestResult.StatusCode == 200;
        }
    }
}
