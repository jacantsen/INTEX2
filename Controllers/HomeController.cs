using INTEX2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEX2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMummyRepository repo;
        public HomeController(IMummyRepository temp)
        {
            repo = temp;
        }

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
        public IActionResult Burial_summary()
        {
            var x = repo.Mummies.ToArray();
            return View(x);
        }

        [HttpPost]
        public IActionResult Burial_summary(SearchSpecifications search)
        {
            //var results = repo.Mummies.AsQueryable();
            
            var results = repo.Mummies
                .Include(m => m.BurialMain_Textile)
                    .ThenInclude(bmt => bmt.Textile)
                        .ThenInclude(t => t.ColorTextile)
                            .ThenInclude(ct => ct.Color)
                .AsQueryable();

            // go through each variable in search variabel that I've brought over
            //possibly add ability to search for null values

            if (search.burialId.HasValue)
            {
                results = results.Where(m => m.id == search.burialId);
            }

            if (!string.IsNullOrEmpty(search.deathAge))
            {
                results = results.Where(m => m.ageatdeath == search.deathAge);
            }

            if (!string.IsNullOrEmpty(search.sex))
            {
                results = results.Where(m => m.sex == search.sex);
            }

            //might break it.  Not exactly sure how textile, connects ot mummy table yet
            if (!string.IsNullOrEmpty(search.textileColor))
            {
                results = results.Where(m =>
                   m.BurialMain_Textile.Any(bmt =>
                       bmt.Textile != null &&
                       bmt.Textile.ColorTextile != null &&
                       bmt.Textile.ColorTextile.Color != null &&
                       bmt.Textile.ColorTextile.Color.value.Contains(search.textileColor)));
            }

            var filteredResults = results.ToArray();
            return View(filteredResults);
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

    }
}
