using INTEX2.Models;
using INTEX2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly RDSDbContext _context;

        //private IMummyRepository repo;
        public HomeController(RDSDbContext context)
        {
            _context = context;
        }
/*        public HomeController(IMummyRepository temp)
        {
            repo = temp;
        }*/

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult GDPR_Notice()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Burial_summary(int pageNum = 1)
        {

            int pageSize = 10;

            var x = new MummiesViewModel
            {
                Mummies = repo.Mummies
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumRecords = repo.Mummies.Count(),
                    RecordsPerPage = pageSize,
                    CurrentPage = pageNum,
                    
                }

            };

            

            return View(x);
        }

        public IActionResult Burial_prediction()
        {
            return View();
        }
        public IActionResult Analysis()
        {
            return View();
        }
        public IActionResult Add_mummy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit_burialmain(int mummy_id)
        {
            var mummy_data = _context.Mummies.SingleOrDefault(x => x.id == mummy_id);
            return View(mummy_data);
        }

        [HttpPost]
        public IActionResult Edit_burialmain(Mummy mummy)
        {
            _context.Mummies.Update(mummy);
            _context.SaveChanges();
            return RedirectToAction("Burial_summary");
        }

    }
}
