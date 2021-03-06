﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelBedsApp.ViewModel;
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
        public ActionResult Index(FormCollection form)
        {
            SearchCriteriaViewModel searchcriteria = new SearchCriteriaViewModel();
            //When user enter search criteria, page will be validated by its model class data annotations, like required, datatype etc.
            //If all data is valid  , it will put it into Session and take user to wait page.
            searchcriteria.CheckInDate = DateTime.Parse (form["CheckInDate"]);
            searchcriteria.CheckOutDate = DateTime.Parse(form["CheckOutDate"]);
            searchcriteria.DestinationCode = form["DestinationCode"];
            searchcriteria.CountryCode = form["CountryCode"];
            searchcriteria.HotelCodes = form["HotelCodes"];
            searchcriteria.NumberOfRooms = int.Parse (form["NumberOfRooms"]);
            searchcriteria.StarRatingSearch = int.Parse(form["StarRatingSearch"]);
            searchcriteria.RoomOneAdults = int.Parse(form["RoomOneAdults"]);
            searchcriteria.RoomOneChildren = int.Parse(form["RoomOneChildren"]);
            searchcriteria.RoomOneInfants = int.Parse(form["RoomOneInfants"]);
            if (ModelState.IsValid)
            {
                
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
