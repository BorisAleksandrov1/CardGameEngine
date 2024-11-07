using System.Globalization;
using System.Runtime.CompilerServices;

namespace CardGameEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pickGame = string.Empty;
            bool playAgain = true;

            System.Console.WriteLine("Select a game");
            System.Console.WriteLine("1. War");
            System.Console.WriteLine("2. Blackjack");

            pickGame = Console.ReadLine();
            while(playAgain)
            {
                switch (pickGame)
                {
                case "1":
                    Console.Clear();
                    War.StartGame();
                    playAgain = GetPlayAgain(Console.ReadLine());
                    break;
                case "2":
                    Console.Clear();
                    Blackjack.StartGame();
                    break;
                default:
                    System.Console.WriteLine("Invalid option. Please try again.");
                    break;
                }
            }
            
        }

        static bool GetPlayAgain(string choice)
        {
            System.Console.WriteLine("Do you want to play again? (yes/no)");

            switch (choice.ToLower())
            {
                case "yes":
                case "y":
                    return true;
                case "no":
                case "n":
                    return false;
                default:
                    System.Console.WriteLine("Invalid choice. Please enter 'yes' or 'no'.");
                    return GetPlayAgain(Console.ReadLine());
            }
        }
    }
}   
