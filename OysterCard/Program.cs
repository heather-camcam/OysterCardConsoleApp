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

                Console.WriteLine("Welcome to the Oystercard app." +
                    "\nEnter any of the following commands to get started:" +
                    "\nTop up" +
                    "\n");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "Top up":
                        new TopUpCommand(customer);
                        break;
                        
                    default:
                        Console.WriteLine($"Unknown command {userInput}");
                        break;
                }
            }
        }
    }
}
