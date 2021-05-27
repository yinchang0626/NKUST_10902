using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using YC.Models;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("QuestionGroups")]
        public async Task<ActionResult<IEnumerable<QuestionGroup>>> GetQuestionGroups()
        {
            return await _context.QuestionGroups.ToListAsync();
        }
        [HttpGet]
        [Route("QuestionTypes")]
        public async Task<ActionResult<IEnumerable<QuestionType>>> GetQuestionTypes(long groupId)
        {
            return await _context.QuestionTypes
                .Where(x => x.GroupId == groupId)
                .ToListAsync();
        }



        [HttpPost]
        [Route("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                
            }
            return Ok();
        }
        [HttpPost]
        [Route("DeleteQuestion")]
        public async Task<IActionResult> DeleteQuestion(long id)
        {
            if (ModelState.IsValid)
            {
                var question = await _context.Questions.FindAsync(id);
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();

            }
            return Ok();
        }
    }
}
