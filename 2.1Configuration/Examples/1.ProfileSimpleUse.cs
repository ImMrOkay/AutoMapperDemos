using AutoMapper;
using Configuration.Dtos;
using Configuration.Models;
using Configuration.Profiles;
using System.Diagnostics;

namespace Configuration.Examples
{
    public class ProfileSimpleUse
    {
        /// <summary>
        /// 通过直接的方式添加到主映射器配置中
        /// </summary>
        public static void RunExample()
        {
            // 1.配置映射
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FooProfile>();
            });

            // 2.创建映射
            var mapper = config.CreateMapper();

            // 3.执行映射
            var foo = new Foo() { Value = 2 };
            FooDto dto = mapper.Map<FooDto>(foo);

            // 测试映射结果
            Debug.Assert(dto.Value == 2);
            Console.WriteLine(dto.Value);
            Console.ReadLine();
        }
    }
}
