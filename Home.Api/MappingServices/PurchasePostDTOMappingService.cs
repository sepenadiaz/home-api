using Home.Api.DTOs;
using Home.Api.Model;
using AutoMapper;

namespace Home.Api.MappingServices
{
    public class PurchasePostDTOMappingService : Profile
    {
        public PurchasePostDTOMappingService() 
        {
            CreateMap<PurchasePostDTO, Purchase>();
        }
    }
}


