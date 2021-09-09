using System;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Especialidade.Commands.CadastrarEspecialidade
{
    public class CadastrarEspecialidadeCommand : IRequest<ViewModel.Especialidade.EspecialidadeViewModel>
    {
        public string Descricao { get; set; }
    }
}
