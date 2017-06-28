using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCard
{
    class Card
    {
        private int _balance;

        public Card()
        {
            _balance = 0;
        }

        public void TopUp(int amount)
        {
            _balance += amount;
        }
    }
}
