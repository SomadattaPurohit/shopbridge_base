using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shop_Bridge.DataAccess;
using Shop_Bridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shop_Bridge.Controllers
{
    [TypeFilter(typeof(FiltersController))]
    public class AdminController : Controller
    {
        private readonly DBInventoryClass _dal;
        
        
        public AdminController(DBInventoryClass dal)
        {
            _dal = dal; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_dal.inventory.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(500);
            }
            Inventory inventory = _dal.inventory.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }


        
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _dal.inventory.Add(inventory);
                await _dal.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }




        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(500);
            }
            Inventory inventory = _dal.inventory.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _dal.Entry(inventory).State = EntityState.Modified;
                _dal.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(500);
            }
            Inventory inventory = _dal.inventory.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }


      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = _dal.inventory.Find(id);
            _dal.inventory.Remove(inventory);
            _dal.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dal.Dispose();
            }
            base.Dispose(disposing);
        }




    }
}
