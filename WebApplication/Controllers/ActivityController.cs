using ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class ActivityController : Controller
    {
        public ApplicationDbContext applicationDbContext;
        public ActivityController(
            ApplicationDbContext applicationDbContext
            )
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Search(ActivitySearchParams searchParams)
        {
            var query = applicationDbContext.Activities.AsQueryable();
            if (!string.IsNullOrEmpty(searchParams.Keyword))
            {
                query = query.Where(x => x.PrgName.Contains(searchParams.Keyword));
            }

            query = query.OrderByDescending(x => x.Id);
            //if (!string.IsNullOrEmpty(searchParams.Order)) 
            //{

            //    query = query.OrderBy(x => EF.Property<string>(x, searchParams.Order));
            //}

            query.Skip((searchParams.PageIndex) * 30).Take(30);


            return View("Index", query.ToList());
        }

        [HttpGet]
        public IActionResult Import()
        {
            var activityService = new ConsoleApp.Services.ImportJsonService();
            List<Activity> activityDatas = activityService.LoadFormFile(ConsoleApp.Utils.FilePath.GetFullPath("高雄活動.txt"));

            var stationExitService = new ConsoleApp.Services.ImportXmlService();
            List<StationExit> stationExitDatas = stationExitService.LoadFormFile(ConsoleApp.Utils.FilePath.GetFullPath("北捷站點.xml"));

            //activityDatas.ForEach(x =>
            //{
            //    applicationDbContext.Activities.Add(x);

            //});

            applicationDbContext.Activities.AddRange(activityDatas);
            applicationDbContext.StationExits.AddRange(stationExitDatas);

            applicationDbContext.SaveChanges();

            return Content("OK");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ConsoleApp.Models.Activity create)
        {
            //var count = applicationDbContext.Activities.Max(x => x.Id);

            //create.Id = count + 1;
            create.Id = 0;

            applicationDbContext.Activities.Add(create);

            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
