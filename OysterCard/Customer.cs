using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
