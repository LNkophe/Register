using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Login.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        OurDbContext _Context;
        public HomeController(OurDbContext context)
        {
            _Context = context;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Log log)
        {
            var query = (from t in _Context.Login where t.Username == log.Username 
                         && t.Password == log.Password select t);
            if (query != null)
            {
                return RedirectToAction("Register");
            }
            else
            {
                ViewBag.Message = "Username or password is incorrect";
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Log lg)
        {
            if (ModelState.IsValid)
            { 
                _Context.Login.Add(lg);
                _Context.SaveChanges();
            }
            else
                throw new Exception();
            return RedirectToAction("Login");
        }
    }
}
