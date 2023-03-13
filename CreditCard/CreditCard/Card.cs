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
        public string userChoice { get; set; }
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

        public void CardChoice()
        {
            Console.WriteLine("Enter the corresponding number of the card type you'd like to choose. \n1: Visa \n2: Mastercard \n3:American Express?");
            userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    userChoice = "Visa";
                    break;
                case "2":
                    userChoice = "Mastercard";
                    break;
                case "3":
                    userChoice = "American Express";
                    break;
            }
            Console.WriteLine($"you chose a {userChoice} card.");
        }
    }
    class Visa : Card
    {
        public override void ViewCardDetails()
        {
            cardType = "Visa";
            base.ViewCardDetails();
        }
    }

    class Mastercard : Card
    {
        public override void ViewCardDetails()
        {
            cardType = "Mastercard";
            base.ViewCardDetails();
        }
    }

    class AmericanExpress : Card
    {
        public override void ViewCardDetails()
        {
            cardType = "American Express";
            base.ViewCardDetails();
        }
    }



}