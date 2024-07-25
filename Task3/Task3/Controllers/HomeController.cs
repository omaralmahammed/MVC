using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult LogIn(FormCollection form)
        {
            string[] emails = { "omar@yahoo.com", "anas@yahoo.com" };
            string[] passwords = { "123456", "987654321" };

            Session["Name"] = form["name"];

            string inputEmail = form["email"];
            string inputPassword = form["password"];

            //foreach (string email in emails)
            //{
            //    if (inputEmail == email)
            //    {
            //        Session["is_login"] = true;
            //        break;
            //    }
            //    else
            //    {
            //        Session["is_login"] = false;

            //    }

            //}


            //foreach (string password in passwords)
            //{
            //    if (password == inputPassword)
            //    {
            //        Session["is_login"] = true;

            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        Session["is_login"] = false;

            //    }
            //}

            foreach (string email in emails)
            {
                foreach (string password in passwords)
                {
                    if (password == inputPassword && inputEmail == email)
                    {
                        Session["is_login"] = true;

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Session["is_login"] = false;
                        ViewBag.Message = "Invalid Input";

                    }
                }

            }



            return View();
        }

        public ActionResult Logout()
        {

            Session["is_login"] = false;
            return RedirectToAction("Index");
        }


    }
}