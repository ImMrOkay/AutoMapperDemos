using AutoMapper;
using Demo.Shared.Dtos;
using Demo.Shared.Models;

namespace Demo.Shared.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
