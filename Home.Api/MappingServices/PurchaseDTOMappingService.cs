using Home.Api.DTOs;
using Home.Api.Model;
using AutoMapper;

namespace Home.Api.MappingServices
{
    public class PurchaseDTOMappingService : Profile
    {
        public PurchaseDTOMappingService()
        {
            CreateMap<Purchase, PurchaseDTO>()
                    .ForMember(
                        dest => dest.CreditCardName,
                        opt => opt.MapFrom(src => src.CreditCard.Bank + " " + src.CreditCard.CardBrand)
                    );
            CreateMap<PurchasePostDTO, Purchase>();
        }
    }
}


