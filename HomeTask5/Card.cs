using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
    class Card
    {
        private static string[] strWeight = {
            "двойка",
            "тройка",
            "четверка",
            "пятерка",
            "шестерка",
            "семёрка",
            "восьмёрка",
            "девятка",
            "десятка",
            "валет",
            "дама",
            "король",
            "туз"
        };
        public int Point()
        {
            if (weight < 11)
                return weight;
            else if (weight != 14)
                return weight - 9;
            else
                return 11;
        }
        string suit;
        int weight;
        public Card(int value)
        {
            weight = (value % 13) + 2;
            switch (value / 13)
            {
                case 0:
                    suit = "пика";
                    break;
                case 1:
                    suit = "трефа";
                    break;
                case 2:
                    suit = "бубна";
                    break;
                case 3:
                    suit = "чирва";
                    break;
            }
        }
        public override string ToString()
        {
            return $"{strWeight[weight - 2]} {suit}";
        }
    }
}
