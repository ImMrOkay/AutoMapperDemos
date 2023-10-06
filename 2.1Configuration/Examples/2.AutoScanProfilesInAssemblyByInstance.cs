using AutoMapper;
using Demo.Shared.Dtos;
using Demo.Shared.Enums;
using Demo.Shared.Models;
using System.Diagnostics;

namespace Configuration.Examples
{
    // 通过程序集实例
    public class AutoScanProfilesInAssemblyByInstance
    {
        public static void RunExample()
        {
            // 1.配置映射
            var myAssembly = typeof(Order).Assembly;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(myAssembly);
            });

            // 2.创建映射
            var mapper = config.CreateMapper();

            // 3.执行映射
            var order = new Order() { Status = Status.Complete };
            OrderDto dto = mapper.Map<OrderDto>(order);

            // 测试映射结果
            Debug.Assert(dto.Status == Status.Complete);
            Console.WriteLine(dto.Status);
            Console.ReadLine();
        }
    }
}
