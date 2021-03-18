using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class StationExit
    {
        public string StationID { get; set; }
        public string UpdateTime { get; set; }
        public string LocationDescription { get; set; }
        public bool Elevator { get; set; }
        public DisplayName StationName { get; set; }
        public DisplayName ExitName { get; set; }
    }

    public class DisplayName 
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }
}
