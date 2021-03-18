using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class ImportXmlService
    {
        public ImportXmlService() { }
        public List<StationExit> LoadFormFile(string filePath)
        {
            var str = System.IO.File.ReadAllText(filePath);

            var xDocument = System.Xml.Linq.XDocument.Parse(str);

            var targets = xDocument.Descendants("StationExit");

            return targets
                .Select(x =>
                {
                    var item = new StationExit();
                    item.UpdateTime = x.Element("UpdateTime").Value;
                    item.StationID = x.Element("StationID").Value;
                    item.LocationDescription = x.Element("LocationDescription").Value;
                    return item;
                })
                .ToList();
        }
    }
}
