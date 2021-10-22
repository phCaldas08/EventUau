using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Evento.Persistence;
using Event.Uau.Evento.ViewModel.Evento;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Evento.Core.StatusContratacao.Queries.BuscarStatusContratacaoPorId
{
    public class BuscarStatusContratacaoPorIdQueryHandler : IRequestHandler<BuscarStatusContratacaoPorIdQuery, StatusContratacaoViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarStatusContratacaoPorIdQueryValidator validator;

        public BuscarStatusContratacaoPorIdQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscarStatusContratacaoPorIdQueryValidator(context);
        }

        public async Task<StatusContratacaoViewModel> Handle(BuscarStatusContratacaoPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var status = await context.StatusContratacoes.FirstOrDefaultAsync(i => i.Id.Equals(request.Id, StringComparison.CurrentCultureIgnoreCase));

            var statusViewModel = mapper.Map<StatusContratacaoViewModel>(status);

            return statusViewModel;
        }
    }
}
