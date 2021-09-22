using System;
using System.Collections.Generic;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using Event.Uau.Comum.Util.Mediator;

namespace Event.Uau.Autenticacao.Core.Parceiro.Commands.CadastrarParceiro
{
    public class CadastrarParceiroCommand : EventUauRequest<ParceiroViewModel>
    {

        public List<EspecialidadeViewModel> Especialidades { get; set; }

        public decimal ValorHora { get; set; }

    }
}
