using AutoMapper;
using System.Diagnostics;

namespace Configuration.Examples
{
    // 当前示例演示 property_name -> PropertyName 映射
    // TODO:自定义命名约定
    public class NamingConventions
    {
        public class Source
        {
            public int my_value { get; set; }
            public int Value { get; set; }
        }

        public class Destination
        {
            public int MyValue { get; set; }
            public int Value { get; set; }
        }


        public class OrganizationProfile : Profile
        {
            public OrganizationProfile()
            {
                // 对于当前Profile里面的映射,除了支持默认的属性映射方式外，还支持
                // 命名约定为：property_name -> PropertyName 映射
                SourceMemberNamingConvention = LowerUnderscoreNamingConvention.Instance;
                DestinationMemberNamingConvention = PascalCaseNamingConvention.Instance;
                CreateMap<Source, Destination>();
            }
        }

        public static void RunExample()
        {
            // 1.配置映射
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrganizationProfile>();
            });

            // 2.创建映射
            var mapper = config.CreateMapper();

            // 3.执行映射
            var src = new Source() { my_value = 2, Value = 3 };
            Destination dst = mapper.Map<Destination>(src);

            // 测试映射结果
            Debug.Assert(dst.MyValue == 2);
            Debug.Assert(dst.Value == 3);
            Console.WriteLine(dst.MyValue);
            Console.WriteLine(dst.Value);
            Console.ReadLine();
        }
    }
}
