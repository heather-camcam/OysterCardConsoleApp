using OysterCard.Interfaces;
using System;
using static OysterCard.Tfl;

namespace OysterCard
{
    class TouchOutCommand
    {
        private ITfl _tfl;
        private ICustomer _customer;

        public TouchOutCommand(ICustomer customer, ITfl tfl)
        {
            _customer = customer;
            _tfl = tfl;

            if (!_customer.InFlight)
                Console.WriteLine("You must touch in to a station before you touch out.\n");

            else
            {
                _tfl.PrintStationList();

                var stationName = _tfl.TouchOut();

                var journey = _customer.TouchOut(stationName);

                var fare = _tfl.CalculateFare(journey);

                _customer.DeductFare(fare);
            }
        }
    }
}
