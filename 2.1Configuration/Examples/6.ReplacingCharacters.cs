using AutoMapper;
using System.Diagnostics;

namespace Configuration.Examples
{
    public class ReplacingCharacters
    {
        public class Source
        {
            public int Value { get; set; }
            public int Ävíator { get; set; }
            public int SubAirlinaFlight { get; set; }
        }
        public class Destination
        {
            public int Value { get; set; }
            public int Aviator { get; set; }
            public int SubAirlineFlight { get; set; }
        }

        public class OrganizationProfile : Profile
        {
            public OrganizationProfile()
            {
                CreateMap<Source, Destination>();
            }
        }

        public static void RunExample()
        {
            // 1.配置映射
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ReplaceMemberName("Ä", "A");
                cfg.ReplaceMemberName("í", "i");
                cfg.ReplaceMemberName("Airlina", "Airline");
                cfg.AddProfile<OrganizationProfile>();
            });

            // 2.创建映射
            var mapper = config.CreateMapper();

            // 3.执行映射
            var src = new Source() { Value = 2, Ävíator = 3, SubAirlinaFlight = 4 };
            Destination dst = mapper.Map<Destination>(src);

            // 测试映射结果
            Debug.Assert(dst.Value == 2);
            Debug.Assert(dst.Aviator == 3);
            Debug.Assert(dst.SubAirlineFlight == 4);
            Console.WriteLine(dst.Value);
            Console.WriteLine(dst.Aviator);
            Console.WriteLine(dst.SubAirlineFlight);
            Console.ReadLine();
        }
    }
}
