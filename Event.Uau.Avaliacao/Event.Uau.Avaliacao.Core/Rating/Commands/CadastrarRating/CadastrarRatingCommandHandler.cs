
using AutoMapper;
using Event.Uau.Avaliacao.Persistence;
using Event.Uau.Avaliacao.ViewModel.Rating;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Event.Uau.Avaliacao.Core.Rating.Commands.CadastrarRating
{
    public class CadastrarRatingCommandHandler : IRequestHandler<CadastrarRatingCommand, RatingViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        //private readonly CadastrarRatingCommandValidator validator;

        public CadastrarRatingCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            //this.validator = new CadastrarParceiroCommandValidator(context);
        }

        public async Task<RatingViewModel> Handle(CadastrarRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = mapper.Map<Domain.Entities.Rating>(request);

            await context.Ratings.AddAsync(rating);

            await context.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<RatingViewModel>(rating);

            return result;
        }
    }
}