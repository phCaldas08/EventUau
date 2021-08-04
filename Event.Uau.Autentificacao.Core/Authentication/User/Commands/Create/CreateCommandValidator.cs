using System;
namespace Event.Uau.Autenticacao.Core.Authentication.User.Commands.Create
{
    public class CreateCommandValidator : FluentValidation.AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator(Persistence.EventUauDbContext context)
        {

        }
    }
}
