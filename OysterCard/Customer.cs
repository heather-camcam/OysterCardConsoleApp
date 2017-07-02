using System;
using System.Collections.Generic;
using static OysterCard.Tfl;

namespace OysterCard
{
    class Customer
    {
        public int Balance;
        public bool InFlight;
        private List<Station> _journey;

        public Customer()
        {
            Balance = 0;
            _journey = new List<Station>();
        }

        public void TopUp(int amount)
        {
            Balance += amount;
        }

        public void TouchIn(Station station)
        {
            InFlight = true;
            _journey.Add(station);
        }

        public List<Station> TouchOut(Station station)
        {
            InFlight = false;
            _journey.Add(station);
            return _journey;
        }

        public void DeductFare(int fare)
        {
            Balance -= fare;
        }
    }
}
