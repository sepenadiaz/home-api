using Home.Api.DTOs;
using Home.Api.Model;
using AutoMapper;

namespace Home.Api.MappingServices
{
    public class PaymentPostDTOMappingService : Profile
    {
        public PaymentPostDTOMappingService()
        {
            CreateMap<PaymentPostDTO, Payment>();
        }
    }
}


