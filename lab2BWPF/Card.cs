using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2BWPF
{
    class Card
    {
        private Suit suit = Suit.diamond;
        private Rank rank = Rank.ace;

        private Card() { }

        public Card(int Rank, string Suit)
        { }
        public Card(string Rank, string Suit)
        { }
        public Card(int Rank, Suit Suit)
        { }
        public Card(Rank Rank, Suit Suit)
        {
            rank = Rank;
            suit = Suit;
        }

        public override string ToString()
        {
            return "Suit: "+ this.suit + " Rank: "+ this.rank;
        }
    }
}
