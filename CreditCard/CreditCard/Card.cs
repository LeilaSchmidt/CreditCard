using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    class Card
    {
        public string firstName { get; set; }   
        public string lastName { get; set; }
        public string email { get; set; }
        public virtual void ViewCardDetails()
        {
            
        }
    }
    class Visa : Card
    {
        public int cardNum = 1;
        public override void ViewCardDetails()
        {
            do
            {
                Console.WriteLine("These are the Visa details, when you are done viewing, type 'done'.");
                var done = Console.ReadLine();
                if (done == "done")
                {
                    break;
                }
            } while (true);
        }
    }

    class Mastercard : Card
    {
        public int cardNum = 2;
        public override void ViewCardDetails()
        {
            Console.WriteLine("These are the Mastercard details");
        }
    }

    class AmericanExpress : Card
    {
        public int cardNum = 3;
        public override void ViewCardDetails()
        {
            Console.WriteLine("These are the American Express details");
        }
    }



}