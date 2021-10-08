using System;
using System.Collections.Generic;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Autenticacao.Core.Especialidade.Queries.BuscarEspecialidades
{
    public class BuscarEspecialidadesQuery : EventUauRequest<List<EspecialidadeViewModel>>
    {
    }
}
