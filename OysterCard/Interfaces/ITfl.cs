using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OysterCard.Tfl;

namespace OysterCard.Interfaces
{
    interface ITfl
    {
        List<int> TopUpAmounts { get; set; }

        Dictionary<Station, int> StationAndZoneInfo { get; set; }

        List<int> TopUpOptions();

        int ValidateInput();

        Station TouchIn();

        Station TouchOut();

        int CalculateFare(List<Station> journey);

        Dictionary<Station, int> AddZoneInfo();
    }
}
