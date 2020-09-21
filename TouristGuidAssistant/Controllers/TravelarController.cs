using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuidAssistant.Models;
using Vereyon.Web;
using TouristGuidAssistant.DataContext;

namespace TouristGuidAssistant.Controllers
{
    public class TravelarController : Controller
    {
        // GET: Travelar
        TouristDbContext db = new TouristDbContext();
        public ActionResult Index()
        {
            if(Session["guideT"]==null)
            {
                return RedirectToAction("LoginForm", "Home");
            }
          
            var travler = db.Registrations.ToList();
            foreach(var item in travler)
            {
                if(item.NID== Session["guideT"].ToString())
                {
                    ViewBag.TravlerImage = item.Image;
                    ViewBag.TravelarName = item.UserName;
                    ViewBag.TravelarEmail = item.Email;
                    ViewBag.TravelarPhone = item.Phone;
                    ViewBag.TravelarAddress = item.Address;
                    ViewBag.TravelarGender = item.Gender;

                    return View(db.Events.ToList());

                }
            }
                return View();
        }
        [HttpPost]
        public ActionResult Index(BookingInfo bookinginfo)
        {
            if(ModelState.IsValid)
            {
                db.BookingInfo.Add(bookinginfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Hireguide()
        {
            if (Session["guideT"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }
            var travler = db.Registrations.ToList();
            foreach (var item in travler)
            {
                if (item.NID == Session["guideT"].ToString())
                {
                    ViewBag.TravlerImage = item.Image;
                    ViewBag.TravlerName = item.UserName;
                    ViewBag.Phone = item.Phone;
                    ViewBag.Address = item.Address;
              
                    return View();

                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Hireguide(HireGuide hireguide)
        {
            if(ModelState.IsValid)
            {
                db.HireGuides.Add(hireguide);
                db.SaveChanges();
                FlashMessage.Confirmation("Hire Guide request successfull");
                return RedirectToAction("Hireguide");
            }    
            return RedirectToAction("Hireguide");
        }
    }
}