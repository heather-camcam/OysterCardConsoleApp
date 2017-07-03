using OysterCard.Interfaces;
using System;
using System.Collections.Generic;
using static OysterCard.Tfl;

namespace OysterCard
{
    class Customer : ICustomer
    {
        private int _balance;
        private bool _inFlight;
        private List<Station> _journey;

        public int Balance { get => _balance; set => _balance = value; }
        public bool InFlight { get => _inFlight; set => _inFlight = value; }

        public Customer()
        {
            _balance = 0;
            _journey = new List<Station>();
        }

        public void TopUp(int amount)
        {
            _balance += amount;
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
            _balance -= fare;
        }
    }
}
