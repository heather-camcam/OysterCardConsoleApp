using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
