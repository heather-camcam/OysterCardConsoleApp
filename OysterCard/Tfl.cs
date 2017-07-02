using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCard
{
    class Tfl
    {
        private List<int> _topUpAmounts;
        private Dictionary<Station, int> _stationAndZoneInfo;

        public Tfl()
        {
            _topUpAmounts = new List<int>() { 5, 10, 15, 20, 50 };
            AddZoneInfo();
        }

        public enum Station
        {
            Paddington,
            Hackney,
            LiverpoolStreet,
            Brockley
        }

        public List<int> TopUpOptions()
        {
            return _topUpAmounts;
        }

        public int ValidateInput()
        {
            var stringAmount = Console.ReadLine();

            if (Int32.TryParse(stringAmount, out int amount))
            {
                Console.WriteLine($"You have topped up £{amount}");
            }
            else
            {
                Console.WriteLine($"Oops {stringAmount} is not valid. " +
                    "\nMake sure you are only topping up a valid amount.");
            }

            return amount;
        }

        public Station TouchIn()
        {
            var input = Console.ReadLine();

            if (Enum.IsDefined(typeof(Station), input))
            {
                Console.WriteLine($"You have touched in to {input} station");
            }
            else
            {
                Console.WriteLine($"Oops {input} is not a valid station\n");
            }

            Enum.TryParse(input, out Station station);

            return station;
        }

        public Station TouchOut()
        {
            var input = Console.ReadLine();

            if (Enum.IsDefined(typeof(Station), input))
            {
                Console.WriteLine($"You have touched out of {input} station");
            }
            else
            {
                Console.WriteLine($"Oops {input} is not a valid station\n");
            }

            Enum.TryParse(input, out Station station);

            return station;
        }

        public int CalculateFare(List<Station> journey)
        {
            var startLocation = journey.First();
            var endLocation = journey.Last();

            _stationAndZoneInfo.TryGetValue(startLocation, out int startLocationZone);
            _stationAndZoneInfo.TryGetValue(endLocation, out int endLocationZone);

            if (startLocationZone == 1 || endLocationZone == 1)
            {
                return 3;
            }
            else if (startLocationZone == 2 || endLocationZone == 2)
            {
                return 2;
            }
            else
                return 1;

        }

        private Dictionary<Station, int> AddZoneInfo()
        {
            _stationAndZoneInfo = new Dictionary<Station, int>()
            {
                {Station.Paddington, 1},
                {Station.Hackney, 2 },
                {Station.LiverpoolStreet, 1 },
                {Station.Brockley, 3 }
            };

            return _stationAndZoneInfo;
        }
    }
}
