// See https://aka.ms/new-console-template for more information
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Elizabeth Oyebade
//Info 350 Final Project
//This is my Blackjack App

namespace Final
{
    public class Selection
    {
        private int optionChoise;


        public Selection()
        {
            Console.WriteLine("Choose Menu");
            Console.WriteLine("1) Play Game");
            Console.WriteLine("2) Exit Game");

            ConsoleKeyInfo meniuselection;
            meniuselection = Console.ReadKey(true);

            switch (meniuselection.KeyChar)
            {
                case '1':
                    Console.WriteLine("1");
                    Console.ReadKey();
                    optionChoise = 1 ;
                    break;
                case '2':
                    Console.WriteLine("2");
                    Console.ReadKey();
                    optionChoise = 2;
                    break;
            }
            Console.ReadLine();
        }

        public int OptionChoise
        { get { return optionChoise; } }

    }
    public class program
    {
        public static void Main(string[] args)
        {
            string name;
            int age;
            Console.WriteLine("Welcome to the luxury life of blackjack");
            Console.WriteLine("By: Elizabeth Oyebade");

            Selection oCh1 = new Selection();
            // ... oCh1.OptionChoise ...
            if (oCh1.OptionChoise == 1)
            {
                Console.WriteLine("Enter the game");
            }
            else 
            {
                Console.WriteLine("Invalid! Thank you for trying my app");
                return; 
            }

            Console.WriteLine("Before we begin, " +
                    "Please enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter age: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.ReadLine();
            if (age < 18)
            {
                    Console.WriteLine("Under age user cannot access game");
                    Console.ReadLine();
                    return;
            }
            else
            {
                    Console.WriteLine("User as of age, Proceed to the game");
            }

            Console.WriteLine("Welcome to my blackjack app. " +
                    "You have $500. Each hand costs $100. You win at $1000. ");
            Console.ReadKey();

            var money = 500;
            while (money > 0)
            {
                var yourHand = GetNewHand();

                Console.WriteLine($"Your cards are {GetCardName(yourHand.Item1)} and {GetCardName(yourHand.Item2)}");

                var dealerHand = GetNewHand();
                Console.WriteLine($"The dealer is showing a {GetCardName(dealerHand.Item1)}. Do you (h)it or (s)tay?");

                var input = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                while (input != "h" && input != "s")
                {
                        Console.WriteLine("Do you (h)it or (s)tay?");
                        input = Console.ReadKey().KeyChar.ToString();
                        Console.WriteLine();
                }

                if (input == "s")
                {
                        Console.WriteLine(Environment.NewLine +
                                          $"The dealer flips their other card over. It's a {GetCardName(dealerHand.Item2)}.");
                }
                var newCard = 0;
                if (input == "h")
                {
                    var random = new Random();
                    newCard = random.Next(1, 14);
                    var n = "";
                    if (newCard == 1)
                    {
                        n = "n";
                    }
                    Console.WriteLine($"The dealer slides another card to you. It's a{n} {GetCardName(newCard)}.");
                }

                var yourCards = GetCardValue(yourHand.Item1) + GetCardValue(yourHand.Item2) + GetCardValue(newCard);
                var dealersCards = GetCardValue(dealerHand.Item1) + GetCardValue(dealerHand.Item2);

                if (dealersCards < 17)
                {
                    var random = new Random();
                    newCard = random.Next(1, 14);
                    var n = "";
                    if (newCard == 1)
                    {
                        n = "n";
                    }
                    Console.WriteLine($"The dealer adds another card to their hand. It's a{n} {GetCardName(newCard)}.");
                        dealersCards += newCard;
                }

                if (yourCards < dealersCards || yourCards > 21)
                {
                        money -= 100;
                        var loseMessage = yourCards > 21 ? "You busted!" : "You lost!";
                        Console.WriteLine(
                            $"You had {yourCards} and dealer had {dealersCards}. {loseMessage} You now have ${money} (-$100)");
                }
                else if (yourCards == dealersCards)
                {
                        Console.WriteLine(
                            $"You had {yourCards} and dealer had {dealersCards}. It's a push! You now have ${money} (+$0))");
                }
                else 
                {
                        money += 100;
                        Console.WriteLine(
                            $"You had {yourCards} and dealer had {dealersCards}. You won! You now have ${money} (+$100).");
                }

                // lose if < 1000, reach 1000, you win
                if (money < 1000)
                {
                        Console.WriteLine("Keep on trying");
                }
                else
                {
                        Console.WriteLine("You Win!");
                        Console.ReadKey();
                        return;
                }
            }
        }
        public static int GetCardValue(int card)
        {
                if (card > 10)
                    return 10;
                return card;
        }
        public static string GetCardName(int card)
        {
                if (card == 1)
                    return "Ace";
                if (card == 11)
                    return "Jack";
                if (card == 12)
                    return "Queen";
                if (card == 13)
                    return "King";
                return card.ToString();
        }
        public static Tuple<int, int> GetNewHand()
        {
                var random = new Random();
                var num1 = random.Next(1, 14);
                var num2 = random.Next(1, 14);
                return new Tuple<int, int>(num1, num2);
        }
    }
    
}
