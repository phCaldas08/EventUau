using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Carteira.ViewModel.Carteira;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Carteira.Core.Operacao.Commands.RealizarOperacao
{
    public class RealizarOperacaoCommandValidator : AbstractValidator<RealizarOperacaoCommand>
    {
        public RealizarOperacaoCommandValidator(Persistence.EventUauDbContext context, IMapper mapper)
        {
            RuleFor(i => i.TipoOperacao)
                .Must(tipoOperacao => context.TiposOperacoes.Any(i => i.EhDisponivel && i.Descricao.Equals(tipoOperacao, StringComparison.CurrentCultureIgnoreCase)))
                .WithMessage("Tipo de operação não suportado.");

            RuleFor(i => i.Valor)
                .GreaterThan(0)
                .WithMessage("O valor da operação deve ser maior que 0.");

            RuleFor(request => request)
                .MustAsync((request, c) => SaldoDisponivelAsync(request, context, mapper))
                .WhenAsync((i, c) => context.TiposOperacoes.AnyAsync(j => j.Descricao.Equals(i.TipoOperacao, StringComparison.CurrentCultureIgnoreCase) && j.Multplicador < 0))
                .WithMessage("Saldo insuficiente para essa operação.");
        }

        private async Task<bool> SaldoDisponivelAsync(RealizarOperacaoCommand request, Persistence.EventUauDbContext context, IMapper mapper)
        {
            var carteira = await context.Carteiras.FirstOrDefaultAsync(i => i.IdUsuario == request.IdUsuarioLogado);
            var carteiraViewModel = mapper.Map<CarteiraViewModel>(carteira);

            return carteiraViewModel.ValorDisponivel - request.Valor >= 0;
        }


    }
}
