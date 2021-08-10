using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniCompnay.Data;
using MiniCompnay.Models;

namespace MiniCompnay.Controllers
{
    public class EmployeeSkillModelsController : Controller
    {
        private readonly CompanyContext _context;

        public EmployeeSkillModelsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: EmployeeSkillModels
        
        public IActionResult Index()
        {
            /*var employeeData = _context.Employees
                .Join(
                    _context.EmployeeSkills,
                    employee => employee.ID,
                    employeeSkill => employeeSkill.EmployeeID,
                    (employee, employeeSkill) => new
                    {
                        ID = employee.ID,
                        Name = employee.Name,
                        Email = employee.Email
                    }
                ).ToList();


            ViewBag.Emp = employeeData;*/
            //ViewData["Emp"] = employeeData;
            return View(_context.EmployeeSkills.ToList());
        }

        // GET: EmployeeSkillModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSkillModel = await _context.EmployeeSkills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employeeSkillModel == null)
            {
                return NotFound();
            }

            return View(employeeSkillModel);
        }

        // GET: EmployeeSkillModels/Create
        public IActionResult Create()
        {
            //ViewBag.Emp = _context.Employees.ToList();
            
            var empList = new SelectList(_context.Employees.ToList(), "ID", "Name");
            ViewData["Employees"] = empList;

            var sklList = new SelectList(_context.Skills.ToList(),"ID", "Name");
            ViewData["Skills"] = sklList;

            ViewBag.Emp = _context.Employees.ToList();
            ViewBag.Skl = _context.Skills.ToList();
            return View();
        }

        // POST: EmployeeSkillModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EmployeeID,SkillID")] EmployeeSkillModel employeeSkillModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeSkillModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeSkillModel);
        }

        // GET: EmployeeSkillModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSkillModel = await _context.EmployeeSkills.FindAsync(id);
            if (employeeSkillModel == null)
            {
                return NotFound();
            }
            return View(employeeSkillModel);
        }

        // POST: EmployeeSkillModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EmployeeID,SkillID")] EmployeeSkillModel employeeSkillModel)
        {
            if (id != employeeSkillModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeSkillModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeSkillModelExists(employeeSkillModel.ID))
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
            return View(employeeSkillModel);
        }

        // GET: EmployeeSkillModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSkillModel = await _context.EmployeeSkills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employeeSkillModel == null)
            {
                return NotFound();
            }

            return View(employeeSkillModel);
        }

        // POST: EmployeeSkillModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeSkillModel = await _context.EmployeeSkills.FindAsync(id);
            _context.EmployeeSkills.Remove(employeeSkillModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeSkillModelExists(int id)
        {
            return _context.EmployeeSkills.Any(e => e.ID == id);
        }

    }
}
