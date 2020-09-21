using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using TouristGuidAssistant.Models;
using TouristGuidAssistant.DataContext;
using Vereyon.Web;
using System.IO;

namespace TouristGuidAssistant.Controllers
{
    public class HomeController : Controller
    {
        TouristDbContext db = new TouristDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

       
        public ActionResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginForm(Users users)
        {
            var registration1 = db.Registrations.Where(x => x.Email == users.Email && x.NID == users.NID && x.Password == users.Password && x.UserType == "Travelar").FirstOrDefault();
            var registration2 = db.Registrations.Where(x => x.Email == users.Email && x.NID == users.NID && x.Password == users.Password && x.UserType == "Tourist Guide").FirstOrDefault();
            var registration3 = db.Registrations.Where(x => x.Email == users.Email && x.NID == users.NID && x.Password == users.Password && x.UserType == "Tour Organizer").FirstOrDefault();
            var registration4 = db.Registrations.Where(x => x.Email == users.Email && x.NID == users.NID && x.Password == users.Password && x.UserType == "Admin").FirstOrDefault();
            if (registration1 != null)
            {
                Session["guideT"] = users.NID;
                return RedirectToAction("Index","Travelar");
            }
            if (registration2 != null)
            {
                Session["guideTG"] = users.NID;
                return RedirectToAction("Index","TravelGuide");
            }
            if (registration3 != null)
            {
                Session["guideTO"] = users.NID;
                return RedirectToAction("UserProfile", "TourOrganizer");
            }
            if (registration4 != null)
            {
                Session["admin"] = users.NID;
                return RedirectToAction("EventStatus","Admin");
            }
            FlashMessage.Confirmation("User Name or NID or Password doesn't match!");
            return RedirectToAction("LoginForm");
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Users usersObject,HttpPostedFileBase Image)
        {
            string path = uploadImage(Image);
            if (ModelState.IsValid)
            {
                usersObject.Image = path;
                db.Registrations.Add(usersObject);
                db.SaveChanges();
                FlashMessage.Confirmation("Registration successfully");
                return RedirectToAction("Registration");

            }

            return RedirectToAction("Registration");

        }


        public string uploadImage(HttpPostedFileBase Image)
        {
            string path = "";

            if (Image != null && Image.ContentLength > 0)
            {
                string extension = Path.GetExtension(Image.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("/content/image") + Path.GetFileName(Image.FileName));
                        Image.SaveAs(path);
                        path = "/content/image" + Path.GetFileName(Image.FileName);

                    }

                    catch(Exception)
                    {
                        path = "-1";
                    }


                }

                else
                {
                    Response.Write("<script>alert('only jpg,jpeg & png file acceptable.')</script>");
                }

            }

            return path; 
        }

        public ActionResult Contract()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contract(Contract contact)
        {
            if(ModelState.IsValid)
            {
                db.Contract.Add(contact);
                db.SaveChanges();
                FlashMessage.Confirmation("Message submition successfully");
                return RedirectToAction("Contract");

            }
            return RedirectToAction("Contract");
        }

        public ActionResult Signout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


    }
}