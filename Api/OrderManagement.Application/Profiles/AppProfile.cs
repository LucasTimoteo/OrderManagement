using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Profiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<Product, ProductViewDto>();
        CreateMap<Client, ClientViewDto>();

        CreateMap<Promotion, PromotionViewDto>();

        CreateMap<Order, OrderViewDto>()
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
            .ForMember(d => d.ClientName, o => o.MapFrom(s => s.Client.Name))
            .ForMember(d => d.Items, o => o.MapFrom(s => s.OrderItems));

        CreateMap<OrderItem, OrderItemViewDto>()
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name));
    }
}

