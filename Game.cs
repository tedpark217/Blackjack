using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Models;

namespace Blackjack.Models
{
    public class Game { 
        private Deck deck;

        public Game()
        {
            deck = new Deck();
            deck.shuffle();
        }

        public void resetGame()
        {
            deck.shuffle();
        }

        public Card deal()
        {
            if (this.deck.getCardCount() < 40)
            {
                this.deck.shuffle();
            }
            return this.deck.dealNewCard();
        }

        public int getScore(List<Card> hand)
        {
            int score = 0;
            bool ace = false;

            foreach (Card card in hand)
            {
                if (card.FaceDown)
                {
                    continue;
                }

                int fn = card.FaceNumber;
                if (fn > 10)
                {
                    score += 10;
                }
                else
                {
                    score += fn;
                    if (fn == 1)
                    {
                        ace = true;
                    }
                }
            }

            if(ace && score <= 11)
            {
                score += 10;
            }
            return score;
        }
    }
}
