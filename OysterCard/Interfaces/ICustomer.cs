using System.Collections.Generic;
using static OysterCard.Tfl;

namespace OysterCard.Interfaces
{
    interface ICustomer
    {
        List<Station> TouchOut(Station station);

        void TopUp(int amount);

        void TouchIn(Station station);

        void DeductFare(int fare);

        int Balance { get; set; }

        bool InFlight { get; set; }

        List<Station> Journey { get; set; }

        List<List<Station>> JourneyHistory { get; }
    }
}
