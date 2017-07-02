using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OysterCard.Tfl;

namespace OysterCard
{
    class Card
    {
        private int _balance;
        private bool _inFlight;
        private List<Station> _journey;

        public Card()
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
            _inFlight = true;
            _journey.Add(station);
        }

        public List<Station> TouchOut(Station station)
        {
            _inFlight = false;
            _journey.Add(station);
            return _journey;
        }

        public void DeductFare(int fare)
        {
            _balance -= fare;
        }
    }
}
