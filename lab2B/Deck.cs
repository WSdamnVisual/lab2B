using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2B
{
    class Deck
    {
        private Card[] cards = new Card[52];
        public Deck()
        {
            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                for (int j = 0; i < (int)s * 13; j++, i++)
                    cards[i] = new Card((Rank)j+1, s);

            }
        }

        public Card this[UInt32 index]
        {
            get { return cards[index]; }
            set { cards[index] = value; }
        }

        public void Show()
        {
            foreach (Card card in cards)
                Console.WriteLine(card.ToString());
        }
    }
}
