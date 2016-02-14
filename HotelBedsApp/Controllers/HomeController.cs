using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelBedsApp.ViewModel;
using com.hotelbeds.distribution.hotel_api_sdk.helpers;
namespace HotelBedsApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View(new SearchCriteriaViewModel());
        }
        string SetServerTime()
        {
            DateTime dt = System.DateTime.Now.AddDays(7);
            return dt.Day.ToString("00") + "/" + dt.Month.ToString("00") + "/" + dt.Year;
        }
        string SetCurrentDateTime()
        {
            DateTime dt = System.DateTime.Now;
            return dt.Day.ToString("00") + "/" + dt.Month.ToString("00") + "/" + dt.Year;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Index(SearchCriteriaViewModel searchcriteria)
        {
              
            if (ModelState.IsValid)
            { searchcriteria.Passengers=new List<Passenger> ();
                for (int i = 0; i < searchcriteria.RoomOneAdults ; i++)
                {
                    searchcriteria.Passengers.Add(new Passenger(RoomDetail.GuestType.ADULT, 30, "", "", 1));
                
               
                }
                for (int i = 0; i < searchcriteria.RoomOneChildren; i++)
                {
                    searchcriteria.Passengers.Add(new Passenger(RoomDetail.GuestType.CHILD, 11, "", "", 1));


                }
                for (int i = 0; i < searchcriteria.RoomOneInfants; i++)
                {
                    searchcriteria.Passengers.Add(new Passenger(RoomDetail.GuestType.CHILD, 2, "", "", 1));


                }

                Session["SearchCriteria"] = searchcriteria;


                return RedirectToAction("Index", "result");
            }

            else
            {   //if page is not validated then it will remain on same view.
                
                return View(searchcriteria);
            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
