using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Evento.ViewModel.Autenticacao;
using Flurl.Http;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Autenticacao
{
    public class EspecialidadeIntegracao : Interfaces.IEspecialidadeIntegracao
    {
        private readonly string url;

        public EspecialidadeIntegracao(string url)
        {
            this.url = url;
        }

        public async Task<EspecialidadeViewModel> BuscarEspecialidadePorId(int IdEspecialidade, string token)
        {
            EspecialidadeViewModel especialidade = null;

            try
            {
                var result = await $"{url}/especialidades/{IdEspecialidade}"
                    .WithOAuthBearerToken(token)
                    .GetAsync();

                if (result.StatusCode == 200)
                    especialidade = await result.GetJsonAsync<EspecialidadeViewModel>();

            }
            catch
            {
                especialidade = null;
            }

            return especialidade;
        }

        public async Task<List<EspecialidadeViewModel>> BuscarEspecialidades(string token)
        {
            List<EspecialidadeViewModel> especialidades = null;

            try
            {
                var result = await $"{url}/especialidades"
                    .WithOAuthBearerToken(token)
                    .GetAsync();

                if (result.StatusCode == 200)
                    especialidades = await result.GetJsonAsync<List<EspecialidadeViewModel>>();

            }
            catch
            {
                especialidades = null;
            }

            return especialidades;
        }
    }
}
