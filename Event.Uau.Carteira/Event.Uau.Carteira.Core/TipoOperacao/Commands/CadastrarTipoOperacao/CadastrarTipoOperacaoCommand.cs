using System;
using Event.Uau.Carteira.ViewModel.Carteira;
using MediatR;

namespace Event.Uau.Carteira.Core.TipoOperacao.Commands.CadastrarTipoOperacao
{
    public class CadastrarTipoOperacaoCommand : IRequest<TipoOperacaoViewModel>
    {
        public string Descricao { get; set; }

        public string Id { get; set; }

        public int Multplicador { get; set; }

        public bool EhDisponivel { get; set; }
    }
}
