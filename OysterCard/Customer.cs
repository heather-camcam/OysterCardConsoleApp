using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OysterCard.Tfl;

namespace OysterCard
{
    class Customer
    {
        private Card _card;
            
        public Customer()
        {
            _card = new Card();
        }

        public void TopUp(int amount)
        {
            _card.TopUp(amount);
        }

        public void TouchIn(Station station)
        {
            _card.TouchIn(station);
        }

        public List<Station> TouchOut(Station station)
        {
           return _card.TouchOut(station);
        }

        public void DeductFare(int fare)
        {
            _card.DeductFare(fare);
        }
    }
}
