using ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication.Data;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebApplication.Controllers.Apis
{
    [Route("api/activity")]
    [ApiController]
    public class ActivityApiController: ControllerBase
    {

        public ApplicationDbContext applicationDbContext;
        public ActivityApiController(
            ApplicationDbContext applicationDbContext
            )
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<List<Activity>> GetAsync() 
        {
            var datas = await this.applicationDbContext.Activities.ToListAsync();
            return datas;
        }
        [HttpGet]
        public async Task<Activity> GetAsync(string id)
        {
            var data = await this.applicationDbContext.Activities.FindAsync(id);
            return data;
        }
        [HttpPost]
        public async Task<Activity> Post(Activity input)
        {
            applicationDbContext.Activities.Add(input);

            await applicationDbContext.SaveChangesAsync();

            return input;

        }

        [HttpPut]
        public async Task<Activity> Put(Activity input)
        {
            //applicationDbContext.Activities.Add(input);

            //await applicationDbContext.SaveChangesAsync();

            //return input;
            return null;

        }

        [HttpDelete]
        public async Task<Activity> Delete(Activity input)
        {
            return null;
        }

    }
}
