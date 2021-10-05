using System;
using System.Threading.Tasks;

namespace Event.Uau.Endereco.Infrastructure.Cep.Interfaces
{
    public interface ICepIntegracao
    {
        public Task<Models.Saida.EnderecoModel> BuscarEnderecoPorCep(string cep);
    }
}
