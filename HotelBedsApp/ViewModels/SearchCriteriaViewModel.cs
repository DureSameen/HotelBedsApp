using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.ComponentModel;
using com.hotelbeds.distribution.hotel_api_sdk.helpers;
namespace HotelBedsApp.ViewModel
{
    public class SearchCriteriaViewModel
    { 
         
       
        public string    DestinationCode{ get; set; }

        public string CountryCode { get; set; }
        public int? Zone { get; set; }
        public string HotelCodes { get; set; }

        [Required(ErrorMessage = "Please enter departure date")]
     
        DateTime CheckIn_dt = System.DateTime.Now;
        //[DataType(DataType.Date)]
        [DisplayName("Check-in")]
        public DateTime CheckInDate { get { return CheckIn_dt; } set { CheckIn_dt = value; } }
        [Required(ErrorMessage = "Please enter return date")]
       
        //[IsDateGreaterThan("CheckInDate")]
        DateTime Checkout_dt = System.DateTime.Now.AddDays(7);
        [DisplayName("Check-out")]
        //[DataType(DataType.Date)]
        public DateTime CheckOutDate { get { return Checkout_dt; } set { Checkout_dt = value; } }
        public int StarRatingSearch { get; set; }
        [Range(1, 3)]
        public int NumberOfRooms { get; set; }
        [Range(1, 9)]
        private int _roomoneadults = 1;
        public int RoomOneAdults { get { return _roomoneadults; } set { _roomoneadults = value; } }
        [Range(0, 4)]
        public int RoomOneChildren { get; set; }
        [Range(0, 4)]
        public int RoomOneInfants { get; set; }

        public int RoomTwoAdults { get; set; }
        public int RoomTwoChildren { get; set; }
        public int RoomTwoInfants { get; set; }

        public int RoomThreeAdults { get; set; }
        public int RoomThreeChildren { get; set; }
        public int RoomThreeInfants { get; set; }

        public List<Passenger> Passengers { get; set; }
         
    }
    public class Passenger
    {
        public RoomDetail.GuestType type { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public int roomId { get; set; }

        public Passenger(com.hotelbeds.distribution.hotel_api_sdk.helpers.RoomDetail.GuestType type, int age, string name, string surname, int roomId)
        { this.type = type;
        this.age = age;
        this.name = name;

        this.surname = surname;
        this.roomId = roomId;
        }
    }
}