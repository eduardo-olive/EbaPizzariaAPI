using AutoMapper;
using EbaPizzaria.API.DTOs;
using EbaPizzaria.API.Models;

namespace EbaPizzaria.API.Mappings
{
	public class EntitiesToDTOMappingProfile : Profile
	{
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
