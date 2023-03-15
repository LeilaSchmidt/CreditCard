using System.Reflection.Metadata.Ecma335;
using System;
using Microsoft.VisualBasic;

namespace CreditCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            Card card = null;
            bool makeCard = true;


            //asking the user if they want to apply for a credit card
            Console.WriteLine("");
            Console.WriteLine("Hello, do you want to apply for a credit card?");
            var runProgram = Console.ReadLine();
            do
            {
                if (runProgram.ToLower() != "yes" && runProgram.ToLower() != "y")
                {
                    Console.WriteLine("okay, goodbye!");
                    Environment.Exit(0);
                }
                else
                {
                    break;
                }
            } while (true);

            //while the user
            while (makeCard == true)
            {
                string cardType = "";
                while (cardType != "ready")
                {
                    //user chooses between the 3 options
                    Console.WriteLine("");
                    Console.WriteLine("If you would like to see the card details, type the corresponding number.");
                    Console.WriteLine("Or, if you are ready to choose which card you'd like to apply for, type 'ready'.");
                    Console.WriteLine("1: VISA \n2: Mastercard \n3: American Express");
                    cardType = Console.ReadLine();

                    //user choice triggers the equivalent card types
                    switch (cardType)
                    {
                        case "ready":
                            break;
                        case "1":
                            Visa visa = new Visa();
                            visa.ViewCardDetails();
                            break;
                        case "2":
                            Mastercard mastercard = new Mastercard();
                            mastercard.ViewCardDetails();
                            break;
                        case "3":
                            AmericanExpress americanExpress = new AmericanExpress();
                            americanExpress.ViewCardDetails();
                            break;
                        default:
                            break;
                    }
                
                }

                Console.WriteLine("");
                Console.WriteLine("Enter the corresponding number of the card type you'd like to choose. \n1: Visa \n2: Mastercard \n3:American Express");
                bool isValidChoice = false;
                int userChoice = 0;
                while (!isValidChoice)
                {
                    if (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 3)
                    {
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 3.");
                    }
                    else
                    {
                        isValidChoice = true;
                    }
                }
                switch (userChoice)
                {
                    case 1:
                        card = new Visa();
                        break;
                    case 2:
                        card = new Mastercard();
                        break;
                    case 3:
                        card = new AmericanExpress();
                        break;
                }
                if (card != null)
                {
                    cards.Add(card);
                    Console.WriteLine($"You chose a {card.cardType} card.");
                }

                Console.WriteLine("");
                Console.Write("Enter your first name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter your last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("");

                card.firstName = firstName;
                card.lastName = lastName;
                card.GenerateCardNumber();
                card.GenerateExpirationDate();
                card.GenerateCVV();

                card.printCardDetails(card);

                Console.WriteLine("");
                Console.WriteLine("Do you wish to apply for another card? ");
                var anotherCard = Console.ReadLine();
                switch (anotherCard)
                {
                    case "no":
                        makeCard = false;
                        break;
                    case "yes":
                        continue;
                    default:
                        makeCard = false;
                        break;
                }

            }
            foreach (Card obj in cards)
            {
                obj.printCardDetails(obj);
            }
        }
    }
}