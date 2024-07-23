using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace day3.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult StudentsName()
        {
            return View();
        }
        /// ////////////////////////////////////
       

        [HttpGet]
        public ActionResult Information()
        {
            return View();
        }

        //////////////////// USING Parameter ////////////////////


        [HttpPost]
        public ActionResult ShowInformation(string firstName, string lastName, string city, string email, string feedback)
        {
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.City = city;
            ViewBag.Email = email;
            ViewBag.Feedback = feedback;

            return View();
        }




        //////////////////// USING Request ////////////////////


        //[HttpPost]
        //public ActionResult ShowInformation()
        //{
        //    ViewBag.FirstName = Request["firstName"];
        //    ViewBag.LastName = Request["lastName"];
        //    ViewBag.City = Request["city"];
        //    ViewBag.Email = Request["email"];
        //    ViewBag.Feedback = Request["feedback"];

        //    return View();
        //}



        //////////////////// USING FormCollection ////////////////////

        //[HttpPost]
        //public ActionResult ShowInformation(FormCollection form)
        //{
        //    ViewBag.FirstName = form["firstName"];
        //    ViewBag.LastName = form["lastName"];
        //    ViewBag.City = form["city"];
        //    ViewBag.Email = form["email"];
        //    ViewBag.Feedback = form["feedback"];

        //    return View();
        //}



    }
}