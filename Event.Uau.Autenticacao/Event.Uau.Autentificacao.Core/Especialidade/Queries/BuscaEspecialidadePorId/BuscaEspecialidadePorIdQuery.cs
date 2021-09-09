using System;
using Event.Uau.Comum.Util.Mediator;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Especialidade.Queries.BuscaEspecialidadePorId
{
    public class BuscaEspecialidadePorIdQuery : EventUauRequest<ViewModel.Especialidade.EspecialidadeViewModel>
    {
        public int IdEspecialidade { get; set; }
    }
}