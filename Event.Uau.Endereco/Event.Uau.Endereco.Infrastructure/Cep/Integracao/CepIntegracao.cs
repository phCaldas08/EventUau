using System;
using System.Threading.Tasks;
using Event.Uau.Endereco.Infrastructure.Cep.Interfaces;
using Flurl.Http;

namespace Event.Uau.Endereco.Infrastructure.Cep.Integracao
{
    public class CepIntegracao : ICepIntegracao
    {
        private readonly string urlApi;

        public CepIntegracao(string urlApi)
        {
            this.urlApi = urlApi;
        }

        public async Task<Models.Saida.EnderecoModel> BuscarEnderecoPorCep(string cep)
        {
            var result = await $"{this.urlApi}{cep}.json".GetAsync();

            if(result.StatusCode == 200)
            {
                dynamic endereco = await result.GetJsonAsync();

                if (endereco.ok)
                {
                    var enderecoModel = new Models.Saida.EnderecoModel
                    {
                        Bairro = endereco.district,
                        Cidade = endereco.city,
                        Endereco = endereco.address,
                        Estado = endereco.state
                    };

                    return enderecoModel;
                }
            }

            return null;
        }
    }
}
