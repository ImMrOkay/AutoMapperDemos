using AutoMapper;
using Demo.Shared.Dtos;
using Demo.Shared.Enums;
using Demo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Examples
{
    public class AutoScanProfilesInAssemblyByType
    {
        public static void RunExample()
        {
            // 1.配置映射
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(Order));
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
