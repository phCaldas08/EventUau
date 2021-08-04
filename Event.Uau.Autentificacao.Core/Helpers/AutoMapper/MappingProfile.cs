using System;
using AutoMapper;
using Event.Uau.Autenticacao.Core.Authentication.User.Commands.Create;
using Event.Uau.Autenticacao.Core.Authentication.User.Commands.Update;

namespace Event.Uau.Autenticacao.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.User, ViewModel.UserViewModel>();
            CreateMap<CreateCommand, Domain.Entities.User>();
            CreateMap<UpdateCommand, Domain.Entities.User>();
        }
    }
}
