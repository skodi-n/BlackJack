using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Lib
{
    internal class Factory
    {
        /// <summary>Erstellt eine neue Karte.</summary>
        /// <param name="suit">Kartenfarbe der Karte.</param>
        /// <param name="value">Kartenwert der Karte.</param>
        /// <returns>Eine neue Instanz von <see cref="ICard"/>.</returns>
        public static ICard CreateCard(CardSuit suit, CardValue value)
        {

            return new Card(suit, value);

        }
    }
}
