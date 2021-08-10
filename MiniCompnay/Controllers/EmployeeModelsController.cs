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
    public class EmployeeModelsController : Controller
    {
        private readonly CompanyContext _context;

        public EmployeeModelsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: EmployeeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: EmployeeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employees
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (employeeModel == null)
            {
                return NotFound();
            }

//            List<SkillModel> skills = new List<SkillModel>();
//            skills = _context.EmployeeSkills
//                .Join
//                .Where(e => e.EmployeeID == id)
//.Select(s => new SkillModel
//{
//    ID=s.SkillID
//}).ToList();


            List<SkillModel> skills = _context.EmployeeSkills
                .Where(e => e.EmployeeID == id)
                .Join(
                    _context.Skills,
                    es => es.SkillID,
                    s => s.ID,
                    (es, s) => new SkillModel
                    {
                        ID = es.SkillID,
                        Name = s.Name
                    }
                ).ToList();
            //ViewData["Skills"] = skills;
            ViewBag.TableHead = "Skills";
            ViewBag.SkillList = skills;

            return View(employeeModel);
        }

        // GET: EmployeeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeModel);
        }

        // GET: EmployeeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employees.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        // POST: EmployeeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email")] EmployeeModel employeeModel)
        {
            if (id != employeeModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeModelExists(employeeModel.ID))
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
            return View(employeeModel);
        }

        // GET: EmployeeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.Employees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // POST: EmployeeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeModel = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employeeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeModelExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }

        public IActionResult AddSkill(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sklList = new SelectList(_context.Skills.ToList(),"ID", "Name");
            ViewData["Skills"] = sklList;

            ViewBag.Skl = _context.Skills.ToList();

            var employee = _context.Employees.Where(e => e.ID == id).ToList();
            ViewBag.Employee = employee;

            ViewData["id"] = id;


            return View();
        }

        

        // POST: EmployeeModels/AddSkill/6
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSkill([Bind("EmployeeID")] EmployeeSkillModel employeeSkillModel,int[] SkillIDs)
        {
            
            /*EmployeeModel emp = new EmployeeModel()
            {
                ID = employeeSkillModel.EmployeeID
            };*/

            if (ModelState.IsValid)
            {
                foreach (int newSkillID in SkillIDs)
                {
                    employeeSkillModel.ID = 0;
                    employeeSkillModel.SkillID = newSkillID;
                    _context.Add(employeeSkillModel);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeSkillModel);
        }
    }
}
