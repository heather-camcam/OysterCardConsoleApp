using OysterCard.Interfaces;
using System;
using System.Linq;
using static OysterCard.Tfl;

namespace OysterCard
{
    class TouchInCommand
    {
        private Tfl _tfl;
        private ICustomer _customer;

        public TouchInCommand(ICustomer customer, Tfl tfl)
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

                PrintStationList();

                var stationName = _tfl.TouchIn();

                if(stationName != Station.None)
                    _customer.TouchIn(stationName);
            }
        }

        private void PrintStationList()
        {
            var query = Enum.GetValues(typeof(Station))
                    .Cast<Station>()
                    .Except(new Station[] { Station.None });

            foreach (Station station in query)
            {
                Console.WriteLine($"{station}");
            }
            Console.WriteLine("\n");
        }
    }
}
