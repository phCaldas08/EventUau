using System;
using AutoMapper;

namespace Event.Uau.Upload.Core.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Arquivo.Commands.UploadArquivos.UploadArquivosCommand, Domain.Entities.Arquivo>()
                .ForMember(i => i.IdUsuario, opt => opt.MapFrom(i => i.IdUsuarioLogado));

            CreateMap<Domain.Entities.Arquivo, ViewModel.Upload.ArquivoViewModel>();
        }
    }
}
