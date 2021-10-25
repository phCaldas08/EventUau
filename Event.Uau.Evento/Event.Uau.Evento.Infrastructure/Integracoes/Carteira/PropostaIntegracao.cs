using System;
using System.Threading.Tasks;
using Flurl.Http;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Comum.Util.Exceptions;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Carteira
{
    public class PropostaIntegracao : IPropostaIntegracao
    {
        private readonly string url;

        public PropostaIntegracao(string url)
        {
            this.url = url;
        }

        public async Task<bool> AceitarPropostaEvento(int idEvento, string token)
        {
            var body = new
            {
            };

            var requestResult = await $"{url}/eventos/{idEvento}/propostas/aceitar"
                .WithOAuthBearerToken(token)
                .PutJsonAsync(body);

            return requestResult.StatusCode switch
            {
                200 => true,
                400 => throw await requestResult.GetJsonAsync<EventUauBadRequestException>(),
                _ => throw new Exception("Erro interno ao aceitar proposta na carteira."),
            };
        }

        public async Task<bool> CancelarEvento(int idEvento, string token)
        {
            var requestResult = await $"{url}/eventos/{idEvento}/propostas/cancelar"
                   .WithOAuthBearerToken(token)
                   .DeleteAsync();

            return requestResult.StatusCode switch
            {
                200 => true,
                400 => throw await requestResult.GetJsonAsync<EventUauBadRequestException>(),
                _ => throw new Exception("Erro interno ao cancelar propostas na carteira."),
            };
        }

        public async Task<bool> EnviarPropostaParaCarteira(int idEvento, int idParceiro, decimal valor, string token)
        {
            var body = new
            {
                idFuncionario = idParceiro,
                valor,
            };

            var requestResult = await $"{url}/eventos/{idEvento}/propostas"
                .WithOAuthBearerToken(token)
                .PostJsonAsync(body);

            var exception = requestResult.ResponseMessage;

            return requestResult.StatusCode switch
            {
                200 => true,
                400 => throw await requestResult.GetJsonAsync<EventUauBadRequestException>(),
                _ => throw new Exception("Erro interno ao persistir proposta na carteira."),
            };
        }

        public async Task<bool> FinalizarPropostasEvento(int idEvento, string token)
        {
            var body = new
            {
            };

            var requestResult = await $"{url}/eventos/{idEvento}/propostas/finalizar"
                .WithOAuthBearerToken(token)
                .PutJsonAsync(body);

            return requestResult.StatusCode switch
            {
                200 => true,
                400 => throw await requestResult.GetJsonAsync<EventUauBadRequestException>(),
                _ => throw new Exception("Erro interno ao persistir proposta na carteira."),
            };
        }

        public async Task<bool> RecusarPropostaEvento(int idEvento, string token)
        {
            var requestResult = await $"{url}/eventos/{idEvento}/propostas"
                .WithOAuthBearerToken(token)
                .DeleteAsync();

            return requestResult.StatusCode switch
            {
                200 => true,
                400 => throw await requestResult.GetJsonAsync<EventUauBadRequestException>(),
                _ => throw new Exception("Erro interno ao recusar proposta na carteira."),
            };
        }
    }
}
