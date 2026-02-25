using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Lib
{
    /// <summary>Stellt eine Spielkarte dar.</summary>
    public class Card : ICard
    {
        /// <summary>Kartenfarbe.</summary>
        public CardSuit Suit { get; }

        /// <summary>Kartenwert.</summary>
        public CardValue Value { get; }

        /// <summary>Erstellt eine Karte.</summary>
        /// <param name="suit">Kartenfarbe.</param>
        /// <param name="value">Kartenwert.</param>
        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        /// <summary>Gibt die Karte als Text zurück.</summary>
        /// <returns>Textdarstellung der Karte.</returns>
        public override string ToString()
        {
            return $"Kartentyp: {Suit} ; Kartenwert: {Value}";
        }
    }
}
