using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCard
{
    class TopUpCommand
    {
        private Customer _customer;

        public TopUpCommand(Customer customer)
        {
            _customer = customer;

            Console.WriteLine("How much would you like to top up?" +
                        "\nYou can top up the following amounts:" +
                        "\n5" +
                        "\n10" +
                        "\n20" +
                        "\n50" +
                        "\n");

            ValidateInput();
        }
        
        private void ValidateInput()
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

            _customer.TopUp(amount);
        }
    }
}
