using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ViewModels
{
    public class ActivitySearchParams
    {
        public string Keyword { get; set; }
        public int PageIndex { get; set; }
        public string Order { get; set; }
    }
}
