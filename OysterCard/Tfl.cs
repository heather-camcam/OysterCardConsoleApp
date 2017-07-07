using OysterCard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OysterCard
{
    class Tfl : ITfl
    {
        private List<int> _topUpAmounts;
        private Dictionary<Station, int> _stationAndZoneInfo;

        public List<int> TopUpAmounts { get => _topUpAmounts; set => _topUpAmounts = value; }
        public Dictionary<Station, int> StationAndZoneInfo { get => _stationAndZoneInfo; set => _stationAndZoneInfo = value; }

        public Tfl()
        {
            _topUpAmounts = new List<int>() { 5, 10, 15, 20, 50 };
            AddZoneInfo();
        }

        public enum Station
        {
            None,
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

            var isANumber = (Int32.TryParse(stringAmount, out int amount));

            if (_topUpAmounts.Contains(amount))
            {
                Console.WriteLine($"You have topped up £{amount}\n");
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
                Console.WriteLine($"You have touched in to {input} station\n");
                Enum.TryParse(input, out Station station);
                return station;
            }
            else
            {
                Console.WriteLine($"Oops {input} is not a valid station\n");
                return Station.None;
            }

        }

        public Station TouchOut()
        {
            var input = Console.ReadLine();

            if (Enum.IsDefined(typeof(Station), input))
            {
                Console.WriteLine($"You have touched out of {input} station\n");
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

        public Dictionary<Station, int> AddZoneInfo()
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

        public void CheckZone()
        {
            foreach (KeyValuePair<Station, int> station in _stationAndZoneInfo)
            {
                Console.WriteLine($"{station.Key}: {station.Value}");
            }
            Console.WriteLine("\n");
        }

        public void PrintStationList()
        {
            Console.WriteLine("Select a station...\n");
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
