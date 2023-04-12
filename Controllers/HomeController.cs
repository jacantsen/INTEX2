using INTEX2.Models;
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

        [HttpGet("{mummy_id}")]
        public IActionResult Edit_burialmain(long mummy_id)
        {
            var mummy_data = repo.Mummies.SingleOrDefault(x => x.id == mummy_id);
            return View("Edit_burialmain",mummy_data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit_burialmain(long id , [Bind("fieldbookexcavationyear, fieldbookpage, dataexpertinitials, squarenorthsouth, northsouth, squareeastwest, eastwest, area, burialnumber, westtohead, westtofeet, southtohead, southtofeet, depth, length, headdirection, preservation, wrapping, adultsubadult, sex, ageatdeath, haircolor, samplescollected, goods, facebundles, text, burialid, photos, dateofexcavation, shaftnumber, clusternumber, burialmaterials, excavationrecorder, hair")] Mummy mummy)
        {
            //var mummyToUpdate = repo.GetMummyById(id);
            var mummyToUpdate = repo.Mummies.SingleOrDefault(x => x.id == id);
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


    }
}
