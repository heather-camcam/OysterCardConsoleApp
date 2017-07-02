using System;
using static OysterCard.Tfl;

namespace OysterCard
{
    class TouchInCommand
    {
        private Tfl _tfl;
        private Customer _customer;

        public TouchInCommand(Customer customer, Tfl tfl)
        {
            _customer = customer;
            _tfl = tfl;

            if(_customer.Balance < 1)
                Console.WriteLine($"Your balance is only £{_customer.Balance}. Please top up.\n");

            else if (_customer.InFlight)
                Console.WriteLine("You must touch out of your current journey before beginning a new one.\n");

            else
            {
                Console.WriteLine("Select a station...\n");

                foreach (Station station in Enum.GetValues(typeof(Station)))
                {
                    Console.WriteLine($"{station}");
                }
                Console.WriteLine("\n");

                var stationName = _tfl.TouchIn();

                _customer.TouchIn(stationName);
            }
            
        }
    }
}
