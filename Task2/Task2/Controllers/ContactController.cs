using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task2.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult ContactForm()
        {
            return View();
        }

        public ActionResult ShowForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowForm(List<string> path)
        {
            ViewBag.FirstName = Request["name"];
            ViewBag.ID = int.Parse(Request["id"]);

            switch (Request["gender"])
            {
                case "male":
                    ViewBag.Gender = "Male";
                    break;
                case "female":
                    ViewBag.Gender = "Female";
                    break;
            }
            
            ViewBag.selectedGroup = Request["group"];

            ViewBag.Path = path;
            
            return View();
        }

    }
}