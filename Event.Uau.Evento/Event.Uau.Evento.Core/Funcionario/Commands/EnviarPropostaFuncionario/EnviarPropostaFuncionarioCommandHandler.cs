using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Infrastructure.Integracoes.Autenticacao;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.ViewModel.Evento;
using MediatR;

namespace Event.Uau.Evento.Core.Funcionario.Commands.EnviarPropostaFuncionario
{
    public class EnviarPropostaFuncionarioCommandHandler : IRequestHandler<EnviarPropostaFuncionarioCommand, FuncionarioEventoViewModel>
    {
        private Persistence.EventUauDbContext context;
        private IMapper mapper;
        private IUsuarioIntegracao usuarioIntegracao;

        public EnviarPropostaFuncionarioCommandHandler(Persistence.EventUauDbContext context, IMapper mapper, IUsuarioIntegracao usuarioIntegracao)
        {
            this.context = context;
            this.mapper = mapper;
            this.usuarioIntegracao = usuarioIntegracao;
        }

        public async Task<FuncionarioEventoViewModel> Handle(EnviarPropostaFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var funcionario = mapper.Map<Domain.Entities.FuncionarioEvento>(request);

            await context.Funcionarios.AddAsync(funcionario, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            var funcionarioViewModel = mapper.Map<FuncionarioEventoViewModel>(funcionario);

            funcionarioViewModel.Funcionario = await usuarioIntegracao.BuscaUsuarioPorId(request.Usuario.Id, request.Token);

            return funcionarioViewModel;
        }
    }
}
