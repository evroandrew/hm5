using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
    class BlackJack
    {
        List<Card> player=new List<Card> { };
        List<Card> casino=new List<Card> { };
        int points_p=0;
        int points_c=0;
        int itt = 3;
        CardDesk desk;
        public BlackJack()
        {
            Console.Clear();
            desk = new CardDesk();
            desk.Suffle();
        }
        private int Count(List<Card> obj, int points)
        {
            int obj_p = 0;
            for (int i = 0; i < obj.Count; i++)
            {
                int tmp = obj[i].Point();
                if (tmp == 11)
                    if (points > 21)
                        obj_p += 1;
                    else
                        obj_p += 11;
                else
                    obj_p += tmp;
                Console.WriteLine(points_p);
            }
            return obj_p;
        }
        private void Count_points()
        {
            points_p = Count(player, points_p);
            points_p = Count(player, points_p);
            points_c = Count(casino, points_c);
            points_c = Count(casino, points_c);
        }
        public void NewGame()
        {
            AddCard(player);
            AddCard(player);
            AddCard(casino);
            ShowTable();
            Question();
            if (points_p < 22)
                while (points_c < 17)
                    AddCard(casino);
            else
            {
                Console.WriteLine("You lose!");
                return;
            }
            ShowTable();
            if((points_c>21)||(points_p>points_c))
                    Console.WriteLine("You win!");
            else
                Console.WriteLine("You lose!");
        }
        private void Question()
        {
            if (points_p < 21)
            {
                Console.WriteLine("Взять карту?(1)");
                ConsoleKeyInfo gb = Console.ReadKey();
                if (gb.Key == ConsoleKey.NumPad1)
                {
                    AddCard(player);
                    ShowTable();
                    Question();
                }
            }
            else
                return;
        }
        private void AddCard(List<Card> obj)
        {
            obj.Add(desk[itt]);
            itt++;
            Count_points();
        }
        private void ShowTable()
        {
            Console.Clear();
            Console.WriteLine("Player Cards:");
            for (int i = 0; i < player.Count; i++)
                Console.WriteLine(player[i]);
            Console.WriteLine("Player Points: "+points_p);
            Console.WriteLine("Casino Cards:");
            for (int i = 0; i < casino.Count; i++)
                Console.WriteLine(casino[i]);
            Console.WriteLine("Casino Points: " + points_c);
        }
    }
}
