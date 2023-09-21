using AutoMapper;
using Demo.Shared.Dtos;
using Demo.Shared.Enums;
using Demo.Shared.Models;

namespace GettingStarted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.配置映射
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>());
            // config.AssertConfigurationIsValid();// 这句可测试映射是否配置有效
            // 2.创建映射
            var mapper = config.CreateMapper();
            // var mapper = new Mapper(config); 与上面一行等价

            var order = new Order() { Status = Status.Complete };

            // 3.执行映射
            OrderDto dto = mapper.Map<OrderDto>(order);

            // 测试映射结果
            Console.WriteLine(dto.Status);
            Console.ReadLine();
        }
    }
}