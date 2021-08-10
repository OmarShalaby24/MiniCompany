using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniCompnay.Data;
using MiniCompnay.Models;

namespace MiniCompnay.Controllers
{
    public class SkillModelsController : Controller
    {
        private readonly CompanyContext _context;

        public SkillModelsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: SkillModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skills.ToListAsync());
        }

        // GET: SkillModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillModel = await _context.Skills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (skillModel == null)
            {
                return NotFound();
            }

            return View(skillModel);
        }

        // GET: SkillModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkillModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] SkillModel skillModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skillModel);
        }

        // GET: SkillModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillModel = await _context.Skills.FindAsync(id);
            if (skillModel == null)
            {
                return NotFound();
            }
            return View(skillModel);
        }

        // POST: SkillModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] SkillModel skillModel)
        {
            if (id != skillModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillModelExists(skillModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(skillModel);
        }

        // GET: SkillModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillModel = await _context.Skills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (skillModel == null)
            {
                return NotFound();
            }

            return View(skillModel);
        }

        // POST: SkillModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillModel = await _context.Skills.FindAsync(id);
            _context.Skills.Remove(skillModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillModelExists(int id)
        {
            return _context.Skills.Any(e => e.ID == id);
        }
    }
}
