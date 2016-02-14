using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.ComponentModel;
namespace HotelBedsApp.ViewModel
{
    public class SearchCriteriaViewModel
    { 
         
       
        public string    DestinationCode{ get; set; }

        public string CountryCode { get; set; }

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


         
    }
}