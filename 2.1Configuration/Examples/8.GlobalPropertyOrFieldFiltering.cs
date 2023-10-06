using AutoMapper;
using System.Diagnostics;

namespace Configuration.Examples
{
    public class GlobalPropertyOrFieldFiltering
    {
        public class Source
        {
            private int value = 2;
            private int value2 = 3;

            public int MyValue { get; private set; } = 4;

            public int MyValue2 { get; protected set; } = 5;

            public int GetMyMoney()
            {
                return 100;
            }
        }
        public class Destination
        {
            public int Value { get; set; }
            public int Value2 { get; set; }
            public int MyValue { get; set; }
            public int MyValue2 { get; set; }
            public int MyMoney { get; set; }
        }

        public class OrganizationProfile : Profile
        {
            public OrganizationProfile()
            {
                ShouldMapField = fi => false;
                ShouldMapMethod = fi => false;
                ShouldMapProperty = pi =>
                    pi.SetMethod != null &&
                    (pi.SetMethod.IsPublic || pi.SetMethod.IsPrivate);
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
            var src = new Source();
            Destination dst = mapper.Map<Destination>(src);

            // 测试映射结果
            Debug.Assert(dst.Value == 0);
            Debug.Assert(dst.Value2 == 0);
            Debug.Assert(dst.MyValue == 4);
            Debug.Assert(dst.MyValue2 == 0);
            Debug.Assert(dst.MyMoney == 0);
            Console.WriteLine(dst.Value);
            Console.WriteLine(dst.Value2);
            Console.WriteLine(dst.MyValue);
            Console.WriteLine(dst.MyValue2);
            Console.WriteLine(dst.MyMoney);
            Console.ReadLine();
        }

    }
}
