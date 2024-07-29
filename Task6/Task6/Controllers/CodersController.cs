using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task6.Models;

namespace Task6.Controllers
{
    public class CodersController : Controller
    {

        WebsiteEntities db = new WebsiteEntities();
        // GET: Coders
        public ActionResult Index()
        {
            return View();
        }

        //Regester
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UsersID,UserName,UserEmail,UserPassword,UserImage, ConfirmPassword")] USER uSER, string confirmpassowrd)
        {
            if (ModelState.IsValid && uSER.UserPassword == confirmpassowrd)
            {
                db.USERS.Add(uSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSER);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(USER uSER)
        {
            var checkInputs = db.USERS.Where(model => model.UserEmail == uSER.UserEmail && model.UserPassword == uSER.UserPassword).FirstOrDefault();

            Session["UserID"] = checkInputs.UsersID;
            

            if (checkInputs != null) { 
               return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return RedirectToAction("Index");
        }


        public ActionResult Profile()
        {
             var userID = (int)Session["UserID"];
             var user = db.USERS.Find(userID);
             return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(USER uSER, HttpPostedFileBase upload)
        {
            

            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                if (!Directory.Exists(Server.MapPath("~/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/"));
                }

                upload.SaveAs(path);
                uSER.UserImage = fileName;
            }

            db.Entry(uSER).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ResetPasswordt()
        {
            var userID = (int)Session["UserID"];
            var user = db.USERS.Find(userID);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPasswordt(string currentPassword, string newPassword, string confirmNewPassword)
        {
            var userID = (int)Session["UserID"];
            var user = db.USERS.Find(userID);

            if (currentPassword == user.UserPassword)
            {
                if (newPassword == confirmNewPassword)
                {
                    user.UserPassword = newPassword;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Profile");
                }
                else
                {
                    ViewBag.Message = "New Password does not match Confirm Password!";
                    return View(user);
                }
            }
            else
            {
                ViewBag.Message = "Current Password is incorrect!";
                return View(user);
            }
        }
    }
}