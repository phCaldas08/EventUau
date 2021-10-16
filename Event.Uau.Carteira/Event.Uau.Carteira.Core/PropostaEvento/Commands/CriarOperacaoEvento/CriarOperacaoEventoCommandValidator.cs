using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Carteira.Persistence;
using Event.Uau.Carteira.ViewModel.Carteira;
using Event.Uau.Comum.Util.Mediator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.ProspostaEvento.Commands.CriarOperacaoEvento
{
    public class CriarOperacaoEventoCommandValidator : AbstractValidator<CriarOperacaoEventoCommand>
    {
        public CriarOperacaoEventoCommandValidator(EventUauDbContext context, IMapper mapper, IUsuarioIntegracao usuarioIntegracao, IEventoIntegracao eventoIntegracao)
        {
            RuleFor(i => new { i.IdFuncionario, i.Token })
                .MustAsync((obj, c) => usuarioIntegracao.VerificarIdExistente(obj.IdFuncionario, obj.Token))
                .WithMessage("Usuário não encontrado.");

            RuleFor(i => new { i.IdEvento, i.Token })
                .MustAsync((obj, c) => eventoIntegracao.VerificarIdExistente(obj.IdEvento, obj.Token))
                .WithMessage("Evento não encontrado.");

            RuleFor(i => i)
                .Must(request => !context.OperacoesEventos.Any(i => i.IdEvento == request.IdEvento && i.IdRecebedor == request.IdFuncionario))
                .WithMessage("Proposta já enviada para este colaborador.");

            RuleFor(i => i.Valor)
                .GreaterThan(0)
                .WithMessage("O valor da proposta precisa ser maior que zero.");

            RuleFor(request => request)
                .MustAsync((request, c) => SaldoDisponivelAsync(request, context, mapper))
                .WithMessage("Saldo insuficiente para essa operação.");

        }

        private async Task<bool> SaldoDisponivelAsync(CriarOperacaoEventoCommand request, Persistence.EventUauDbContext context, IMapper mapper)
        {
            var carteira = await context.Carteiras.FirstOrDefaultAsync(i => i.IdUsuario == request.IdUsuarioLogado);
            var carteiraViewModel = mapper.Map<CarteiraViewModel>(carteira);

            return carteiraViewModel.ValorDisponivel - request.Valor >= 0;
        }
    }
}
