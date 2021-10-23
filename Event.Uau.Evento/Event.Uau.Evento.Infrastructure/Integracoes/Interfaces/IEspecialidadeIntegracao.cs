using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event.Uau.Evento.ViewModel.Autenticacao;

namespace Event.Uau.Evento.Infrastructure.Integracoes.Interfaces
{
    public interface IEspecialidadeIntegracao
    {
        public Task<EspecialidadeViewModel> BuscarEspecialidadePorId(int IdEspecialidade, string token);

        public Task<List<EspecialidadeViewModel>> BuscarEspecialidades(string token);
    }
}
