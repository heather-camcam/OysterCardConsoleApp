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

            while (true)
            {
                Console.WriteLine("Welcome to the Oystercard app." +
                    "\nEnter any of the following commands to get started:" +
                    "\nTop up" +
                    "\nTouch in" +
                    "\nTouch out" +
                    "\nCheck balance" +
                    "\nCheck zone" +
                    "\n See journey history" +
                    "\n");

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
                        Console.WriteLine($"Your remaining balance is £{customer.Balance}");
                        break;

                    case "Check zone":
                        tfl.CheckZone();
                        break;

                    case "See journey history":
                        foreach(List<Station> journey in customer.JourneyHistory)
                        {
                            Console.WriteLine($"From: {journey[0]}" +
                                $"\nTo: {journey[1]}" +
                                $"\n");
                        }
                        break;

                    default:
                        Console.WriteLine($"Unknown command {userInput}");
                        break;
                }
            }
        }
    }
}
