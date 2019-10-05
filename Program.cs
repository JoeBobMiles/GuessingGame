// @file Program.cs
// @author Joseph Miles <josephmiles2015@gmail.com>
// @date 2019-10-04
//
// This is the entry point for the Guessing Game program.

using System;

namespace GuessingGame
{

    class Program
    {
        private static Game game = new Game();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
                exit = game.run();

            Console.WriteLine("Goodbye!");
        }
    }
}
