using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
using System.Diagnostics;
using com.hotelbeds.distribution.hotel_api_sdk.helpers;
using com.hotelbeds.distribution.hotel_api_model.auto.messages;
using HotelBedsApp.ViewModel;
using com.hotelbeds.distribution.hotel_api_sdk;
namespace HotelBedsApp.Controllers
{
    public class resultController : Controller
    {
        //
        // GET: /result/

        public ActionResult Index()
        {
            try
            {
                HotelApiClient client = new HotelApiClient();
                StatusRS status = client.status();

                SearchCriteriaViewModel searchcriteria = (SearchCriteriaViewModel)Session["SearchCriteria"];

                List<Tuple<string, string>> param;


                Availability avail = new Availability();
                avail.checkIn = searchcriteria.CheckInDate;
                avail.checkOut = searchcriteria.CheckOutDate;
                avail.destination = searchcriteria.DestinationCode;
                avail.zone = searchcriteria.Zone;
                // avail.zone = 90;
                // avail.language = "CAS";
                if (searchcriteria.NumberOfRooms >= 1)
                {
                    AvailRoom room = new AvailRoom();
                    room.adults = searchcriteria.RoomOneAdults;
                    room.children = searchcriteria.RoomOneChildren + searchcriteria.RoomOneInfants;
                    room.details = new List<RoomDetail>();
                    for (int i = 0; i < searchcriteria.RoomOneAdults; i++)
                    { room.adultOf(30); }

                    for (int i = 0; i < searchcriteria.RoomOneChildren; i++)
                    { room.childOf(11); }

                    for (int i = 0; i < searchcriteria.RoomOneInfants; i++)
                    { room.childOf(2); }

                    //room.childOf(4);                
                    avail.rooms.Add(room);
                }
                avail.payed = Availability.Pay.AT_WEB;
                //avail.ofTypes = new HashSet<hotel_api_model.auto.common.SimpleTypes.AccommodationType>();
                //avail.ofTypes.Add(hotel_api_model.auto.common.SimpleTypes.AccommodationType.HOTEL);
                //avail.ofTypes.Add(hotel_api_model.auto.common.SimpleTypes.AccommodationType.APARTMENT);

                avail.minCategory = searchcriteria.StarRatingSearch;
                //avail.limitHotelsTo = 10;
                //avail.numberOfTripAdvisorReviewsHigherThan = 2;
                //avail.tripAdvisorScoreHigherThan = 2

                //avail.matchingKeywords = new HashSet<int>();
                //avail.matchingKeywords.Add(34);
                //avail.matchingKeywords.Add(81);
                //avail.keywordsMatcher = Availability.Matcher.ALL;

                //avail.includeHotels = new List<int>();
                //avail.includeHotels.Add(111637);
                //avail.includeHotels.Add(2818);
                //avail.includeHotels.Add(138465);
                //avail.includeHotels.Add(164471);

                //avail.excludeHotels = new List<int>();
                //avail.excludeHotels.Add(187013);
                //avail.excludeHotels.Add(188330);

                //avail.useGiataCodes = false;
                //avail.limitHotelsTo = 250;
                //avail.limitRoomsPerHotelTo = 5;
                //avail.limitRatesPerRoomTo = 5;
                //avail.ratesHigherThan = 50;
                //avail.ratesLowerThan = 350;

                //avail.hbScoreHigherThan = 3;
                //avail.hbScoreLowerThan = 5;
                //avail.numberOfHBReviewsHigherThan = 50;

                //avail.tripAdvisorScoreHigherThan = 1;
                //avail.tripAdvisorScoreLowerThan = 4;
                //avail.numberOfHBReviewsHigherThan = 50;

                //avail.withinThis = new Availability.Circle() { latitude = 2.646633999999949, longitude = 39.57119, radiusInKilometers = 50 };
                //avail.withinThis = new Availability.Square() { northEastLatitude = 45.37680856570233, northEastLongitude = -2.021484375, southWestLatitude = 38.548165423046584, southWestLongitude = 8.658203125 };

                //avail.includeBoards = new List<string>();
                //avail.includeBoards.Add("R0-E10");
                //avail.includeBoards.Add("BB-E10");
                //avail.excludeBoards = new List<string>();
                //avail.excludeBoards.Add("RO");

                //avail.includeRoomCodes = new List<string>();
                //avail.includeRoomCodes.Add("DBL.ST");
                //avail.includeRoomCodes.Add("DBL.SU");
                ////avail.includeRoomCodes.AddRange(new string[]{ "DBL.ST", "DBL.SU" });
                //avail.excludeRoomCodes = new List<string>();
                //avail.excludeRoomCodes.Add("TPL.ST");

                AvailabilityRQ availabilityRQ = avail.toAvailabilityRQ();
                if (availabilityRQ == null)
                    throw new Exception("Availability RQ can't be null", new ArgumentNullException());
                Stopwatch sw = new Stopwatch();
                sw.Start();
                AvailabilityRS responseAvail = client.doAvailability(availabilityRQ);
                sw.Stop();
                ViewBag.TimeTaken = sw.Elapsed.Seconds;


                //  request.PathToSaveXml = Server.MapPath("~");




                if (responseAvail != null && responseAvail.hotels != null && responseAvail.hotels.hotels != null && responseAvail.hotels.hotels.Count > 0)
                {

                    Session["ResultedHotels"] = responseAvail.hotels;

                }

                return View(responseAvail);
            }
            catch (Exception exp)
            { return Content(exp.Message); }
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            
            string  ratekey = form[1] ;
          //  List<Hotel> hotels = (List<Hotel>)Session["ResultedHotels"];
            // Hotel selectedhotel=null;
          
            //foreach (string selectedroomtype in arrselectedroomtypes)
            //{
            //    string[] arrselectedroomtype = selectedroomtype.Split('-');
              
            //    if (selectedhotel == null)
            //    {
            //        hotelid = arrselectedroomtype[0];
            //        selectedhotel= hotels.Where (hotel=> hotel.HotelID ==hotelid ).FirstOrDefault (); 
                                    
            //       }

            //    int roomid = int.Parse (arrselectedroomtype[1]);
            //    string roomtypeid =  arrselectedroomtype[2] ;
                
            //     var bookroomtype= (from room in selectedhotel.Rooms 
            //                      from roomtype in room.RoomTypes 
            //                      where room.RoomCount == roomid && roomtype.Id == roomtypeid 
            //                      select roomtype).FirstOrDefault ();
            //     selectedhotel.Rooms[roomid - 1].BookRoomTypes = new List<RoomType>();
            //     selectedhotel.Rooms[roomid - 1].BookRoomTypes.Add(bookroomtype);
            
            //}
            Session["ratekey"] = ratekey;

            return RedirectToAction("Index", "passengers");
        }
    }
}
