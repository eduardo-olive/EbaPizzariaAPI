using AutoMapper;
using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Application.Mappings
{
	public class EntitiesToDTOMappingProfile : Profile
	{
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Pizza, PizzaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Pedido, PedidoDTO>().ReverseMap()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(x => x.ClienteDTO));
            CreateMap<Pedido, PedidoPostDTO>().ReverseMap();
        }
    }
}
