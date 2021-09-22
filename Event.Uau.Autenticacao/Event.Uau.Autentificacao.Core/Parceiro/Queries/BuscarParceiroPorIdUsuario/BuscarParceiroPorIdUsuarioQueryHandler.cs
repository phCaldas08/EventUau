using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiroPorIdUsuario
{
    public class BuscarParceiroPorIdUsuarioQueryHandler : IRequestHandler<BuscarParceiroPorIdUsuarioQuery, ParceiroViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarParceiroPorIdUsuarioQueryValidator validator;

        public BuscarParceiroPorIdUsuarioQueryHandler(Persistence.EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscarParceiroPorIdUsuarioQueryValidator(context);
        }

        public async Task<ParceiroViewModel> Handle(BuscarParceiroPorIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var parceiro = await context.Parceiros.FirstOrDefaultAsync(i => i.IdUsuario == request.IdUsuario);

            var parceiroViewModel = mapper.Map<ParceiroViewModel>(parceiro);

            return parceiroViewModel;

        }
    }
}
