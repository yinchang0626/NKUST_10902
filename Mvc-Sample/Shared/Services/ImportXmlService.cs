﻿using ConsoleApp.Models;
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
                    item.StationID = x.Element("StationID").Value;
                    item.UpdateTime = x.Element("UpdateTime").Value;
                    item.LocationDescription = x.Element("LocationDescription").Value;
                    item.Elevator = bool.Parse(x.Element("Elevator").Value);
                    var stationNameNode = x.Element("StationName");
                    var exitNameNode= x.Element("ExitName");
                    item.StationName = stationNameNode.Element("Zh_tw").Value;
                    item.ExitName  = exitNameNode.Element("Zh_tw").Value;
                    return item;
                })
                .ToList();
        }
    }
}
