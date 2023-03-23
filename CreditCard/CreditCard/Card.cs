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
                var done = Console.ReadLine();
                if (done == "done")
                {
                    break;
                }
            }
        }
        public virtual void GenerateCard(string firstName, string lastName, Card card)
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

    //Wallet Class
    class Wallet
    {
        private List<Card> cards = new List<Card>();
        public void CreateCard()
        {
            Console.WriteLine("Hello, do you want to apply for a credit card?");
            var runProgram = Console.ReadLine();

            while (runProgram.ToLower() != "yes" && runProgram.ToLower() != "y" && runProgram.ToLower() != "no" && runProgram.ToLower() != "n")
            {
                Console.WriteLine("Invalid input! Please enter 'yes' or 'no'");
                runProgram = Console.ReadLine();
            }

            if (runProgram.ToLower() == "no" || runProgram.ToLower() == "n")
            {
                Console.WriteLine("okay, goodbye!");
                Environment.Exit(0);
            }
        }

        public Card UserCardChoice(string userChoice, int version, Wallet wallet)
        {
            Card card = null;
            while (userChoice != "ready" && userChoice != "1" && userChoice != "2" && userChoice != "3" && userChoice != "done")
            {
                Console.WriteLine("Invalid input! Please enter a valid choice.");
                userChoice = Console.ReadLine();
            }

            //user choice triggers the equivalent card types
            switch (userChoice)
            {
                case "ready":
                    return null;
                case "1":
                    card = new Visa();
                    break;
                case "2":
                    card = new Mastercard();
                    break;
                case "3":
                    card = new AmericanExpress();
                    break;
                case "done":
                    return null;
            }
            if (version == 1)
            {
                card.ViewCardDetails();
                return null;
            }
            else if (version == 2)
            {
                //first and last name
                Console.Write("\nEnter your first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter your last name: ");
                string lastName = Console.ReadLine();

                card.GenerateCard(firstName, lastName, card);
                card.printCardDetails(card);
                wallet.StoreCard(card);
                return card;
            }
            else
            {
                return null;
            }
        }

        public void StoreCard(Card card)
        {
            cards.Add(card);
            Console.WriteLine($"You chose a {card.GetCardType()} card.");
        }

        public bool AnotherCard(bool makeCard)
        {
            Console.WriteLine($"\nDo you wish to apply for a card? ");
            var anotherCard = Console.ReadLine();
            switch (anotherCard)
            {
                case "no":
                    makeCard = false;
                    return makeCard;
                case "yes":
                    return true;
                default:
                    makeCard = false;
                    return makeCard;
            }
        }
        public void PrintWallet()
        {
            Console.WriteLine("You created the following cards: ");
            //final print out details of each card created 
            foreach (Card obj in cards)
            {
                obj.printCardDetails(obj);
            }
            Console.WriteLine("\nGoodbye!");
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

        public override void GenerateCard(string firstName, string lastName, Card card)
        {
            base.GenerateCard(firstName, lastName, card);
            cvv = random.Next(1000, 10000).ToString();
        }
        public override void printCardDetails(Card card)
        {
            base.printCardDetails(card);
            Console.WriteLine($"Member Since: {memberSince}");
        }
    }
}
