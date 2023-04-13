using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;
using System.Collections.Generic;
using INTEX2.Models;
using System.Linq;

namespace INTEX2.Controllers
{
    public class InferenceController : Controller
    {
        private InferenceSession _session;

        public InferenceController(InferenceSession session)
        {
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MummyData data)
        {
            if (data.adultsubadult_A == 1)
            {
                data.adultsubadult_C = 0;
            }
            else
            {
                data.adultsubadult_C = 1;
            }

            if(data.wrapping_B == 1)
            {
               
                data.wrapping_H = 0;
                data.wrapping_W = 0;
            }
            else if (data.wrapping_B == 2)
            {
                data.wrapping_B = 0;
                data.wrapping_H = 1;
                data.wrapping_W = 0;
            }
            else
            {
                data.wrapping_B = 0;
                data.wrapping_H = 0;
                data.wrapping_W = 1;
            }

            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });

            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new Prediction { PredictedValue = score.First() };
            result.Dispose();
            if (prediction.PredictedValue == "W")
            {
                ViewBag.prediction = "The Head Direction is predicted to face west";
            }
            else
            {
                ViewBag.prediction = "The Head Direction is predicted to face east";
            }
            return View();
        }
    }
}
