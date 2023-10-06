using Configuration.Examples;
namespace Configuration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// 1.Profile的简单使用
            //ProfileSimpleUse.RunExample();

            //// 2.扫描程序集中所有Profile，配置映射(以程序集实例方式)
            //AutoScanProfilesInAssemblyByInstance.RunExample();

            //// 3.扫描程序集中所有Profile，配置映射(以程序集名称方式)
            //AutoScanProfilesInAssemblyByName.RunExample();

            //// 4.扫描程序集中所有Profile，配置映射(以类型的方式)
            //AutoScanProfilesInAssemblyByType.RunExample();

            //// 5.按命名约定映射
            //NamingConventions.RunExample();

            //// 6.替换字符
            //ReplacingCharacters.RunExample();

            //// 7.前缀映射
            //RecognizingPreOrpostfixes.RunExample();

            // 8.前缀映射
            GlobalPropertyOrFieldFiltering.RunExample();

        }
    }
}