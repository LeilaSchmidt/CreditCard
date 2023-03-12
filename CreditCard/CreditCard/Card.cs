using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    class Card
    {
        public string cardType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public virtual void ViewCardDetails()
        {
            while (true)
            {
                Console.WriteLine($"These are the {cardType} details, when you are done viewing, type 'done'.");
                var done = Console.ReadLine();
                if (done == "done")
                {
                    break;
                }
            }
        }
    }
    class Visa : Card
    {
        public int cardNum = 1;
        public override void ViewCardDetails()
        {
            cardType = "Visa";
            base.ViewCardDetails();
        }
    }

    class Mastercard : Card
    {
        public int cardNum = 2;
        public override void ViewCardDetails()
        {
            cardType = "Mastercard";
            base.ViewCardDetails();
        }
    }

    class AmericanExpress : Card
    {
        public int cardNum = 3;
        public override void ViewCardDetails()
        {
            cardType = "American Express";
            base.ViewCardDetails();
        }
    }



}