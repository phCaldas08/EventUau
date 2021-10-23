using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Core.Evento.Commands.AlterarStatusEvento;
using Event.Uau.Evento.Core.Proposta.Queries.BuscarPropostaPorId;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Proposta.Commands.EnviarPropostaFuncionario
{
    public class EnviarPropostaFuncionarioCommandHandler : IRequestHandler<EnviarPropostaFuncionarioCommand, FuncionarioEventoViewModel>
    {
        private Persistence.EventUauDbContext context;
        private IMapper mapper;
        private readonly IPropostaIntegracao propostaIntegracao;
        private readonly IMediator mediator;
        private readonly EnviarPropostaFuncionarioCommandValidator validator;

        public EnviarPropostaFuncionarioCommandHandler(Persistence.EventUauDbContext context, IMapper mapper, IParceiroIntegracao parceiroIntegracao, IPropostaIntegracao propostaIntegracao, IEspecialidadeIntegracao especialidadeIntegracao, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.propostaIntegracao = propostaIntegracao;
            this.mediator = mediator;
            this.validator = new EnviarPropostaFuncionarioCommandValidator(context, parceiroIntegracao, especialidadeIntegracao);
        }

        public async Task<FuncionarioEventoViewModel> Handle(EnviarPropostaFuncionarioCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var funcionario = mapper.Map<Domain.Entities.FuncionarioEvento>(request);

            await RemoverPropostaRecusadasNoEvento(request);

            await context.Funcionarios.AddAsync(funcionario, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            try
            {
                await propostaIntegracao.EnviarPropostaParaCarteira(request.IdEvento, request.Usuario.Id, request.Salario, request.Token);   
            }
            catch
            {
                context.Funcionarios.Remove(funcionario);
                await context.SaveChangesAsync();

                throw;
            }

            await AlterarStatusParaContratando(request);

            var query = new BuscaProspostaPorIdQuery
            {
                IdEvento = request.IdEvento,
                IdUsuarioLogado = request.Usuario.Id,
                Token = request.Token
            };

            return await mediator.Send(query);
        }

        private async Task RemoverPropostaRecusadasNoEvento(EnviarPropostaFuncionarioCommand request)
        {
            if (await context.Funcionarios.AnyAsync(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.Usuario.Id && i.IdStatusContratacao.Equals("REC", StringComparison.CurrentCultureIgnoreCase)))
            {
                var funcionarios = await context.Funcionarios.Where(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.Usuario.Id && i.IdStatusContratacao.Equals("REC", StringComparison.CurrentCultureIgnoreCase))
                    .ToListAsync();

                context.Funcionarios.RemoveRange(funcionarios);
                await context.SaveChangesAsync();
            }
        }


        private async Task AlterarStatusParaContratando(EnviarPropostaFuncionarioCommand request)
        {
            var atualizarCommand = new AlterarStatusEventoCommand
            {
                IdEvento = request.IdEvento,
                IdUsuarioLogado = request.IdUsuarioLogado,
                Token = request.Token,
                Status = Domain.Enums.StatusEnum.CONTRATANDO
            };

            await mediator.Send(atualizarCommand);
        }
    }
}
