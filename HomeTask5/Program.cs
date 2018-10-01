using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
    class Program
    {
        static void BlackJack()
        {
            BlackJack blackjack = new BlackJack();
            blackjack.NewGame();
            Console.WriteLine("For repeat enter 1");
            ConsoleKeyInfo gb;
            gb = Console.ReadKey();
            if (gb.Key == ConsoleKey.NumPad1)
                BlackJack();
        }
        static void Game15()
        {
            Game game = new Game();
            while (!game.IsWin())
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        game.zeroUp();
                        break;
                    case ConsoleKey.UpArrow:
                        game.zeroDown();
                        break;
                    case ConsoleKey.RightArrow:
                        game.zeroLeft();
                        break;
                    case ConsoleKey.LeftArrow:
                        game.zeroRight();
                        break;
                }
            }
            Console.WriteLine("For repeat enter 1");
            ConsoleKeyInfo gb;
            gb = Console.ReadKey();
            if (gb.Key == ConsoleKey.NumPad1)
                Game15();
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo gb;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to play in Game15 ");
                Console.WriteLine("Enter 2 to play in BlackJack ");
                Console.WriteLine("Enter 0 to exit");
                gb = Console.ReadKey();
                if (gb.Key == ConsoleKey.NumPad1)
                    Game15();
                if (gb.Key == ConsoleKey.NumPad2)
                    BlackJack();
            } while (gb.Key != ConsoleKey.NumPad0);
        }
    }
}