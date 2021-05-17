using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP8_MVC.Models;

namespace TP8_MVC.Controllers
{
    public class PublicWebApiController : Controller
    {
        public ActionResult Index()
        {
            var url = $"https://api.nasa.gov/planetary/apod?api_key=Jff0hSW2l1yuzR2D2HFByuI1prwjVdSI3cb7KEMe";
            //En caso de que no ande la url:
            //var url = $"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY"

            try
            {
                var response = GetWebAPiResponse(url);
                var nasaApi = JsonConvert.DeserializeObject<PublicWebApiView>(response);
                return View(nasaApi);
            }
            catch (WebException ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("Index", "Error");
            }
        }

        private string GetWebAPiResponse(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        var content = sr.ReadToEnd();
                        return content;
                    }
                }
            }
        }
    }
}