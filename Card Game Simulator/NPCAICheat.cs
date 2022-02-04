using System;
using System.Collections.Generic;

namespace Card_Game_Simulator
{
    class NPCAICheat : NPCAI
    {
        private int howManyLastPlayed;
        public int HowManyLastPlayed
        {
            get { return howManyLastPlayed; }
            set { howManyLastPlayed = value; }
        }

        public int Decide(int howMany, int handCount) //Algorithm to decide the chance of npc not cheating.
        {
            int playChance = 0;
            if (howMany > 0)
            {
                playChance = 60 + howMany * 23;
            }
            return playChance;
        }

        public Symbol GetSymbolToPlay(Hand hand) //Gets the symbol to play when an npc has a 'free turn'.
        {
            Random rnd = new Random();
            int MaxAmount = 1;
            List<Symbol> MaxCards = new List<Symbol>();
            List<Symbol> AllCards = new List<Symbol>();
            for (int i = 2; i < 15; i++)
            {
                if (hand.HowManySymbol((Symbol)i) > 0)
                {
                    AllCards.Add((Symbol)i);
                }
                if (hand.HowManySymbol((Symbol)i) > MaxAmount)
                {
                    MaxAmount = hand.HowManySymbol((Symbol)i);
                    MaxCards.Clear();
                }
                if (hand.HowManySymbol((Symbol)i) == MaxAmount)
                {
                    MaxCards.Add((Symbol)i);
                }
            }
            if (rnd.Next(1, 10) < 7)
            {
                return MaxCards[rnd.Next(0, MaxCards.Count)];
            }
            else
            {
                return AllCards[rnd.Next(0, AllCards.Count)];
            }
        }

        public void Play(ref Queue playerQueue, Symbol symbol, ref Hand hand, ref Stack discard, bool soundBool) //Method for playing all cards of a certain symbol.
        {
            for (int i = 0; i < hand.GetCount(); i++)
            {
                if (hand.cards[i].Symbol == symbol)
                {
                    discard.push(hand.PlaySymbol(hand.cards[i].Symbol, soundBool));
                    i--;
                }
            }
        }

        public bool Cheat(ref Queue playerQueue, ref Hand hand, ref Stack discard, int howMany, Symbol symbol, bool soundBool) //Plays random cards from hand when npc cheats.
        {
            bool cheatBool = false;
            Symbol symbolToPlay = (Symbol)rnd.Next(2, 15);
            while (howMany > 0)
            {
                if (hand.HowManySymbol(symbolToPlay) > 0)
                {
                    if (symbolToPlay != symbol)
                    {
                        cheatBool = true;
                    }
                    discard.push(hand.PlaySymbol(symbolToPlay, soundBool));
                    howMany--;
                }
                else
                {
                    symbolToPlay = (Symbol)rnd.Next(2, 15);
                }
            }
            return cheatBool;
        }

        public int HowManyCheat(Hand hand, Symbol symbol) //Decides how many cards to play when cheating.
        {
            if (rnd.Next(1, 10) < 3 * hand.HowManySymbol(symbol)) //If 'tricking'.
            {
                return hand.HowManySymbol(symbol);
            }
            else
            {
                int random = rnd.Next(1, 100);
                if (random < 3 && hand.GetCount() >= 15)
                {
                    return 4;
                }
                else if (random < 12 && hand.GetCount() >= 10)
                {
                    return 3;
                }
                else if (random < 55 && hand.GetCount() >= 4)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
        }

        public Player Callout(Player[] players, Player currentPlayer, Player user, int discardCount, Symbol symbol, int playerNum) //Calculates chance/npc who will call out cheat.
        {
            if (discardCount - HowManyLastPlayed == 0) //If first play after a challenge, don't call 'cheat!'
            {
                return null;
            }
            int chance = -10 + discardCount - currentPlayer.hand.GetCount() + 2 * Exponential(HowManyLastPlayed, 3); //Calculates inital chance (factors all npcs can see);
            int[] chancesArray = new int[playerNum];
            for (int i = 0; i < playerNum; i++)
            {
                if (players[i] == currentPlayer || players[i] == user || players[i] == null)
                {
                    chancesArray[i] = 0; //Sets chance to 0 if npc is the current player or the npc is not in the game.
                }
                else
                {
                    chancesArray[i] = (chance + 2 * Exponential(players[i].hand.HowManySymbol(symbol), 2)) / 4; //Finalises chance for each npc based on cards in their hand.
                    if (HowManyLastPlayed == 4)
                    {
                        chancesArray[i] *= 2;
                    }
                    if (players[i].hand.HowManySymbol(symbol) + HowManyLastPlayed > 4 && rnd.Next(1, 36) > 5)
                    {
                        return players[i];
                    }
                }
            }
            if (playerNum == 1) //Player 1 cannot call 'cheat!'.
            {
                return null;
            }
            foreach (int item in chancesArray)
            {
                chance += item; //Adding up chances.
            }
            if (HowManyLastPlayed == 4 && currentPlayer.hand.GetCount() < 15)
            {
                chance += (100 + 20 * currentPlayer.hand.GetCount());
            }
            else
            {
                chance += (100 + 28 * currentPlayer.hand.GetCount());
            }
            int random = rnd.Next(1, chance);
            int total = 0;
            int position = rnd.Next(0, playerNum); //Starts on rnd npc to stop P2 calling out first.
            for (int i = 0; i < playerNum; i++)
            {
                total += chancesArray[position];
                if (total >= random) //Compares to random number to decide if npc calls out.
                {
                    return players[position]; //Returns number of npc.
                }
                position++;
                if (position == playerNum)
                {
                    position = 0;
                }
            }
            return null; //If no npc calls out, returns 0.
        }
    }
}