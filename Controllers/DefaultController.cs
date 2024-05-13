using EmpAuthentication130524.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmpAuthentication130524.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        // GET: Default
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Users = @"DESKTOP-E43S078\Administrator")]
        [Authorize(Roles="Emp")]
        public ActionResult abcd()
        {
            return View();
        }
        //[Authorize(Users = "DESKTOP-E43S078\\temp,DESKTOP-E43S078\\Administrator")]
        [Authorize(Roles="Admin,Emp")]
        public ActionResult xyz()
        {
            return View();
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
        [AllowAnonymous]
        public ActionResult login()
        {
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult login(tblLogin lg)
        {
            DB_EMP_100524Entities dbContext = new DB_EMP_100524Entities();

            var log=dbContext.tblLogins.FirstOrDefault(x=>x.userId == lg.userId && x.password==lg.password);
            if (log==null)
            {
                ViewBag.error = "Invalid user id or Password!!!";
                return View();
            }
            else
            {
                //if (lg.saveOrNot==true)
                //{
                //    FormsAuthentication.SetAuthCookie(lg.userId, true);
                //}
                //else
                {
                    FormsAuthentication.SetAuthCookie(lg.userId, false);
                }
                return RedirectToAction("Home");
            }

        }
    }
}