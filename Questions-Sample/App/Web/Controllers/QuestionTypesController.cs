using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using YC.Models;

namespace Web.Controllers
{
    public class QuestionTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionTypes
        public async Task<IActionResult> Index(long groupId)
        {
            if (groupId == 0) 
            {
                var group = _context.QuestionGroups.OrderBy(x => x.Id).FirstOrDefault();
                return RedirectToAction("Index", new { groupId = group.Id });
            }

            var groups = _context.QuestionGroups.ToList()
                .Select(x =>
                {
                    SelectListItem selectListItem = new SelectListItem();
                    selectListItem.Value = x.Id.ToString();
                    selectListItem.Text = x.Name;
                    selectListItem.Selected = x.Id == groupId;

                    return selectListItem;
                }).ToList();

            


            this.ViewBag.Groups = groups;
            

            var applicationDbContext = _context
                .QuestionTypes
                .Include(q => q.Group)
                .Where(x => x.GroupId == groupId);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QuestionTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionType = await _context.QuestionTypes
                .Include(q => q.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionType == null)
            {
                return NotFound();
            }

            return View(questionType);
        }

        // GET: QuestionTypes/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.QuestionGroups, "Id", "Name");
            return View();
        }

        // POST: QuestionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,GroupId")] QuestionType questionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionType);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { groupId = questionType.GroupId });
            }
            ViewData["GroupId"] = new SelectList(_context.QuestionGroups, "Id", "Id", questionType.GroupId);
            return View(questionType);
        }

        // GET: QuestionTypes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionType = await _context.QuestionTypes.FindAsync(id);
            if (questionType == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.QuestionGroups, "Id", "Name", questionType.GroupId);
            return View(questionType);
        }

        // POST: QuestionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Description,GroupId")] QuestionType questionType)
        {
            if (id != questionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionTypeExists(questionType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { groupId = questionType.GroupId });
            }
            ViewData["GroupId"] = new SelectList(_context.QuestionGroups, "Id", "Id", questionType.GroupId);
            return View(questionType);
        }

        // GET: QuestionTypes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionType = await _context.QuestionTypes
                .Include(q => q.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionType == null)
            {
                return NotFound();
            }

            return View(questionType);
        }

        // POST: QuestionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var questionType = await _context.QuestionTypes.FindAsync(id);
            _context.QuestionTypes.Remove(questionType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionTypeExists(long id)
        {
            return _context.QuestionTypes.Any(e => e.Id == id);
        }
    }
}
