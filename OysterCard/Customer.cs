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
        private List<List<Station>> _journeyHistory;

        public int Balance { get => _balance; set => _balance = value; }
        public bool InFlight { get => _inFlight; set => _inFlight = value; }
        public List<List<Station>> JourneyHistory => _journeyHistory;
        public List<Station> Journey { get => _journey; set => _journey = value; }

        public Customer()
        {
            _balance = 0;
            _journey = new List<Station>();
            _journeyHistory = new List<List<Station>>();
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
            _journeyHistory.Add(_journey);

            return _journey;
        }

        public void DeductFare(int fare)
        {
            _balance -= fare;
        }
    }
}
