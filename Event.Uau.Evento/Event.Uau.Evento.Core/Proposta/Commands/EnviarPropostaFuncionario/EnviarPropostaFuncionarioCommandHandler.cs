using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Core.Proposta.Queries.BuscarPropostaPorId;
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
        private readonly IPropostaIntegracao propostaIntegracao;
        private readonly IMediator mediator;
        private readonly EnviarPropostaFuncionarioCommandValidator validator;

        public EnviarPropostaFuncionarioCommandHandler(Persistence.EventUauDbContext context, IMapper mapper, IParceiroIntegracao parceiroIntegracao, IPropostaIntegracao propostaIntegracao, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.propostaIntegracao = propostaIntegracao;
            this.mediator = mediator;
            this.validator = new EnviarPropostaFuncionarioCommandValidator(context, parceiroIntegracao);
        }

        public async Task<FuncionarioEventoViewModel> Handle(EnviarPropostaFuncionarioCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var funcionario = mapper.Map<Domain.Entities.FuncionarioEvento>(request);

            await context.Funcionarios.AddAsync(funcionario, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            try
            {
                await propostaIntegracao.EnviarPropostaParaCarteira(request.IdEvento, request.Usuario.Id, request.Salario, request.Token);

                var query = new BuscaProspostaPorIdQuery { IdEvento = request.IdEvento, IdUsuarioLogado = request.Usuario.Id, Token = request.Token };

                return  await mediator.Send(query);
            }
            catch
            {
                context.Funcionarios.Remove(funcionario);
                await context.SaveChangesAsync();

                throw;
            }
        }
    }
}
