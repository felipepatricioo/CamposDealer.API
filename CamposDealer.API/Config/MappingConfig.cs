using AutoMapper;
using CamposDealer.API.Models;
using CamposDealer.API.Models.DTO;

namespace CamposDealer.API.Config
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ClienteDTO, Cliente>().ReverseMap();
                config.CreateMap<ProdutoDTO, Produto>().ReverseMap();
                config.CreateMap<VendaDTO, Venda>().ReverseMap();
            });


            return mappingConfig;
        }
    }
}
