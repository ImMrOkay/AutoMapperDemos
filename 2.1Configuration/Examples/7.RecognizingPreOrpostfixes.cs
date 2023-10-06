using AutoMapper;
using System.Diagnostics;

namespace Configuration.Examples
{
    public class RecognizingPreOrpostfixes
    {
        public class Source
        {
            public int _value { get; set; }
            public int _value2 { get; set; }

            public int MyControlViewModel { get; set; }

            public int GetMyMoney { get; set; } = 100;

           
        }
        public class Destination
        {
            public int Value { get; set; }
            public int Value2 { get; set; }

            public int MyControl { get; set; }

            public int MyMoney { get; set; }
        }

        public class OrganizationProfile : Profile
        {
            public OrganizationProfile()
            {
                ClearPrefixes(); //清除所有前缀,AutoMapper识别前缀" Get "// BUG?这句加了没用
                RecognizePrefixes("_");
                RecognizePostfixes("ViewModel");
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
            var src = new Source() { _value = 2, _value2 = 3, MyControlViewModel = 4 };
            Destination dst = mapper.Map<Destination>(src);

            // 测试映射结果
            Debug.Assert(dst.Value == 2);
            Debug.Assert(dst.Value2 == 3);
            Debug.Assert(dst.MyControl == 4);
            Debug.Assert(dst.MyMoney == 100);
            Console.WriteLine(dst.Value);
            Console.WriteLine(dst.Value2);
            Console.WriteLine(dst.MyControl);
            Console.WriteLine(dst.MyMoney);
            Console.ReadLine();
        }

    }
}
