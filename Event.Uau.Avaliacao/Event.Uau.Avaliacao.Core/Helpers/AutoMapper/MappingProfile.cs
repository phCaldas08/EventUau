using System;
using AutoMapper;
using Event.Uau.Avaliacao.Core.Rating.Commands.CadastrarRating;
using Event.Uau.Comum.Util.Extensoes;
using Event.Uau.Rating.ViewModel.Rating;

namespace Event.Uau.Avaliacao.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CadastrarRatingCommand, Domain.Entities.Rating>();
            CreateMap<Domain.Entities.Rating, RatingViewModel>();
        }
    }
}
