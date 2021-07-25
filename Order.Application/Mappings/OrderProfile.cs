using AutoMapper;
using Order.Application.Features.Commands.CreateOrder;
using Order.Application.Features.Commands.UpdateOrder;

namespace Order.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CommonLibrary.Entities.Order, CreateOrderCommand>().ReverseMap();
            CreateMap<CommonLibrary.Entities.Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
