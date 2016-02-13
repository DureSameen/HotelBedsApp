﻿using System;
using System.Collections.Generic;
using com.hotelbeds.distribution.hotel_api_model.auto.model;

namespace com.hotelbeds.distribution.hotel_api_model.auto.messages
{
    public class CheckRateRQ : AbstractGenericRequest
    {
        public bool upselling { get; set; }
        public List<BookingRoom> rooms { get; set; }

        public void Validate()
        {
            if ( rooms == null )
                throw new ArgumentException("Rooms list can't be null");

            for (int r = 0; r < rooms.Count; r++)
            {
                if (String.IsNullOrEmpty(rooms[r].rateKey))
                    throw new ArgumentException("RateKey Room can't be null or empty");
            }
        }
    }
}
