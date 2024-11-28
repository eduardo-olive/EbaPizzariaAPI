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
            CreateMap<PedidoDTO, Pedido>().ReverseMap()
                .ForMember(dest => dest.ClienteDTO, opt => opt.MapFrom(x => x.Cliente));
			    //.ForMember(dest => dest.ItensPedidoDTO, opt => opt.MapFrom(x => x.ItensPedido));
			CreateMap<Pedido, PedidoPostDTO>().ReverseMap();
            CreateMap<Pedido, PedidoPutDTO>().ReverseMap();
            CreateMap<ItensPedido, ItemPedidoDTO>().ReverseMap();
        }
    }
}
