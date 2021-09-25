using System;
using AutoMapper;
using Event.Uau.Endereco.Core.Enderecos.Commands.AtualizarEndereco;
using Event.Uau.Endereco.Core.Enderecos.Commands.CadastrarEndereco;
using Event.Uau.Endereco.Core.TiposEnderecos.Commands.CadastrarTipoEndereco;
using Event.Uau.Endereco.ViewModel.Endereco;

namespace Event.Uau.Endereco.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CadastrarTipoEnderecoCommand, Domain.Entities.TipoEndereco>();

            CreateMap<Domain.Entities.TipoEndereco, TipoEnderecoViewModel>();

            CreateMap<CadastrarEnderecoCommand, Domain.Entities.Endereco>()
                .ForMember(i => i.TipoEndereco, opt => opt.Ignore());

            CreateMap<AtualizarEnderecoCommand, Domain.Entities.Endereco>()
                .ForMember(i => i.TipoEndereco, opt => opt.Ignore())
                .ForMember(i => i.Id, opt => opt.Ignore())
                .ForMember(i => i.IdExterno, opt => opt.Ignore());

            CreateMap<Domain.Entities.Endereco, EnderecoViewModel>();
        }
    }
}
