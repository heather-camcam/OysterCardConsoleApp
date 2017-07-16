using OysterCard.Interfaces;
using System;
using System.Collections.Generic;
using static OysterCard.Tfl;

namespace OysterCard
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomer customer = new Customer();
            ITfl tfl = new Tfl();

            Console.WriteLine("Welcome to the Oystercard app.\n");
            Console.WriteLine("Press 1 to get started\n");

            while (true)
            {
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "Top up":
                        new TopUpCommand(customer, tfl);
                        break;

                    case "Touch in":
                        new TouchInCommand(customer, tfl);
                        break;

                    case "Touch out":
                        new TouchOutCommand(customer, tfl);
                        break;

                    case "Check balance":
                        Console.WriteLine($"\nYour remaining balance is £{customer.Balance}");
                        break;

                    case "Check zone":
                        tfl.CheckZone();
                        break;

                    case "See journey history":
                        if (customer.JourneyHistory.Count > 0)
                        {
                            PrintJourneyHistory(customer);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nYour journey history is empty\n");
                            break;
                        }

                    case "1":
                        PrintCommands();
                        break;

                    default:
                        Console.WriteLine($"Unknown command {userInput}");
                        break;
                }
            }
        }

        private static void PrintCommands()
        {
            Console.WriteLine("\nEnter any of the following commands:" +
                    "\nTop up" +
                    "\nTouch in" +
                    "\nTouch out" +
                    "\nCheck balance" +
                    "\nCheck zone" +
                    "\nSee journey history" +
                    "\n");
        }

        private static void PrintJourneyHistory(ICustomer customer)
        {
            foreach (List<Station> journey in customer.JourneyHistory)
            {
                Console.WriteLine($"From: {journey[0]}" +
                    $"\nTo: {journey[1]}" +
                    $"\n");
            }
        }
    }
}
