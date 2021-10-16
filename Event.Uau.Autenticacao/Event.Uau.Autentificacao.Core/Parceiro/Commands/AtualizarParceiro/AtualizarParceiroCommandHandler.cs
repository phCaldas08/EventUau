using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Event.Uau.Autenticacao.Persistence;
using Event.Uau.Autenticacao.ViewModel.Autenticacao;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Event.Uau.Autenticacao.Core.Parceiro.Queries.BuscarParceiroPorIdUsuario;

namespace Event.Uau.Autenticacao.Core.Parceiro.Commands.AtualizarParceiro
{
    public class AtualizarParceiroCommandHandler : IRequestHandler<AtualizarParceiroCommand, ParceiroViewModel>
    {
        private readonly EventUauDbContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly AtualizarParceiroCommandValidator validator;

        public AtualizarParceiroCommandHandler(EventUauDbContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.validator = new AtualizarParceiroCommandValidator(context);
        }

        public async Task<ParceiroViewModel> Handle(AtualizarParceiroCommand request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            var parceiro = await context.Parceiros.FirstOrDefaultAsync(i => i.IdUsuario == request.IdUsuario);
            var parceiroAlterado = mapper.Map<Domain.Entities.Parceiro>(request);

            parceiro.Especialidades.RemoveAll(x => true);
            await context.SaveChangesAsync(cancellationToken);

            if ((request.IdsEspecialidades?.Any()).GetValueOrDefault(false))
                parceiroAlterado.Especialidades = await context.Especialidades.Where(i => request.IdsEspecialidades.Contains(i.Id)).ToListAsync();

            parceiro.ValorHora = parceiroAlterado.ValorHora;
            parceiro.Especialidades = parceiroAlterado.Especialidades;            

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
