using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
    class CardDesk : IEnumerable<Card>
    {
        const int CardDeskLength = 52;
        Card[] desk = new Card[CardDeskLength];
        static Random rnd = new Random();
        public int Length { get => CardDeskLength; }
        public Card this[int i]
        {
            get
            {
                return desk[i];
            }
        }
        public CardDesk()
        {
            for (int i = 0; i < Length; ++i)
            {
                desk[i] = new Card(i);
            }
        }
        public void Suffle()
        {
            for (int i = 0; i < Length; ++i)
            {
                int n = rnd.Next(Length);
                Card tmp = desk[i];
                desk[i] = desk[n];
                desk[n] = tmp;
            }
        }
        public IEnumerator<Card> GetEnumerator()
        {
            for (int i = 0; i < Length; ++i)
            {
                yield return desk[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
