using System;
using System.Collections.Generic;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Autenticacao.Core.Usuario.Queries.BuscarUsuarios
{
    public class BuscarUsuariosQuery : EventUauPaginacaoRequest<ListaUsuarioViewModel>
    {
        public List<int> IdsUsuarios { get; set; }

        public string TextoProcurado { get; set; }
    }
}
