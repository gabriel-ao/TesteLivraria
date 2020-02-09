using AutoMapper;
using Livraria.Infra.Entities;

namespace Livraria.Infra
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Model.Autor, Autor>().ReverseMap();
            CreateMap<Domain.Model.Livro, Livro>().ReverseMap();
            CreateMap<Domain.Model.Exemplar, Exemplar>().ReverseMap();
        }
    }
}
