using Home.Api.DTOs;
using Home.Api.Model;
using AutoMapper;

namespace Home.Api.MappingServices
{
    public class CreditCardDTOMappingService : Profile
    {
        public CreditCardDTOMappingService()
        {
            CreateMap<CreditCard, CreditCardDTO>().ReverseMap();
        }
    }
}


