using System;
using Event.Uau.Comum.Util.Mediator;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Especialidade.Queries.BuscaEspecialidadePorId
{
    public class BuscaEspecialidadePorIdQuery : EventUauRequest<ViewModel.Autenticacao.EspecialidadeViewModel>
    {
        public int IdEspecialidade { get; set; }
    }
}