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
            Console.WriteLine("Hello, do you want to apply for a credit card?");
            var runProgram = Console.ReadLine();
            do
            {
                if (runProgram.ToLower() != "yes" && runProgram.ToLower() != "y")
                {
                    Console.WriteLine("okay, goodbye!");
                    goto end;
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
                            visa = null;
                            break;
                        case "2":
                            Mastercard mastercard = new Mastercard();
                            mastercard.ViewCardDetails();
                            mastercard = null;
                            break;
                        case "3":
                            AmericanExpress americanExpress = new AmericanExpress();
                            americanExpress.ViewCardDetails();
                            americanExpress = null;
                            break;
                        default:
                            Console.WriteLine("I'm sorry, I did not understand that, please try again");
                            cardType = Console.ReadLine();
                            continue;
                    }
                }

                Console.WriteLine("Enter the corresponding number of the card type you'd like to choose. \n1: Visa \n2: Mastercard \n3:American Express");
                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        card = new Visa();
                        card.cardType = "Visa";
                        break;
                    case "2":
                        card = new Mastercard();
                        card.cardType = "Mastercard";
                        break;
                    case "3":
                        card = new AmericanExpress();
                        card.cardType = "American Express";
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        return;
                }
                if (card != null)
                {
                    cards.Add(card);
                    Console.WriteLine($"You chose a {card.cardType} card.");
                }


                Console.Write("Enter your first name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter your last name: ");
                string lastName = Console.ReadLine();

                card.firstName = firstName;
                card.lastName = lastName;
                card.GenerateCardNumber();
                card.GenerateExpirationDate();
                card.GenerateCVV();

                card.printCardDetails(card);

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
        end:
            Console.WriteLine("");
        }
    }
}
