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

            //asking the user if they want to apply for a credit card
            wallet.CreateCard();

            //while the user wants to make a card
            bool makeCard = true;
            do
            {
                //user chooses which card details they want to look at
                int version = 1;
                var userChoice = "";
                while (userChoice != "ready")
                {
                    Console.WriteLine("\nIf you would like to see the card details, type the corresponding number.");
                    Console.WriteLine("Or, if you are ready to choose which card you'd like to apply for, type 'ready'.");
                    Console.WriteLine("1: VISA \n2: Mastercard \n3: American Express");
                    userChoice = Console.ReadLine();

                    wallet.UserCardChoice(userChoice, version, wallet);
                }

                version = 2;
                Console.WriteLine("\nEnter the corresponding number of the card type you'd like to choose. \n1: Visa \n2: Mastercard \n3:American Express");
                var cardChoice = Console.ReadLine();
                wallet.UserCardChoice(cardChoice, version, wallet);

                //Apply for another card?
                makeCard = wallet.AnotherCard(makeCard);

            } while (makeCard == true);

            //print out all cards in the wallet
            wallet.PrintWallet();
        }
    }
}