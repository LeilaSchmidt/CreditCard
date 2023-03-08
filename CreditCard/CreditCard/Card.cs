using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    class Card
    {
        public void cardChoice()
        {
            Console.WriteLine("Welcome, which of the three credit cards listed below would you like to apply for?");
            Console.WriteLine("VISA, Mastercard, American Express");
        }
        public void GetCardDetails()
        {
            Console.WriteLine("Please e");
        }
    }
    class Visa : Card
    {
        public int cardNum = 1;
    }

    class Mastercard : Card
    {
        public int cardNum = 2;
    }

    class AmericanExpress : Card
    {
        public int cardNum = 3;
    }

}