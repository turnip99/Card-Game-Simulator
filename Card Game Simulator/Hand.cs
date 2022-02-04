using Card_Game_Simulator.Properties;
using System.Collections.Generic;
using System.Media;

namespace Card_Game_Simulator
{
    class Hand
    {
        public List<Card> cards = new List<Card>(); //The hand contains a linked link.

        public Card PlaySymbol(Symbol chosenSymbol, bool soundBool) //Method for removing card with a symbol specified by user.
        {
            Card returnCard;
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Symbol == chosenSymbol)
                {
                    returnCard = cards[i];
                    cards.Remove(cards[i]);
                    if (soundBool)
                    {
                        SoundPlayer sndPlayCard = new SoundPlayer(Resources.PlayCard);
                        sndPlayCard.Play();
                    }
                    return returnCard;
                }
            }
            return null;
        }

        public Card PlayCard(string name, bool soundBool) //Method for removing a card specified by user.
        {
            Card returnCard;
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Name == name)
                {
                    returnCard = cards[i];
                    cards.Remove(cards[i]);
                    if (soundBool)
                    {
                        SoundPlayer sndPlayCard = new SoundPlayer(Resources.PlayCard);
                        sndPlayCard.Play();
                    }
                    return returnCard;
                }
            }
            return null;
        }

        public void Draw(Card cardDrawn) //Method for adding card to hand.
        {
            cards.Add(cardDrawn);
            BubbleSort();
        }

        public void BubbleSort() //Sorts the cards by symbol then by suit.
        {
            bool actuallySwappedSomething = true;
            Card temp;
            while (actuallySwappedSomething)
            {
                actuallySwappedSomething = false;
                for (int i = 0; i < cards.Count - 1; i++)
                {
                    if (cards[i].Symbol > cards[i + 1].Symbol)
                    {
                        actuallySwappedSomething = true;
                        temp = cards[i];
                        cards[i] = cards[i + 1];
                        cards[i + 1] = temp;
                    }
                    else if (cards[i].Symbol == cards[i + 1].Symbol)
                    {
                        if (cards[i].Suit > cards[i + 1].Suit)
                        {
                            actuallySwappedSomething = true;
                            temp = cards[i];
                            cards[i] = cards[i + 1];
                            cards[i + 1] = temp;
                        }
                    }
                }
            }
        }

        public int GetCount() //Retrieves the total number of cards in the hand.
        {
            if (cards.Count > 0)
            {
                int x = cards.Count;
                return x;
            }
            return 0;
        }

        public int HowManySymbol(Symbol symbol) //Finds how many cards of a specified symbol are in this hand.
        {
            int howMany = 0;
            foreach (Card card in cards)
            {
                if (card.Symbol == symbol)
                {
                    howMany++;
                }
            }
            return howMany;
        }

        public int HowManySuit(Suit suit) //Finds how many cards of a specified symbol are in this hand.
        {
            int howMany = 0;
            foreach (Card card in cards)
            {
                if (card.Suit == suit)
                {
                    howMany++;
                }
            }
            return howMany;
        }

        public bool CanKillCard(Card lastPlayed, Suit trumpSuit) //Used during five leaves to decide if a player can play a card.
        {
            if (lastPlayed == null)
            {
                return true;
            }
            foreach (Card card in cards)
            {
                if (card.Suit == trumpSuit && lastPlayed.Suit != trumpSuit ||
    card.Suit == trumpSuit && lastPlayed.Suit == trumpSuit && card.Symbol > lastPlayed.Symbol
    || card.Suit == lastPlayed.Suit && card.Symbol > lastPlayed.Symbol)
                {
                    return true;
                }
            }
            return false;
        }
    }
}