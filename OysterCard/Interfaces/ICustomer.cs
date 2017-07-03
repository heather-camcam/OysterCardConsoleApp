﻿using System.Collections.Generic;
using static OysterCard.Tfl;

namespace OysterCard.Interfaces
{
    interface ICustomer
    {
        int Balance { get; set; }

        bool InFlight { get; set; }

        void TopUp(int amount);

        void TouchIn(Station station);

        List<Station> TouchOut(Station station);

        void DeductFare(int fare);

    }
}
