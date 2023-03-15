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
                Console.WriteLine("");
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
        public virtual void GenerateCVV()
        {
            Random random = new Random();
            cvv = random.Next(100, 1000).ToString();
        }
        public virtual void printCardDetails(Card card)
        {
            Console.WriteLine("Your newly created card: ");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"{card.cardType}");
            Console.WriteLine("");
            Console.WriteLine($"      {card.cardNumber}");
            Console.WriteLine("");
            Console.WriteLine($"{card.firstName} {card.lastName}     {card.expirationDate}");
            Console.WriteLine("");
            Console.WriteLine($"CVV: {card.cvv}");
        }
    }
    class Visa : Card
    {
        public Visa()
        {
            cardType = "Visa";
        }
        public override void ViewCardDetails()
        {
            cardType = "Visa";
            cardDetails = @"
            Benefits:
            - available in 200+ countries & territories
            - credit, debit, and PIN card transactions
            - card issued by third party, Visa responsible for transactions
            - secure transactions
            - good international acceptance
            
            Further tiered paying members benefits:
            Tier 1:
            - roadside dispatch
            - emergency card replacement 
            - emergency cash distribution

            Tier 2:
            - fine wine & food discount
            - golf discounts 
            - Visa luxury hotel collections

            Tier 3: 
            - priority pass lounge access
            - return protection
            - global entry statement credit
                        ";
            base.ViewCardDetails();
        }
        public override void GenerateCardNumber()
        {
            specialCardNum = "4";
            base.GenerateCardNumber();
        }
    }

    class Mastercard : Card
    {
        public Mastercard()
        {
            cardType = "Mastercard";
        }
        public override void ViewCardDetails()
        {
            cardType = "Mastercard";
            cardDetails = @"
            Benefits:
            - available in 210+ countries & territories
            - credit, debit, and PIN card transactions
            - card issued by third party, Mastercard responsible for transactions
            - secure transactions
            - good international acceptance
            
            Further tiered paying members benefits:
            Tier 1:
            - mastercard ID Theft protection 
            - rental car insurance
            - extended warranty

            Tier 2:
            - mastercard luxury hotels & resorts 
            - fuel rewards network
            - master rental insurance

            Tier 3: 
            - lyft credit 
            - fandango discount 
            - personal travel advisor
                        ";
            base.ViewCardDetails();
        }
        public override void GenerateCardNumber()
        {
            specialCardNum = "5";
            base.GenerateCardNumber();
        }
    }

    public class AmericanExpress : Card
    {
        public AmericanExpress()
        {
            cardType = "American Express";
        }
        
        public override void ViewCardDetails()
        {
            cardType = "American Express";
            cardDetails = @"
            Benefits:
            - available in 160+ countries 
            - credit card transactions
            - card issued and transactions done by American Express
            - amazing customer service
            - secure transactions
            - not great international acceptance
            - need a 'good' credit score            

            Further membership benefits:
            (American Express only has one tier)
            - cell phone coverage
            - extended warranty 
            - car rental loss/damage insurance
            - return protection         
                        ";
            base.ViewCardDetails();
        }
        public override void GenerateCardNumber()
        {
            specialCardNum = "3";
            base.GenerateCardNumber();
        }
        public override void GenerateCVV()
        {
            Random random = new Random();
            cvv = random.Next(1000, 10000).ToString();
        }
        public override void printCardDetails(Card card)
        {
            card.memberSince = "2023";
            base.printCardDetails(card);
            Console.WriteLine($"Member Since: {memberSince}");
        }
    }
}
