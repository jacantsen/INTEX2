﻿using INTEX2.Models;
using INTEX2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Humanizer.On;


namespace INTEX2.Controllers
{
    public class HomeController : Controller
    {
        


        private IMummyRepository repo;
        public HomeController(IMummyRepository context)
        {
            repo = context;
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
        
        [HttpGet]
        public IActionResult RecordLookup()
        {

            return View();
        }
        [HttpPost]
        public IActionResult RecordLookup(long idNumber)
        {
            if (idNumber > 0)
            {
                long burialId = idNumber;
                var results = repo.Mummies
                               .Where(m => m.id == burialId)
                               .Include(m => m.BurialMain_Textile)
                                    .ThenInclude(bmt => bmt.Textile)
                                        .ThenInclude(t => t.ColorTextile)
                                            .ThenInclude(ct => ct.Color)
                                 .FirstOrDefault();

                ViewBag.SearchPerformed = true;
                return View(results);
            }
            else
            {
                ViewBag.SearchPerformed = false;
                return View();
            }
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

        // reset button to clear search results
        public IActionResult ResetFilter()
        {
            TempData["search"] = null;
            return RedirectToAction("Burial_summary", new { pageNum = 1 });
        }

        [HttpGet]
        public IActionResult Burial_summary(int pageNum = 1)
        {

            int pageSize = 10;
            var results = repo.Mummies
                .Include(m => m.BurialMain_Textile)
                    .ThenInclude(bmt => bmt.Textile)
                        .ThenInclude(t => t.ColorTextile)
                            .ThenInclude(ct => ct.Color)
                .AsQueryable();

            if (TempData["search"] != null)
            {
                SearchSpecifications search = JsonConvert.DeserializeObject<SearchSpecifications>(TempData["search"].ToString());
                // go through each variable in search variabel that I've brought over
                //possibly add ability to search for null values
                TempData["search"] = TempData["search"];

                if (search.burialId.HasValue)
                {
                    results = results.Where(m => m.id == search.burialId);
                }
                if (!string.IsNullOrEmpty(search.deathAge))
                {
                    results = results.Where(m => m.ageatdeath == search.deathAge);
                }
                //if there's time, make it so that it's between this depth and this depth
                if (!string.IsNullOrEmpty(search.depth))
                {
                    results = results.Where(m => m.depth == search.depth);
                }
                if (!string.IsNullOrEmpty(search.sex))
                {
                    results = results.Where(m => m.sex == search.sex);
                }
                if (!string.IsNullOrEmpty(search.headDirection))
                {
                    results = results.Where(m => m.headdirection == search.headDirection);
                }
                if (!string.IsNullOrEmpty(search.hairColor))
                {
                    results = results.Where(m => m.haircolor == search.hairColor);
                }
                if (!string.IsNullOrEmpty(search.faceBundle))
                {
                    if (search.faceBundle == "Y")
                    {
                        results = results.Where(m => m.facebundles == search.faceBundle);
                    }
                    else
                    {
                        results = results.Where(m => string.IsNullOrEmpty(m.facebundles));
                    }
                        
                }

                //put in Textile structure if time
                // Also add Textile function if time
                //might break it.  Not exactly sure how textile, connects ot mummy table yet
                if (!string.IsNullOrEmpty(search.textileColor))
                {
                    results = results.Where(m =>
                       m.BurialMain_Textile.Any(bmt =>
                           bmt.Textile != null &&
                           bmt.Textile.ColorTextile != null &&
                           bmt.Textile.ColorTextile.Color != null &&
                           bmt.Textile.ColorTextile.Color.value.ToUpper().Contains(search.textileColor.ToUpper())));
                }

            }

            var x = new MummiesViewModel
            {
                Mummies = results
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumRecords = results.Count(),
                    RecordsPerPage = pageSize,
                    CurrentPage = pageNum,
                }

            };

            return View(x);
        }


        [HttpPost]
        public IActionResult Burial_summary(SearchSpecifications search)
        {

            TempData["search"] = JsonConvert.SerializeObject(search);
            return RedirectToAction("Burial_summary", new { pageNum = 1 });

            //return View(y);
        }
        public IActionResult Burial_prediction()
        {
            return View();
        }
        public IActionResult Analysis()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add_mummy()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add_mummy(Mummy mummy)
        {
            if (ModelState.IsValid)
            {
                repo.AddMummy(mummy);
                return RedirectToAction("Burial_summary");
            }
            return View(mummy);
        }


        //delete method
        [HttpPost]
        public IActionResult Delete_burialmain(long mummy_id)
        {
            var mummyToDelete = repo.Mummies.SingleOrDefault(x => x.id == mummy_id);

            if (mummyToDelete != null)
            {
                // Delete the mummy from the repository
                repo.DeleteMummy(mummyToDelete);

                // Save changes (if required by the repository implementation)
                // repo.SaveChanges(); // Uncomment this line if your repository implementation requires it
            }

            return RedirectToAction("Burial_summary");
        }



        [HttpGet("Edit_burialmain/{mummy_id}")]
        public IActionResult Edit_burialmain(long mummy_id)
        {
            var mummy_data = repo.Mummies.SingleOrDefault(x => x.id == mummy_id);
            return View("Edit_burialmain",mummy_data);
        }

        [HttpPost("Edit_burialmain/{id}")]
        [ValidateAntiForgeryToken]
        //public IActionResult Edit_burialmain(long id , [Bind("fieldbookexcavationyear, fieldbookpage, dataexpertinitials, squarenorthsouth, northsouth, squareeastwest, eastwest, area, burialnumber, westtohead, westtofeet, southtohead, southtofeet, depth, length, headdirection, preservation, wrapping, adultsubadult, sex, ageatdeath, haircolor, samplescollected, goods, facebundles, text, burialid, photos, dateofexcavation, shaftnumber, clusternumber, burialmaterials, excavationrecorder, hair")] Mummy mummy)
        public IActionResult Edit_burialmain(long id, Mummy mummy)

        {
            var mummyToUpdate = repo.GetMummyById(id);
            //var mummyToUpdate = repo.Mummies.SingleOrDefault(x => x.id == id);
            if (mummyToUpdate != null)
            {
                mummyToUpdate.fieldbookexcavationyear = mummy.fieldbookexcavationyear;
                mummyToUpdate.fieldbookpage = mummy.fieldbookpage;
                mummyToUpdate.dataexpertinitials = mummy.dataexpertinitials;
                mummyToUpdate.squarenorthsouth = mummy.squarenorthsouth;
                mummyToUpdate.northsouth = mummy.northsouth;
                mummyToUpdate.squareeastwest = mummy.squareeastwest;
                mummyToUpdate.eastwest = mummy.eastwest;
                mummyToUpdate.area = mummy.area;
                mummyToUpdate.burialnumber = mummy.burialnumber;
                mummyToUpdate.westtohead = mummy.westtohead;
                mummyToUpdate.westtofeet = mummy.westtofeet;
                mummyToUpdate.southtohead = mummy.southtohead;
                mummyToUpdate.southtofeet = mummy.southtofeet;
                mummyToUpdate.depth = mummy.depth;
                mummyToUpdate.length = mummy.length;
                mummyToUpdate.headdirection = mummy.headdirection;
                mummyToUpdate.preservation = mummy.preservation;
                mummyToUpdate.wrapping = mummy.wrapping;
                mummyToUpdate.adultsubadult = mummy.adultsubadult;
                mummyToUpdate.sex = mummy.sex;
                mummyToUpdate.ageatdeath = mummy.ageatdeath;
                mummyToUpdate.haircolor = mummy.haircolor;
                mummyToUpdate.samplescollected = mummy.samplescollected;
                mummyToUpdate.goods = mummy.goods;
                mummyToUpdate.facebundles = mummy.facebundles;
                mummyToUpdate.text = mummy.text;
                mummyToUpdate.burialid = mummy.burialid;
                mummyToUpdate.photos = mummy.photos;
                mummyToUpdate.dateofexcavation = mummy.dateofexcavation;
                mummyToUpdate.shaftnumber = mummy.shaftnumber;
                mummyToUpdate.clusternumber = mummy.clusternumber;
                mummyToUpdate.burialmaterials = mummy.burialmaterials;
                mummyToUpdate.excavationrecorder = mummy.excavationrecorder;
                mummyToUpdate.hair = mummy.hair;

                repo.UpdateMummy(mummyToUpdate);
            }

            return RedirectToAction("Burial_summary");
        }

        
        [HttpGet("_MoreInfoPartial/{mummy_id}")]
        public IActionResult _MoreInfoPartial(long mummy_id)
        {
            var mummy_data = repo.Mummies.SingleOrDefault(x => x.id == mummy_id);
            return PartialView("_MoreInfoPartial", mummy_data);
        }
    }
}