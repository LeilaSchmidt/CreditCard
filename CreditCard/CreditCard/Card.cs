using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    public abstract class Card
    {
        protected Random random = new Random();
        protected string cardType { get; set; }                        //change THIS
        protected string cardDetails { get; set; }
        protected string userChoice { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string cardNumber { get; set; }
        protected string specialCardNum { get; set; }
        private string expirationDate { get; set; }
        protected string cvv { get; set; }
        public Card()
        {
            this.cardType = cardType;
        }
        public string GetCardType()
        {
            return cardType;
        }

        public virtual void ViewCardDetails()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine($"These are the {cardType} details, when you are done viewing, type 'done'.");
                Console.WriteLine($"{cardDetails}");
                string done = Console.ReadLine();
                while (done.ToLower() != "done")
                {
                    Console.WriteLine("Invalid input! Please enter a valid choice.");
                    done = Console.ReadLine();
                }
                break;
            }
        }
        public virtual bool GenerateCard(string firstName, string lastName, Card card)
        {
            //assign first and last name
            card.firstName = firstName;
            card.lastName = lastName;
            //generate cardNumber
            cardNumber = specialCardNum + random.Next(100000000, 999999999).ToString() + "0000000";

            //Generate Expiration Date
            int year = DateTime.Now.Year + random.Next(1, 6);
            int month = random.Next(1, 13);
            expirationDate = month.ToString().PadLeft(2, '0') + "/" + year.ToString().Substring(2, 2);

            //Generate CVV
            cvv = random.Next(100, 1000).ToString();

            // check if cardNumber, expirationDate, and cvv were successfully generated
            if (!string.IsNullOrEmpty(cardNumber) && !string.IsNullOrEmpty(expirationDate) && !string.IsNullOrEmpty(cvv))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void printCardDetails(Card card)
        {
            Console.WriteLine("\n\nYour newly created card: ");
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
            specialCardNum = "4";
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
        }
    }

    class Mastercard : Card
    {
        public Mastercard()
        {
            cardType = "Mastercard";
            specialCardNum = "5";
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
        }
    }

    public class AmericanExpress : Card
    {
        private string memberSince { get; set; }
        public AmericanExpress()
        {
            cardType = "American Express";
            specialCardNum = "3";
            memberSince = "2023";
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
        }

        public override bool GenerateCard(string firstName, string lastName, Card card)
        {
            base.GenerateCard(firstName, lastName, card);
            cvv = random.Next(1000, 10000).ToString();
            return true;
        }
        public override void printCardDetails(Card card)
        {
            base.printCardDetails(card);
            Console.WriteLine($"Member Since: {memberSince}");
        }
    }
}
