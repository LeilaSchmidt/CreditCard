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

            string cardType;
            do
            {
                //user chooses between the 3 options
                Console.WriteLine("Which credit card woudl you like to see the details for?");
                Console.WriteLine("1: VISA \n2: Mastercard \n3: American Express");
                cardType = Console.ReadLine();
                //Console.WriteLine($"you chose {cardType}.");

                //user choice triggers the equivalent card types

                switch (cardType)
                {
                    case "1":
                        visa.ViewCardDetails();
                    case "2":
                        mastercard.ViewCardDetails();
                    case "3":
                        americanExpress.ViewCardDetails();
                    default:
                        Console.WriteLine("I'm sorry, I did not understand that, please try again");
                        cardType = Console.ReadLine();
                }
            } while (cardType != "1" && cardType != "2" && cardType != "3");

        end:
            Console.WriteLine("");
        }
    }
}