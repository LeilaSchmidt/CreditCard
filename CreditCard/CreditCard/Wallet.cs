using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    //Wallet Class
    class Wallet
    {
        private List<Card> cards = new List<Card>();
        public bool startProgram(string runProgram)
        {
            while (runProgram.ToLower() != "yes" && runProgram.ToLower() != "y" && runProgram.ToLower() != "no" && runProgram.ToLower() != "n")
            {
                Console.WriteLine("Invalid input! Please enter 'yes' or 'no'");
                runProgram = Console.ReadLine();
            }
            if (runProgram.ToLower() == "no" || runProgram.ToLower() == "n")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Card UserCardChoice(string userChoice, int version)
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
                while (firstName == null)
                {
                    Console.WriteLine("I'm sorry, it appears you didn't enter your first name correctly. Please try again. ");
                    firstName = Console.ReadLine();
                }
                Console.Write("Enter your last name: ");
                string lastName = Console.ReadLine();
                while (lastName == null)
                {
                    Console.WriteLine("I'm sorry, it appears you didn't enter your last name correctly. Please try again. ");
                    lastName = Console.ReadLine();
                }

                if (card.GenerateCard(firstName, lastName, card))
                {
                    card.printCardDetails(card);
                    StoreCard(card);
                    Console.WriteLine("Card successfully generated.");
                    return card;
                }
                else
                {
                    Console.WriteLine("Failed to generate card.");
                    return null;
                }
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
            while (anotherCard.ToLower() != "no" && anotherCard.ToLower() != "yes")
            {
                Console.WriteLine("Invalid input! Please enter 'yes' or 'no'");
                anotherCard = Console.ReadLine();
            }

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
}
