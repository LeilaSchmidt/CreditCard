using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    class Card
    {
        public string cardType { get; set; }
        public string cardDetails { get; set; }
        public string userChoice { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int cardNumber { get; set; }
        public int dateOfExpiraton { get; set; }
        public int memberSince { get; set; }

        public virtual void ViewCardDetails()
        {
            while (true)
            {
                
                Console.WriteLine($"These are the {cardType} details, when you are done viewing, type 'done'.");
                Console.WriteLine($"{cardDetails}");
                var done = Console.ReadLine();
                if (done == "done")
                {
                    break;
                }
            }
        }
        public virtual void CardChoice(Card card)
        {
            Console.WriteLine("Enter the corresponding number of the card type you'd like to choose. \n1: Visa \n2: Mastercard \n3:American Express");
            userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    card = new Visa();
                    card.createCard();
                    break;
                case "2":
                    card = new Mastercard();
                    card.createCard();
                    break;
                case "3":
                    card = new AmericanExpress();
                    card.createCard();
                    break;
            }
            Console.WriteLine($"you chose a {card.cardType} card.");
        }
        public void UserData()
        {
            Console.WriteLine("To create your personalized card, we will next need some personal information.");
            Console.WriteLine("Please enter your first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Now enter your last name: ");
            lastName = Console.ReadLine();
        }
        public virtual void createCard()
        {
            Console.WriteLine($"You just created a card ");
        }
    }

    class Visa : Card
    {
        public override void ViewCardDetails()
        {
            cardType = "Visa";
            cardDetails = 
                "THESE ARE THE VISA" + 
                " DEETS";
            base.ViewCardDetails();
        }
    }
    class Mastercard : Card
    {
        public override void ViewCardDetails()
        {
            cardType = "Mastercard";
            cardDetails =
                "THESE ARE THE MC" +
                " DEETS";
            base.ViewCardDetails();
        }
        public override void CardChoice(Card card)
        {
            cardType = "Mastercard";
            base.CardChoice(card);
        }
    }
    class AmericanExpress : Card
    {
        public override void ViewCardDetails()
        {
            cardType = "American Express";
            cardDetails =
                "THESE ARE THE AMEX" +
                " DEETS";
            base.ViewCardDetails();
        }
    }

}