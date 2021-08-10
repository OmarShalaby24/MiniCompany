using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniCompnay.Data;

namespace MiniCompnay.Controllers
{
    public class helloworldController : Controller
    {
        //private readonly CompanyContext _context;

        public IActionResult Index()
        {
            /*var query = from e in _context.Employees
                        where e.ID == 1
                        select e.Name;
            ViewData["data1"] = query;*/
            return View();
        }
    }
}
