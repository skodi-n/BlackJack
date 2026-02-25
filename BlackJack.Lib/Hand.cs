using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Lib
{
    public partial class Hand
    {
        /// <summary>
        /// Speichert sämtliche Karten, die sich aktuell in der Hand befinden.
        /// </summary>
        private List<ICard> _cards = new List<ICard>();

        public List<ICard> GetTheCardsOfTheHand { get { return _cards; } }

        /// <summary>
        /// Repräsentiert den momentanen Zustand der Hand.
        /// </summary>
        public HandStatus Status { get; private set; }

        /// <summary>
        /// Initialisiert eine neue Hand ohne Karten.
        /// </summary>
        public Hand()
        {
            CalculateValue();
        }

        /// <summary>
        /// Legt eine weitere Karte in die Hand.
        /// </summary>
        /// <param name="card">Die Karte, die hinzugefügt werden soll.</param>
        public void AddCard(ICard card)
        {
            _cards.Add(card);

            // Nach dem Hinzufügen wird der Gesamtwert erneut berechnet
            CalculateValue();
        }

        /// <summary>
        /// Ermittelt den Gesamtpunktwert der Hand gemäß den Blackjack-Regeln.
        /// </summary>
        /// <returns>Gibt den aktuell berechneten Wert der Hand zurück.</returns>
        public int CalculateValue()
        {
            int value = 0;   // Summierter Wert der Karten
            int aces = 0;    // Anzahl der Asse (werden zunächst als 11 gewertet)

            // Durchläuft jede Karte in der Hand
            foreach (ICard currentCard in _cards)
            {
                // Ass wird vorerst mit 11 Punkten berücksichtigt
                if (currentCard.Value == CardValue.Ace)
                {
                    aces++;
                    value += 11;
                    continue; // Weiter zur nächsten Karte
                }

                // Karten mit Bild (Jack, Queen, King) zählen immer 10
                if (currentCard.Value >= CardValue.Jack)
                {
                    value += 10;
                }
                else
                {
                    // Zahlenkarten entsprechen ihrem numerischen Wert
                    value += (int)currentCard.Value;
                }
            }

            // Überschreitet der Wert 21, wird jedes Ass schrittweise von 11 auf 1 reduziert
            while (value > 21 && aces > 0)
            {
                value -= 10;
                aces--;
            }

            // Setzt den Status der Hand basierend auf dem berechneten Ergebnis
            SetHandStatus(value);

            return value;
        }

        /// <summary>
        /// Legt fest, welchen Status die Hand besitzt (z. B. Blackjack oder überkauft).
        /// </summary>
        /// <param name="value">Der zuvor berechnete Gesamtwert.</param>
        void SetHandStatus(int value)
        {
            int cardCount = _cards.Count; // Anzahl der aktuell vorhandenen Karten

            // Handwert überschreitet 21
            if (value > 21)
            {
                Status = HandStatus.Busted;
                return;
            }

            // Spezialfälle bei exakt 21 Punkten
            if (value == 21)
            {
                // Blackjack: genau zwei Karten
                if (cardCount == 2)
                {
                    Status = HandStatus.BlackJack;
                }
                // Triple Seven: drei Karten und alle haben den Wert sieben
                else if (cardCount == 3 && _cards.All(card => card.Value == CardValue.Seven))
                {
                    Status = HandStatus.TripleSeven;
                }
                // Five Card Charlie: fünf Karten mit insgesamt 21 Punkten
                else if (cardCount == 5)
                {
                    Status = HandStatus.FiveCardCharlie;
                }
                else
                {
                    Status = HandStatus.Safe;
                }

                return;
            }

            // Standardfall: Hand ist weiterhin im sicheren Bereich
            Status = HandStatus.Safe;
        }
    }
}
