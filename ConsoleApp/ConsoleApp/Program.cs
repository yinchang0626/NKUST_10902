using ConsoleApp.Services;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlService1 = new ImportXmlService();

            var datas = xmlService1.LoadFormFile(Utils.FilePath.GetFullPath("北捷站點.xml"));


            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", datas.Count));
            datas.ForEach(x =>
            {
                Console.WriteLine(string.Format("編號 :{0} 名稱:{1}({2}) 描述:{3}", x.StationID, x.StationName?.Zh_tw, x.ExitName.Zh_tw, x.LocationDescription));
            });


            var jsonService = new ImportJsonService();


            var jsonDatas = jsonService.LoadFormFile(Utils.FilePath.GetFullPath("高雄活動.txt"));

            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", jsonDatas.Count));
            jsonDatas.ForEach(x =>
            {
                Console.WriteLine(string.Format("編號 :{0} 名稱:{1} 地點:{2}", x.PrgId,x.PrgName, x.OrgName));
            });

            Console.ReadKey();
        }
    }
}
