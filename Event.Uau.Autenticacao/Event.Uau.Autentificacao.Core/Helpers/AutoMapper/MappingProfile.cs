using System;
using AutoMapper;
using Event.Uau.Comum.Util.Extensoes;

namespace Event.Uau.Autenticacao.Core.Helpers.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Usuario, ViewModel.Autenticacao.UsuarioViewModel>();

            CreateMap<Usuario.Commands.CadastrarUsuario.CadastrarUsuarioCommand, Domain.Entities.Usuario>()
                .ForMember(i => i.Senha, opt => opt.MapFrom(cadastrar => cadastrar.Senha.ToHash()))
                .ForMember(i => i.Telefone, opt => opt.MapFrom(cadastrar => cadastrar.Telefone.LimparTelefone()));

            CreateMap<Domain.Entities.Especialidade, ViewModel.Especialidade.EspecialidadeViewModel>();

            CreateMap<Especialidade.Commands.CadastrarEspecialidade.CadastrarEspecialidadeCommand, Domain.Entities.Especialidade>();
        }
    }
}
