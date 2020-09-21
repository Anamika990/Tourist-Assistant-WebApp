using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuidAssistant.Models;
using TouristGuidAssistant.DataContext;
using Vereyon.Web;
using System.IO;

namespace TouristGuidAssistant.Controllers
{
    public class TourOrganizerController : Controller
    {
        // GET: TourOrganizer
        TouristDbContext db = new TouristDbContext();
        public ActionResult UserProfile()
        {
            if (Session["guideTO"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }

            var Userinfo = db.Registrations.ToList();
           
            foreach (var item in Userinfo)
            {
                if(item.NID == Session["guideTO"].ToString())
                {
                    ViewBag.name = item.UserName;
                    ViewBag.email = item.Email;
                    ViewBag.phone = item.Phone;
                    ViewBag.image = item.Image;
                    ViewBag.nid = item.NID;
                    ViewBag.groupName = item.GroupName;

                }
            }
            return View(db.BookingInfo.ToList());
        }
        public ActionResult EventCreate()
        {
            if (Session["guideTO"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }
            var user = db.Registrations.ToList();
            foreach(var item in user)
            {
                if(item.NID== Session["guideTO"].ToString())
                {
                   ViewBag.groupName= item.GroupName;
                    return View();
                }
            }
            return View();
        }
         [HttpPost]
        public ActionResult EventCreate(Events events, HttpPostedFileBase Image)
        {
            if(ModelState.IsValid)
            {
                var path = uploadImage(Image);
                events.Image = path;
                events.Status = "Not Approved";
                db.Events.Add(events);
                db.SaveChanges();
                FlashMessage.Confirmation("Event Submission Successfull");
                return RedirectToAction("EventCreate");
            }
            return RedirectToAction("EventCreate");
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

                    catch (Exception)
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


        public ActionResult Help()
        {
            if (Session["guideTO"] == null)
            {
                return RedirectToAction("LoginForm", "Home");
            }
            return View();
        }
    }
}
