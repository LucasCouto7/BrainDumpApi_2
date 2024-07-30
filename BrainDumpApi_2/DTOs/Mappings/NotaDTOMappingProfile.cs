using AutoMapper;
using BrainDumpApi_2.Models;

namespace BrainDumpApi_2.DTOs.Mappings;

public class NotaDTOMappingProfile : Profile
{
    public NotaDTOMappingProfile() 
    {
        CreateMap<Nota, NotaDTO>().ReverseMap();
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        //CreateMap<Nota, NotaDTOUpdateRequest>().ReverseMap();
        //CreateMap<Nota, NotaDTOUpdateResponse>().ReverseMap();
    }
}
