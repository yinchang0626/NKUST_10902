using ConsoleApp.Services;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlService1 = new ImportXmlService();

            var datas = xmlService1.LoadFormFile(@"D:\Works\11003\NKUST_10902-0318\docs\北捷站點.xml");


            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", datas.Count));
            datas.ForEach(x =>
            {
                Console.WriteLine(string.Format("編號 :{0} 描述:{1}",x.StationID,x.LocationDescription));
            });


            var jsonService = new ImportJsonService();


            var jsonDatas = jsonService.LoadFormFile(@"D:\Works\11003\NKUST_10902-0318\docs\高雄活動.txt");

            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", jsonDatas.Count));
            jsonDatas.ForEach(x =>
            {
                Console.WriteLine(string.Format("編號 :{0} 描述:{1}", x.PRGID, x.ORGNAME));
            });

            Console.ReadKey();
        }
    }
}
