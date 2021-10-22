using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.Proposta.Queries.BuscarPropostaPorId
{
    public class BuscaProspostaPorIdQueryHandler : IRequestHandler<BuscaProspostaPorIdQuery, FuncionarioEventoViewModel>
    {
        private readonly IMapper mapper;
        private readonly EventUauDbContext context;
        private readonly BuscaProspostaPorIdQueryValidator validator;
        private readonly IParceiroIntegracao parceiroIntegracao;

        public BuscaProspostaPorIdQueryHandler(EventUauDbContext context, IMapper mapper, IParceiroIntegracao parceiroIntegracao)
        {
            this.mapper = mapper;
            this.context = context;
            this.parceiroIntegracao = parceiroIntegracao;
            this.validator = new BuscaProspostaPorIdQueryValidator(context);
        }

        public async Task<FuncionarioEventoViewModel> Handle(BuscaProspostaPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var funcionarioEvento = await context.Funcionarios
                .Include(i => i.StatusContratacao)
                .FirstOrDefaultAsync(i => i.IdEvento == request.IdEvento && i.IdUsuario == request.IdUsuarioLogado);

            var funcionarioEventoViewModel = mapper.Map<FuncionarioEventoViewModel>(funcionarioEvento);

            var parceiro = await parceiroIntegracao.BuscarParceiroPorIdUsuario(request.IdUsuarioLogado, request.Token);

            funcionarioEventoViewModel.Funcionario = parceiro.Usuario;

            return funcionarioEventoViewModel;
        }
    }
}
