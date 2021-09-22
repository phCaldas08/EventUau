using System;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiroPorIdUsuario
{
    public class BuscarParceiroPorIdUsuarioQuery : EventUauRequest<ParceiroViewModel>
    {
        public int IdUsuario { get; set; }
    }
}
