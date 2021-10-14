using System;
using FluentValidation;

namespace Event.Uau.Autenticacao.Core.Usuario.Queries.BuscarUsuarios
{
    public class BuscarUsuariosQueryValidator : AbstractValidator<BuscarUsuariosQuery>
    {
        public BuscarUsuariosQueryValidator()
        {
            RuleFor(i => i.Indice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O indice deve ser maior ou igual a 0.");

            RuleFor(i => i.TamanhoPagina)
                .GreaterThan(0)
                .WithMessage("O tamanho da página deve ser maior que 0.");

        }
    }
}
