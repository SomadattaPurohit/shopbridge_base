using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_Bridge.DataAccess;
using Shop_Bridge.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shop_Bridge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContextClass _dal;
        private readonly DBInventoryClass _inv;

        public HomeController(ILogger<HomeController> logger, DBContextClass dal, DBInventoryClass inv)
        {
            _logger = logger;
            _dal = dal;
            _inv = inv;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListInventory()
        {
            return View(_inv.inventory.ToList());
        }
 

        public ActionResult LogOut()
        { 
            HttpContext.Session.Clear();
            //HttpContext.Session.Abandon();
            return RedirectToAction("Index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(User user)
        {
             
            try
                {

                if (ModelState.IsValid)
                {
                    int len = Request.Form["user_name"].ToString().Length;
                    Random r = new Random();
                    int k = r.Next(200, 5000);

                    user.user_username = Request.Form["user_name"].ToString().Substring(0, 3) + Request.Form["user_name"].ToString().Substring(len - 3, 2) + Convert.ToString(k);

                    if (Request.Form["role"].ToString().Equals("1"))
                    {
                        user.user_role = "Admin";
                    }
                    else if (Request.Form["role"].ToString().Equals("2"))
                    {
                        user.user_role = "ShopKeeper";
                    }
                    else
                    {
                        user.user_role = "Standard";
                    }

                    _dal.Add(user);  // in memory
                    await _dal.SaveChangesAsync(); // physically

                    HttpContext.Session.SetString("name", user.user_name);
                    HttpContext.Session.SetString("email", user.user_mail);
                    HttpContext.Session.SetString("role", user.user_role);
                    HttpContext.Session.SetString("username", user.user_username);

                    //ViewBag.username = HttpContext.Session.GetString("name");

                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));

                    var sessionUsers = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
                    return RedirectToAction("Index");

                }
                else
                {
                    Equals("Invalid Request");
                    return Content("InValid Data");
                }

                }
                catch (Exception e)
                {
                    throw e;
                } 
            } 


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        //public async Task<IActionResult> Login(User model)
        public IActionResult Login(login model)
        {
            try
            {
                var obj = _dal.user.Where(x => x.user_mail.Equals(model.user_mail) && x.user_password.Equals(model.user_password)).FirstOrDefault();
                if (obj != null)
                {
                    HttpContext.Session.SetString("name", obj.user_name);
                    HttpContext.Session.SetString("email", obj.user_mail);
                    HttpContext.Session.SetString("role", obj.user_role);
                    HttpContext.Session.SetString("username", obj.user_username);//
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(obj));
                    //var sessionUsers = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
                    return RedirectToAction("Index");
                }
                else
                {
                    Equals("Invalid Request");
                    return Content("InValid Data");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
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
    }
}
