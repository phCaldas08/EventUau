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

namespace Event.Uau.Evento.Core.Status.Queries.BuscarStatusPorId
{
    public class BuscarStatusPorIdQueryHandler : IRequestHandler<BuscarStatusPorIdQuery, StatusViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly BuscarStatusPorIdQueryValidator validator;

        public BuscarStatusPorIdQueryHandler(EventUauDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = new BuscarStatusPorIdQueryValidator(context);
        }

        public async Task<StatusViewModel> Handle(BuscarStatusPorIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var status = await context.Status.FirstOrDefaultAsync(i => i.Id.Equals(request.Id, StringComparison.CurrentCultureIgnoreCase));

            var statusViewModel = mapper.Map<StatusViewModel>(status);

            return statusViewModel;
        }
    }
}
