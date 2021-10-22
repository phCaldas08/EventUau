using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Event.Uau.Endereco.Infrastructure.Cep.Interfaces;
using Flurl.Http;
using Newtonsoft.Json;

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
            var tentativas = 5;

            for (int i = 0; i < tentativas; i++)
            {
                var result = await $"{this.urlApi}{cep}.json".GetAsync();

                if (result.StatusCode == 200)
                {
                    var httpClient = new HttpClient();
                    var content = await httpClient.GetStringAsync($"{this.urlApi}{cep}.json");
                    var endereco = JsonConvert.DeserializeObject<Models.Retorno.EnderecoRetornoModel>(content);

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

                //espera 10 segundos até a próxima tentativa
                Thread.Sleep(10000);
            }

            //var result = await $"{this.urlApi}{cep}.json".GetAsync();

            //if(result.StatusCode == 200)
            //{
            //    dynamic endereco = await result.GetJsonAsync();

            //    if (endereco.ok)
            //    {
            //        var enderecoModel = new Models.Saida.EnderecoModel
            //        {
            //            Bairro = endereco.district,
            //            Cidade = endereco.city,
            //            Endereco = endereco.address,
            //            Estado = endereco.state
            //        };

            //        return enderecoModel;
            //    }
            //}

            return null;
        }
    }
}
