using System.Reflection.Metadata.Ecma335;
using System;
using Microsoft.VisualBasic;

namespace CreditCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card();
            Visa visa = new Visa();
            Mastercard mastercard = new Mastercard();
            AmericanExpress americanExpress = new AmericanExpress();


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

            string cardType = "";
            while(cardType != "ready")
            {
                //user chooses between the 3 options
                Console.WriteLine("If you would like to see the card details, type the corresponding number.");
                Console.WriteLine("Or, if you are ready to choose which card you'd like to apply for, type 'ready'.");
                Console.WriteLine("1: VISA \n2: Mastercard \n3: American Express");
                cardType = Console.ReadLine();
                //Console.WriteLine($"you chose {cardType}.");

                //user choice triggers the equivalent card types

                switch (cardType)
                {
                    case "ready":
                        break;
                    case "1":
                        visa.ViewCardDetails();
                        break;
                    case "2":
                        mastercard.ViewCardDetails();
                        break;
                    case "3":
                        americanExpress.ViewCardDetails();
                        break;
                    default:
                        Console.WriteLine("I'm sorry, I did not understand that, please try again");
                        cardType = Console.ReadLine();
                        break;
                }
            }

            card.CardChoice();

        end:
            Console.WriteLine("");
        }
    }
}