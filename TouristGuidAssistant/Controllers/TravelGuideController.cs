using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuidAssistant.DataContext;

namespace TouristGuidAssistant.Controllers
{
    public class TravelGuideController : Controller
    {
        // GET: TravelGuide
        TouristDbContext db = new TouristDbContext();
        public ActionResult Index()
        {
            if (Session["guideTG"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }
            return View();
        }
        public ActionResult TravelGuideProfile()
        {
            if (Session["guideTG"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }
            var travelGuide = db.Registrations.ToList();
            foreach(var tGuide in travelGuide )
            {
                if(tGuide.NID == Session["guideTG"].ToString())
                {
                    ViewBag.Name=  tGuide.UserName;
                    ViewBag.image = tGuide.Image;
                    ViewBag.phone = tGuide.Phone;
                    ViewBag.adress = tGuide.Address;
                    ViewBag.Email = tGuide.Email;
                    ViewBag.gender = tGuide.Gender;

                }
            }
            return View();
        }
        public ActionResult TakeTrip()
        {
            if (Session["guideTG"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }
            
            return View(db.HireGuides.ToList());
        }
    }
}