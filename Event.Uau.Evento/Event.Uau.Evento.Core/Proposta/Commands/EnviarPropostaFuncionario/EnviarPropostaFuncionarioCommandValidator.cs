using System;
using System.Linq;
using System.Threading.Tasks;
using Event.Uau.Evento.Infrastructure.Integracoes.Interfaces;
using Event.Uau.Evento.Persistence;
using FluentValidation;

namespace Event.Uau.Evento.Core.Proposta.Commands.EnviarPropostaFuncionario
{
    public class EnviarPropostaFuncionarioCommandValidator : AbstractValidator<EnviarPropostaFuncionarioCommand>
    {
        public EnviarPropostaFuncionarioCommandValidator(EventUauDbContext context, IParceiroIntegracao parceiroIntegracao)
        {
            RuleFor(i => new { i.Usuario.Id, i.Token })
                .MustAsync((obj, c) => Task.Run(async () => (await parceiroIntegracao.BuscarParceiroPorIdUsuario(obj.Id, obj.Token)) != null))
                .WithMessage("Parceiro não encontrado.");

            RuleFor(i => i.Salario)
                .InclusiveBetween(10, 10000)
                .WithMessage("O salário deve ser entre R$10 e R$10.000");

            RuleFor(i => new { i.IdEvento, i.IdUsuarioLogado })
                .Must(obj => context.Eventos.Any(i => i.Id == obj.IdEvento && i.IdUsuario == obj.IdUsuarioLogado && i.DataInicio.AddHours(-2) > DateTime.Now))
                .WithMessage("Nenhum evento encontrado.");

            RuleFor(i => new { i.IdEvento, i.Usuario.Id })
                .Must(obj => {
                    var evento = context.Eventos.FirstOrDefault(i => i.Id == obj.IdEvento);

                    return !context.Funcionarios.Any(i => i.IdUsuario == obj.Id
                                                        && i.StatusContratacao.Id.Equals("AC", StringComparison.CurrentCultureIgnoreCase)
                                                        && i.Evento.DataInicio.AddHours(-2) < evento.DataInicio
                                                        && i.Evento.DataTermino.AddHours(2) > evento.DataInicio);
                })
                .When(obj => context.Eventos.Any(i => i.Id == obj.IdEvento && i.IdUsuario == obj.IdUsuarioLogado && i.DataInicio.AddHours(-2) > DateTime.Now))
                .WithMessage("O parceiro já foi contratado para outra festa neste período.");

            RuleFor(i => new { i.IdEvento, i.Usuario.Id })
                .Must(obj => !context.Funcionarios.Any(i => i.IdEvento == obj.IdEvento && i.IdUsuario == obj.Id))
                .WithMessage("Já existe uma proposta para este evento.");

        }
    }
}
