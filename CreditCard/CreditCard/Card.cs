using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    abstract class Card
    {
        public string cardDetails { get; set; }
        public string cardType { get; set; }
        public string userChoice { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cardNumber;
        public string expirationDate;
        public string cvv;
        public string memberSince;

        public abstract void GenerateCardNumber();

        public abstract void GenerateExpirationDate();

        public abstract void GenerateCVV();

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
            Random random = new Random();
            cardNumber = "4" + random.Next(100000000, 999999999).ToString() + "0000000";
        }

        public override void GenerateExpirationDate()
        {
            Random random = new Random();
            int year = DateTime.Now.Year + random.Next(1, 6);
            int month = random.Next(1, 13);
            expirationDate = month.ToString().PadLeft(2, '0') + "/" + year.ToString().Substring(2, 2);
        }

        public override void GenerateCVV()
        {
            Random random = new Random();
            cvv = random.Next(100, 1000).ToString();
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
            Random random = new Random();
            cardNumber = "5" + random.Next(100000000, 999999999).ToString() + "0000000";
        }

        public override void GenerateExpirationDate()
        {
            Random random = new Random();
            int year = DateTime.Now.Year + random.Next(1, 6);
            int month = random.Next(1, 13);
            expirationDate = month.ToString().PadLeft(2, '0') + "/" + year.ToString().Substring(2, 2);
        }

        public override void GenerateCVV()
        {
            Random random = new Random();
            cvv = random.Next(100, 1000).ToString();
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
            Random random = new Random();
            cardNumber = "3" + random.Next(100000000, 999999999).ToString() + "000000";
        }

        public override void GenerateExpirationDate()
        {
            Random random = new Random();
            int year = DateTime.Now.Year + random.Next(1, 6);
            int month = random.Next(1, 13);
            expirationDate = month.ToString().PadLeft(2, '0') + "/" + year.ToString().Substring(2, 2);
        }

        public override void GenerateCVV()
        {
            Random random = new Random();
            cvv = random.Next(1000, 10000).ToString();
        }
    }
}
