using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Models
{
    public class Deck
    {
        readonly ArrayList suits = new ArrayList() { "diamonds", "hearts", "spades", "clubs" };

        private List<Card> cards;
        private List<Card> shuffledCards;

        public Deck()
        {
            cards = new List<Card>();
            newDeck();
            shuffledCards = new List<Card>();
        }
        private void newDeck()
        {
            cards.Clear();
            for (int i = 0; i < suits.Count; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    cards.Add(new Card(j, (string)suits[i]));
                }
            }
        }

        public void shuffle()
        {
            shuffledCards.Clear();
            Random rand = new Random(DateTime.Now.Millisecond);

            List<int> shuffled = new List<int>(52);

            int card;
            List<int> sequence = Enumerable.Range(0, 52).ToList();
            for (int i = 0; i < 52; i++)
            {
                card = sequence[rand.Next(0, sequence.Count)];
                sequence.Remove(card);

                shuffled.Add(card);
            }

            for (int i = 0; i < 52; i++)
            {
                shuffledCards.Add(cards[shuffled[i]]);
            }
        }

        public Card dealNewCard()
        {
            Card newCard = shuffledCards[0];
            shuffledCards.RemoveAt(0);
            return newCard;
        }
        public int getCardCount()
        {
            return shuffledCards.Count;
        }
    }
}
