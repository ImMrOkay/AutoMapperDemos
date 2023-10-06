using AutoMapper;
using Configuration.Dtos;
using Configuration.Models;

namespace Configuration.Profiles
{
    // 这是从版本5开始的方法
    public class FooProfile : Profile
    {
        public FooProfile()
        {
            CreateMap<Foo, FooDto>();
        }
    }
}
