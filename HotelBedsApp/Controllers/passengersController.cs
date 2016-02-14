using com.hotelbeds.distribution.hotel_api_model.auto.messages;
using com.hotelbeds.distribution.hotel_api_sdk;
using com.hotelbeds.distribution.hotel_api_sdk.helpers;
using HotelBedsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 

namespace HotelBedsApp.Controllers
{
    public class passengersController : Controller
    {
        //
        // GET: /passengers/

        public ActionResult Index()
        {
           
            SearchCriteriaViewModel searchcriteria = (SearchCriteriaViewModel)Session["SearchCriteria"];
            return View(searchcriteria);
        }
        [HttpPost]
        public ActionResult Index(FormCollection form,SearchCriteriaViewModel searchcriteria )
        {
            try
            {
                string[] type = form["pas.type"].Split(',');
                string[] age = form["pas.age"].Split(',');
                string[] name = form["pas.name"].Split(',');
                string[] surname = form["pas.surname"].Split(',');
                string[] roomId = form["pas.roomId"].Split(',');

                HotelApiClient client = new HotelApiClient();
                ConfirmRoom confirmRoom = new ConfirmRoom();
                confirmRoom.details = new List<RoomDetail>();
                for (int i = 0; i < type.Count(); i++)
                    confirmRoom.details.Add(new RoomDetail((com.hotelbeds.distribution.hotel_api_sdk.helpers.RoomDetail.GuestType)Enum.Parse(typeof(com.hotelbeds.distribution.hotel_api_sdk.helpers.RoomDetail.GuestType), type[i]), int.Parse(age[i]), name[i], surname[i], int.Parse(roomId[i])));

                string rateKey = (string)Session["ratekey"];
                BookingCheck bookingCheck = new BookingCheck();
                bookingCheck.addRoom(rateKey, confirmRoom);
                CheckRateRQ checkRateRQ = bookingCheck.toCheckRateRQ();

                if (checkRateRQ != null)
                {
                    CheckRateRS responseRate = client.doCheck(checkRateRQ);
                    if (responseRate != null && responseRate.error == null)
                    {
                        com.hotelbeds.distribution.hotel_api_sdk.helpers.Booking booking = new com.hotelbeds.distribution.hotel_api_sdk.helpers.Booking();
                        booking.createHolder("Rosetta", "Pruebas");
                        booking.clientReference = "SDK Test";
                        booking.remark = "***SDK***TESTING";

                        booking.addRoom(rateKey, confirmRoom);
                        BookingRQ bookingRQ = booking.toBookingRQ();
                        if (bookingRQ != null)
                        {
                            BookingRS responseBooking = client.confirm(bookingRQ);

                            if (responseBooking != null && responseBooking.error == null && responseBooking.booking != null)

                                ViewBag.BookingRef = responseBooking.booking.reference;


                        }
                        else
                        {
                            if (responseRate.error != null)
                            {
                                ViewBag.Error = responseRate.error.message;


                            }
                        }
                    }
                }


                return View(searchcriteria);
            }
            catch (Exception exp)
            { return Content(exp.Message); }
        }
    }

                    }