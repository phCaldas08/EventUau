using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Core.ViewModel;
using Event.Uau.Autenticacao.Persistence;
using FluentValidation;
using MediatR;

namespace Event.Uau.Autenticacao.Core.Authentication.User.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, ViewModel.UserViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly CreateCommandValidator validation;

        public CreateCommandHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validation = new CreateCommandValidator(context);
        }

        public async Task<UserViewModel> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            validation.ValidateAndThrow(request);

            var user = mapper.Map<Domain.Entities.User>(request);

            await context.Users.AddAsync(user);

            await context.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<UserViewModel>(user);

            return result;
        }
    }
}
