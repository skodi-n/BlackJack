using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Lib;

namespace BlackJack.UI
{
    internal class Program
    {
        /// <summary>
        /// Startet das Programm und demonstriert die Verwendung von Karten.
        /// Es wird eine einzelne Karte erstellt und ausgegeben.
        /// Anschließend wird ein komplettes Kartendeck erzeugt und alle Karten
        /// in der Konsole angezeigt. Zum Schluss wartet das Programm auf einen Tastendruck.
        /// </summary>
        static void Main(string[] args)
        {
            Card card = new Card(CardSuit.Heart, CardValue.Two);

            Console.WriteLine(card.ToString());

            CardDeck cardDeck = new CardDeck();

            for (int i = 0; i < 52; i++)
            {

                Console.WriteLine(cardDeck.Cards[i].ToString());

            }


            Console.ReadKey();
        }
    }
}
