using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace day3.Controllers
{
    public class DataController : Controller
    {

        public ActionResult InputInfromation(string email, string password, string firstName, string lastName)
        {
            ViewBag.FirstName = firstName;
            ViewBag.LasttName = lastName;
            ViewBag.Email = email;
            ViewBag.Password = password;

            return View();
        }


        public ActionResult ShowStudents(string student1, string student2, string student3)
        {
            ViewBag.student1 = student1;
            ViewBag.student2 = student2;
            ViewBag.student3 = student3;

            return View();
        }

    }
}