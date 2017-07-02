using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCard
{
    class TopUpCommand
    {
        private Customer _customer;

        private Tfl _tfl;

        public TopUpCommand(Customer customer, Tfl tfl)
        {
            _customer = customer;
            _tfl = tfl;

            Console.WriteLine("How much would you like to top up?" +
                    "\nYou can top up the following amounts...\n");

            var topUpOptions = _tfl.TopUpOptions();
            foreach (int topUpOption in topUpOptions)
                {
                    Console.WriteLine($"{topUpOption}");
                }
            Console.WriteLine("\n");

            var topUpAmount = _tfl.ValidateInput();
            _customer.TopUp(topUpAmount);
        }

    }
}
