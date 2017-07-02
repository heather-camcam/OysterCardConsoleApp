using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCard
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var customer = new Customer();
                var tfl = new Tfl();

                Console.WriteLine("Welcome to the Oystercard app." +
                    "\nEnter any of the following commands to get started:" +
                    "\nTop up" +
                    "\nTouch in" +
                    "\nTouch out" +
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

                    default:
                        Console.WriteLine($"Unknown command {userInput}");
                        break;
                }
            }
        }
    }
}
