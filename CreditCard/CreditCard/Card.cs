using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    public abstract class Card
    {
        public string cardDetails { get; set; }
        public string cardType { get; set; }
        public string userChoice { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cardNumber { get; set; }
        public string expirationDate { get; set; }
        public string cvv { get; set; }
        public string memberSince { get; set; }
        public string specialCardNum { get; set; }

        public virtual void ViewCardDetails()
        {
            while (true)
            {
                Console.WriteLine($"These are the {cardType} details, when you are done viewing, type 'done'.");
                Console.WriteLine($"{cardDetails}");
                var done = Console.ReadLine();
                if (done == "done")
                {
                    break;
                }
            }
        }
        public virtual void GenerateCardNumber()
        {
            Random random = new Random();
            cardNumber = specialCardNum + random.Next(100000000, 999999999).ToString() + "0000000";
        }
        public void GenerateExpirationDate()
        {
            Random random = new Random();
            int year = DateTime.Now.Year + random.Next(1, 6);
            int month = random.Next(1, 13);
            expirationDate = month.ToString().PadLeft(2, '0') + "/" + year.ToString().Substring(2, 2);
        }
        public void GenerateCVV()
        {
            Random random = new Random();
            cvv = random.Next(1000, 10000).ToString();
        }
        public virtual void printCardDetails(Card card)
        {
            Console.WriteLine("");
            Console.WriteLine($"{card.cardType}");
            Console.WriteLine("");
            Console.WriteLine($"      {card.cardNumber}");
            Console.WriteLine("");
            Console.WriteLine($"{card.firstName} {card.lastName}    {card.memberSince} {card.expirationDate}");
            Console.WriteLine("");
            Console.WriteLine($"CVV: {card.cvv}");
        }
    }
    class Visa : Card
    {
        public override void ViewCardDetails()
        {
            cardType = "Visa";
            base.ViewCardDetails();
        }
        public override void GenerateCardNumber()
        {
            specialCardNum = "4";
            base.GenerateCardNumber();
        }
        public override void printCardDetails(Card card) // Change the parameter type
        {
            memberSince = "";
            base.printCardDetails(card); // Call the base implementation with the correct parameter type
        }
    }

    class Mastercard : Card
    {
        public override void ViewCardDetails()
        {
            cardType = "Mastercard";
            base.ViewCardDetails();
        }
        public override void GenerateCardNumber()
        {
            specialCardNum = "5";
            base.GenerateCardNumber();
        }
        public override void printCardDetails(Card card)
        {
            memberSince = "";
            base.printCardDetails(card);
        }
    }

    class AmericanExpress : Card
    {
        public override void ViewCardDetails()
        {
            cardType = "American Express";
            base.ViewCardDetails();
        }
        public override void GenerateCardNumber()
        {
            specialCardNum = "3";
            base.GenerateCardNumber();
        }
        public override void printCardDetails(Card card)
        {

            card.memberSince = "2023";
            base.printCardDetails(card);
            Console.WriteLine($"Member Since: {memberSince}");
        }
    }
}
