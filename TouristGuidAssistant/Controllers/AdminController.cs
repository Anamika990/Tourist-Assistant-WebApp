using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuidAssistant.Models;
using TouristGuidAssistant.DataContext;
using System.Net;
using System.Data.Entity;

namespace TouristGuidAssistant.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        TouristDbContext db = new TouristDbContext();
        public ActionResult Index()
        {
            if(Session["admin"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }

            var eventStatus = db.Events.ToList();
            var count = 0;
            foreach (var item in eventStatus)
            {
                if (item.Status == "Not Approved")
                {
                    count++;
                }

            }
            ViewBag.status = count;
            return View();
        }

        public ActionResult UserInformation()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }

            var eventStatus = db.Events.ToList();
            var count = 0;
            foreach (var item in eventStatus)
            {
                if (item.Status == "Not Approved")
                {
                    count++;
                }

            }
            ViewBag.status = count;
            return View(db.Registrations.ToList());
        }

        public ActionResult EventStatus()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }
            var eventStatus = db.Events.ToList();
            var count = 0;
            foreach(var item in eventStatus)
            {
                if(item.Status== "Not Approved")
                {
                    count++;
                }

            }
            ViewBag.status = count;
            return View(db.Events.ToList());
        }

       public ActionResult Approved(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);

            var eventStatus = db.Events.ToList();
            var count = 0;
            foreach (var item in eventStatus)
            {
                if (item.Status == "Not Approved")
                {
                    count++;
                }

            }
            ViewBag.status = count;



            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approved(Events events)
        {
            if (ModelState.IsValid)
            {
                events.Status = "Approved";
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EventStatus");
            }
            return View(events);
        }
        public ActionResult LiveChat()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }

            return View(db.Contract.ToList());
        }
       
    }
}