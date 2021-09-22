using System;
using System.Collections.Generic;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Comum.ViewModel;

namespace Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiros
{
    public static class BuscarParceirosQuerySettings
    {

        public static Dictionary<string, Func<Domain.Entities.Parceiro, object>> DicionarioOrdenacao => new Dictionary<string, Func<Domain.Entities.Parceiro, object>>
        {
            { "valorHora", parceiro => parceiro.ValorHora },
            { "nome", parceiro => parceiro.Usuario.Nome },
        };

    }
}
