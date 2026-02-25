using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Lib
{
    /// <summary>Standard-Deck mit 52 Karten.</summary>
    public class CardDeck
    {
        ICard[] _cards = new ICard[52];

        /// <summary>Alle Karten im Deck.</summary>
        public ICard[] Cards 
        { 
            get
            {
                return _cards;
            }
        
        }

        /// <summary>Erstellt und füllt ein 52-Karten-Deck.</summary>
        public CardDeck()
        {
            int counter = 0;

            for (int colour = 0; colour <= 3; colour++)
            {
                for (int deckValue = 0; deckValue <= 12; deckValue++)
                {
                    CardSuit suit = (CardSuit)colour;
                    CardValue value = (CardValue)deckValue;

                    _cards[counter++] = Factory.CreateCard(suit, value);
                }
            }
        }
    }
}
