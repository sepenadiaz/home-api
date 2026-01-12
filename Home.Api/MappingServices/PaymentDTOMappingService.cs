using Home.Api.DTOs;
using Home.Api.Model;
using AutoMapper;

namespace Home.Api.MappingServices
{
    public class PaymentDTOMappingService : Profile
    {
        public PaymentDTOMappingService()
        {
            CreateMap<Payment, PaymentDTO>()
                .ForMember(dto => dto.Payment, conf => conf.MapFrom(p => $"{p.PaymentNumber}/{p.Purchase.NumberOfPayments}"));
        }
    }
}


