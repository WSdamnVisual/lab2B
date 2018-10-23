using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2B
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();//Переделать Rank и card.ToString()
                                   //ИСПОЛЬЗОВАТЬ ИНДЕКСАТОР
            Console.WriteLine("\t  " + deck[5].ToString());
            deck.Show();
            Console.ReadKey();
        }
    }
}
