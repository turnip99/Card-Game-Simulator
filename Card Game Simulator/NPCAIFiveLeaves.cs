using System.Collections.Generic;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    class NPCAIFiveLeaves : NPCAI
    {
        public bool Decide(Card lastPlayed, Suit trumpSuit, Player[] players, Stack discard, int deckSize, Player currentPlayer) //Decides if player will play cards during five leaves.
        {
            int chanceToPlay;
            if (currentPlayer.hand.CanKillCard(lastPlayed, trumpSuit) == false) //If player can't kill previous card.
            {
                return true; //Will pick up.
            }
            else //Else, algorithm to calculate chance to playing a card, as opposed to picking up.
            {
                if (currentPlayer.hand.GetCount() == 1) //Guaranteed to play if one only card remaining.
                {
                    return false;
                }
                int howManyTrump = currentPlayer.hand.HowManySuit(trumpSuit);
                chanceToPlay = 95 + (3 * howManyTrump) - (deckSize / 2); //Less likely to play if deck is not yet depleted.
                if (howManyTrump <= 1)
                {
                    chanceToPlay -= 8;
                }
                if (currentPlayer.hand.GetCount() / (currentPlayer.hand.HowManySuit(lastPlayed.Suit) + 1) > 7 && lastPlayed.Suit != trumpSuit) //If you have few cards of the current symbol.
                {
                    chanceToPlay -= 5;
                }
                int trumpsToPickUp = 0;
                for (int i = 1; i < 6; i++)
                {
                    if (discard.pointer - i > 0)
                    {
                        if (discard.GetCardByDistanceFromTop(i).Suit == trumpSuit)
                        {
                            trumpsToPickUp++;
                        }
                    }
                }
                chanceToPlay -= (Exponential(3, trumpsToPickUp) * 2 / 3);
                if (deckSize < 10)
                {
                    chanceToPlay += 90; //Much less likely to strategically pick up if deck is almost empty.
                    if (currentPlayer.hand.GetCount() < 5)
                    {
                        chanceToPlay += 40; //Even less likely to strategically pick up if player is almost out of cards.
                    }
                }
                else if (lastPlayed.Suit == trumpSuit && howManyTrump == 1)
                {
                    chanceToPlay -= 50; //Much lower chance to play if you have only one trump remaining.
                }
                if (rnd.Next(0, 100) < chanceToPlay)
                {
                    return false; //Will play card.
                }
                else
                {
                    return true; //Will pick up.
                }
            }
        }

        public void Play(ref Queue playerQueue, Card lastPlayed, Suit trumpSuit, ref Hand hand, ref Stack discard, int playStatus, Player nextPlayer, bool soundBool) //Play card during five leaves.
        {
            List<Card> validCards = new List<Card>(); //List of valid cards.
            foreach (Card card in hand.cards)
            {
                if (playStatus == 1)
                {
                    if (lastPlayed == null)
                    {
                        validCards.Add(card);
                    }
                    else if (card.Suit == trumpSuit && lastPlayed.Suit != trumpSuit ||
                        card.Suit == trumpSuit && lastPlayed.Suit == trumpSuit && card.Symbol > lastPlayed.Symbol
                        || card.Suit == lastPlayed.Suit && card.Symbol > lastPlayed.Symbol)
                    {
                        validCards.Add(card);
                    }
                }
                else //If for the 2nd played card, all cards are valid.
                {
                    validCards.Add(card);
                }
            }
            bool actuallySwappedSomething = true; //Bubble-sort to sort trump cards to end of the validCards list (makes them less likely to be played).
            Card temp;
            while (actuallySwappedSomething)
            {
                actuallySwappedSomething = false;
                for (int i = 0; i < validCards.Count - 1; i++)
                {
                    if (validCards[i].Suit == trumpSuit && validCards[i + 1].Suit != trumpSuit)
                    {
                        actuallySwappedSomething = true;
                        temp = validCards[i];
                        validCards[i] = validCards[i + 1];
                        validCards[i + 1] = temp;
                    }
                }
            }
            if (nextPlayer != null && nextPlayer.hand.GetCount() < 3 && playStatus == 2) //If next player is soon to win.
            {
                for (int i = 0; i < validCards.Count; i++)
                {
                    if (validCards[i].Suit == trumpSuit && rnd.Next(0, 7) > 0) //Very high chance of playing a trump-card card if you have one.
                    {
                        discard.push(hand.PlayCard(validCards[i].Name, soundBool));
                        return;
                    }
                    else if (rnd.Next(0, 20) > 18) //Low chance of playing a non-trump card.
                    {
                        discard.push(hand.PlayCard(validCards[i].Name, soundBool));
                        return;
                    }
                }
                discard.push(hand.PlayCard(validCards[validCards.Count - 1].Name, soundBool)); //If card still has not been played at end of loop, play highest card.
            }
            else
            {
                for (int i = 0; i < validCards.Count; i++) //Otherwise, decides which card to play. Most likely to be the lowest card.
                {
                    if (rnd.Next(0, 7) > 1)
                    {
                        discard.push(hand.PlayCard(validCards[i].Name, soundBool));
                        return;
                    }
                }
                discard.push(hand.PlayCard(validCards[0].Name, soundBool)); //If card still has not been played at end of loop, play lowest card.
            }
        }
    }
}