﻿using System;
using AutoMapper;

namespace Event.Uau.Carteira.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Carteira.Commads.CadastrarCarteira.CadastrarCarteiraCommand, Domain.Entities.Carteira>()
                .ForMember(i => i.IdUsuario, opt => opt.MapFrom(i => i.IdUsuarioLogado));

            CreateMap<Operacao.Commands.RealizarOperacao.RealizarOperacaoCommand, Domain.Entities.Operacao>()
                .ForMember(i => i.TipoOperacao, opt => opt.Ignore())
                .ForMember(i => i.DataHora, opt => opt.MapFrom(i => DateTime.Now))
                .ForMember(i => i.IdUsuario, opt => opt.MapFrom(i => i.IdUsuarioLogado));
        }
    }
}
