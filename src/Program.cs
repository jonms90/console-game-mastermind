using System;

namespace MasterMind.Game
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var input = Console.ReadKey().Key;
            while (input != ConsoleKey.Escape)
            {


                input = Console.ReadKey().Key;
            }
            Console.WriteLine("Exiting game...");
            Console.WriteLine("Thank you for playing Mastermind!");
        }
    }
}
