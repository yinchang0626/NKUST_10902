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
            return Search(new ActivitySearchParams());
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

            query.Skip((searchParams.PageIndex) * 30).Take(30);

            ViewBag.SearchParams = searchParams;

            return View("Index", query.ToList());
        }

        [HttpGet]
        public IActionResult Import()
        {
            var activityService = new ConsoleApp.Services.ImportJsonService();
            List<Activity> activityDatas = activityService.LoadFormFile(ConsoleApp.Utils.FilePath.GetFullPath("高雄活動.txt"));

            var stationExitService = new ConsoleApp.Services.ImportXmlService();
            List<StationExit> stationExitDatas = stationExitService.LoadFormFile(ConsoleApp.Utils.FilePath.GetFullPath("北捷站點.xml"));

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

            applicationDbContext.Activities.Add(create);

            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {

            var model = applicationDbContext.Activities.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ConsoleApp.Models.Activity edit)
        {

            applicationDbContext.Entry(edit).State = EntityState.Modified;

            applicationDbContext.Update(edit);

            applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {  
            var model = applicationDbContext.Activities.Find(id);

            applicationDbContext.Activities.Remove(model);

            applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
