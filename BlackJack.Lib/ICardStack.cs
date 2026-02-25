using System.Collections.Generic;

namespace BlackJack.Lib
{
    public interface ICardStack
    {
        List<ICard> Cards { get; }

        ICard DrawCard();
        void Shuffle(int numberOfShuffles);
    }
}