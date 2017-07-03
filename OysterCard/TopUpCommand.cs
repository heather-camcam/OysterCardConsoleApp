using OysterCard.Interfaces;
using System;

namespace OysterCard
{
    class TopUpCommand
    {
        private ICustomer _customer;

        private Tfl _tfl;

        public TopUpCommand(ICustomer customer, Tfl tfl)
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
