using System.Reflection.Metadata.Ecma335;
using System;
using Microsoft.VisualBasic;

namespace CreditCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //initialize card and wallet
            Wallet wallet = new Wallet();
            Card card = null;

            //asking the user if they want to apply for a credit card
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


            bool makeCard = true;
            //while the user wants to make a card
            do
            {
                var userChoice = "";
                //user chooses which card details they want to look at
                while (userChoice != "ready")
                {
                    Console.WriteLine("");
                    Console.WriteLine("If you would like to see the card details, type the corresponding number.");
                    Console.WriteLine("Or, if you are ready to choose which card you'd like to apply for, type 'ready'.");
                    Console.WriteLine("1: VISA \n2: Mastercard \n3: American Express");
                    userChoice = Console.ReadLine();

                    //user choice triggers the equivalent card types
                    switch (userChoice)
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
                        case "done":
                            continue;
                        default:
                            break;
                    }

                }

                Console.WriteLine("\nEnter the corresponding number of the card type you'd like to choose. \n1: Visa \n2: Mastercard \n3:American Express");
                bool isValidChoice = false;
                int cardChoice = 0;
                while (!isValidChoice)
                {
                    if (!int.TryParse(Console.ReadLine(), out cardChoice) || cardChoice < 1 || cardChoice > 3)
                    {
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 3.");
                    }
                    else
                    {
                        isValidChoice = true;
                    }
                }
                switch (cardChoice)
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
                    wallet.StoreCard(card);
                }


                Console.Write("\nEnter your first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter your last name: ");
                string lastName = Console.ReadLine();

                card.GenerateCard(firstName, lastName, card);
                card.printCardDetails(card);

                Console.WriteLine("\nDo you wish to apply for another card? ");
                var anotherCard = Console.ReadLine();
                switch (anotherCard)
                {
                    case "no":
                        makeCard = false;
                        break;
                    case "yes":
                        makeCard = true;
                        continue;
                    default:
                        makeCard = false;
                        break;
                }
            } while (makeCard == true);
            //print out all cards in the wallet
            wallet.PrintWallet();
        }
    }
}