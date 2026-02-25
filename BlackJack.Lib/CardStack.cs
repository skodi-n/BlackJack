using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Lib
{
    /// <summary>Kartenstapel aus mehreren Decks.</summary>
    internal class CardStack : ICardStack
    {
        private const int DECKS = 6;

        /// <summary>Alle Karten im Stapel.</summary>
        public List<ICard> Cards { get; }

        /// <summary>Erstellt den Stapel und mischt ihn.</summary>
        /// <param name="deck">Deck-Vorlage (wird intern neu erstellt).</param>
        public CardStack(CardDeck deck)
        {
            Cards = new List<ICard>();

            for (int i = 0; i < DECKS; i++)
            {
                deck = new CardDeck();

                for (int j = 0; j < deck.Cards.Length; j++)
                {
                    Cards.Add(deck.Cards[j]);
                }
            }

            Shuffle(5);
        }

        /// <summary>Mischt den Stapel.</summary>
        /// <param name="numberOfShuffles">Wie oft gemischt wird.</param>
        /// <returns>Kein Rückgabewert.</returns>
        public void Shuffle(int numberOfShuffles)
        {
            Random random = new Random();

            for (int i = 0; i < numberOfShuffles; i++)
            {
                for (int j = 0; j < Cards.Count; j++)
                {
                    int randomIndex = random.Next(Cards.Count);

                    ICard temp = Cards[j];
                    Cards[j] = Cards[randomIndex];
                    Cards[randomIndex] = temp;
                }
            }
        }

        /// <summary>Zieht die oberste Karte.</summary>
        /// <returns>Gezogene Karte oder null, wenn leer.</returns>
        public ICard DrawCard()
        {
            if (Cards.Count == 0)
            {
                return null;
            }
            ICard card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }
}
