
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

/*
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiroPorIdUsuario;
using System.Linq;

namespace Event.Uau.Autenticacao.Core.Parceiro.Commands.CadastrarParceiro
{
    public class CadastrarParceiroCommandHandler : IRequestHandler<CadastrarParceiroCommand, ParceiroViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly CadastrarParceiroCommandValidator validator;

        public CadastrarParceiroCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new CadastrarParceiroCommandValidator(context);
        }

        public async Task<ParceiroViewModel> Handle(CadastrarParceiroCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var usuario = await context.Usuarios.FirstOrDefaultAsync(i => i.Id == request.IdUsuarioLogado);

            usuario.Parceiro = mapper.Map<Domain.Entities.Parceiro>(request);

            if ((request.IdsEspecialidades?.Any()).GetValueOrDefault(false))
                usuario.Parceiro.Especialidades = await context.Especialidades.Where(i => request.IdsEspecialidades.Contains(i.Id)).ToListAsync();

            await context.SaveChangesAsync(cancellationToken);

            var query = new BuscarParceiroPorIdUsuarioQuery
            {
                IdUsuario = request.IdUsuarioLogado,
                IdUsuarioLogado = request.IdUsuarioLogado,
                Token = request.Token
            };

            return await mediator.Send(query);

        }
    }
}
*/