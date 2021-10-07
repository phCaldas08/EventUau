using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Infrastructure.Integracoes.Autenticacao;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;

namespace Event.Uau.Evento.Core.Proposta.Commands.EnviarPropostaFuncionario
{
    public class EnviarPropostaFuncionarioCommandHandler : IRequestHandler<EnviarPropostaFuncionarioCommand, FuncionarioEventoViewModel>
    {
        private Persistence.EventUauDbContext context;
        private IMapper mapper;
        private IParceiroIntegracao parceiroIntegracao;
        private readonly EnviarPropostaFuncionarioCommandValidator validator;

        public EnviarPropostaFuncionarioCommandHandler(Persistence.EventUauDbContext context, IMapper mapper, IParceiroIntegracao parceiroIntegracao)
        {
            this.context = context;
            this.mapper = mapper;
            this.parceiroIntegracao = parceiroIntegracao;
            this.validator = new EnviarPropostaFuncionarioCommandValidator(context, parceiroIntegracao);
        }

        public async Task<FuncionarioEventoViewModel> Handle(EnviarPropostaFuncionarioCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var funcionario = mapper.Map<Domain.Entities.FuncionarioEvento>(request);

            await context.Funcionarios.AddAsync(funcionario, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            var funcionarioViewModel = mapper.Map<FuncionarioEventoViewModel>(funcionario);

            var parceiro = await parceiroIntegracao.BuscarParceiroPorIdUsuario(request.Usuario.Id, request.Token);

            funcionarioViewModel.Funcionario = parceiro.Usuario;

            return funcionarioViewModel;
        }
    }
}
