using Card_Game_Simulator.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    class GameEngineFiveLeaves : GameEngine
    {
        private NPCAIFiveLeaves npcai = new NPCAIFiveLeaves(); //Creates class with npc's decision algorithms.

        private Card trumpCard;
        internal Card TrumpCard
        {
            get { return trumpCard; }
            set { trumpCard = value; }
        }

        private bool pickUpBool = false;
        public bool PickUpBool
        {
            get { return pickUpBool; }
            set { pickUpBool = value; }
        }

        private bool pickUpDeckBool = false;
        public bool PickUpDeckBool
        {
            get { return pickUpDeckBool; }
            set { pickUpDeckBool = value; }
        }

        public override void TimerMainInterval(Game game) //Main timer algorithm for five leaves.
        {
            if (GameEnd == false) //Draw buttons unless game is over.
            {
                DrawButtons(game);
            }
            if (ShuffleStatus) //If shuffling, count to 10 ticks then stop.
            {
                if (ShuffleTime == 40)
                {
                    game.LblDeckNum.Visible = true;
                    game.LblDeckNum.Text = "(" + deck.GetHowMany().ToString() + ")";
                    ShuffleStatus = false;
                    NewTurn(game);
                }
                if (ShuffleTime == 30)
                {
                    game.PicDiscard.Image = null;
                    string name = "Trump" + TrumpCard.Suit;
                    game.PicTrump.Image = (Image)Resources.ResourceManager.GetObject(name);
                    game.PicDiscard.Image = null;
                }
                if (ShuffleTime == 16)
                {
                    foreach (PictureBox box in game.PicHand)
                    {
                        box.Visible = true;
                    }
                    HandLabelActivate(game);
                    game.PicDiscard.Image = TrumpCard.Image;
                    game.LblLastPlayed.Text = "The 'Trump-Suit'\nis " + TrumpCard.Suit + "!";
                    game.LblStatus.Text = "The 'Trump-Suit' is " + TrumpCard.Suit + "!";
                }
                ShuffleTime++;
            }
            base.TimerMainInterval(game);
        }

        protected override void UpdateLastPlayed(Game game, int howMany) //Updates UI with last played card in a format suitable for five leaves.
        {
            StringBuilder builder = new StringBuilder(); //String holds what will be display in 'lblLastPlayed'.
            if (discard.GetHowMany() > 0)
            {
                Card card = discard.GetCardByDistanceFromTop(1);
                if (card != null)
                {
                    if (card.Symbol > (Symbol)10)
                    {
                        builder.Append(card.Symbol.ToString()); //If a word-symbol, add the word to the stringbuilder.
                    }
                    else
                    {
                        builder.Append((int)card.Symbol); //If a number-symbol, add the number to the stringbuilder.
                    }
                    builder.Append(" of ");
                    builder.Append(card.Suit);
                }
            }
            PlayedString = builder.ToString();
            if (PickUpBool)
            {
                if (discard.GetHowMany() > 0) //If there are cards in the pile after picking up 5, show next card to be killed.
                {
                    game.LblLastPlayed.ForeColor = Colours[1];
                    game.LblLastPlayed.Text = "Card to Kill:\n" + PlayedString;
                }
                game.LblPlayed.Text = "\"Pick Up!\"";
            }
            else
            {
                game.LblPlayed.Text = "\"" + PlayedString + "\"";
                if (PlayStatus == 1)
                {
                    game.LblLastPlayed.ForeColor = Colours[2]; //Label changes colour depending on if showing card played or card to kill.
                    game.LblLastPlayed.Text = "Played Card:\n" + PlayedString;
                }
                else
                {
                    game.LblLastPlayed.ForeColor = Colours[1];
                    game.LblLastPlayed.Text = "Card to Kill:\n" + PlayedString;
                }
            }
            if (discard.GetHowMany() > 0 && discard.GetCardByDistanceFromTop(1).Suit == TrumpCard.Suit)
            {
                game.LblLastPlayed.Text += "\n(Trump)";
            }
            base.UpdateLastPlayed(game, howMany);
        }

        protected override void Play(Game game) //Method for playing cards during five leaves.
        {
            PickUpBool = false;
            if (playerQueue.GetTopItem().PlayerNum == 1) //If it's the player's turn.
            {
                PlayPlayer(game);
            }
            else
            {
                if (PlayStatus == 1 && discard.GetHowMany() != 0) //If on the first play (where there is an option of picking up), decide if npc can/will play a card.
                {
                    PickUpBool = npcai.Decide(discard.GetCardByDistanceFromTop(1), TrumpCard.Suit, playerQueue.items, discard, deck.GetHowMany(), playerQueue.GetTopItem());
                }
                if (!PickUpBool)
                {
                    npcai.Play(ref playerQueue, discard.GetCardByDistanceFromTop(1), TrumpCard.Suit, ref playerQueue.GetTopItem().hand, ref discard, PlayStatus, playerQueue.GetNextPlayer(), SoundBool);
                }
                WaitInitial(game);
                UpdateLastPlayed(game, 1);
            }
            UpdateHands(game, true);
        }

        protected override void PlayPlayer(Game game) //Method for starting user's turn during five leaves.
        {
            if (PlayStatus == 1)
            {
                if (playerQueue.GetPlayer(1).hand.CanKillCard(discard.GetCardByDistanceFromTop(1), TrumpCard.Suit) == true)
                {
                    game.BtnPlay.Enabled = true; //Enabled play button if legal move can be made.
                    game.BtnPlay.BackColor = Colours[0];
                }
                else
                {
                    game.BtnPlay.Enabled = false;
                    game.BtnPlay.BackColor = Color.WhiteSmoke;
                }
                game.BtnPickUp.Visible = true;
            }
            else
            {
                game.BtnPlay.Enabled = true;
                game.BtnPlay.BackColor = Colours[0];
            }
            game.BtnPlay.Visible = true;
            game.BtnHint.Visible = true;
            game.BtnRules.Visible = true; //Makes main buttons visible
            game.BtnGuide.Visible = true;
        }

        protected override void WaitInitial(Game game) //Initiate waiting phase.
        {
            UpdateHands(game, false);
            if (playerQueue.GetTopItem().hand.GetCount() < 5 && PlayStatus == 2)
            {
                PickUpDeck(game);
            }
            WaitTime = 0;
            WaitStatus = true;
            game.TimerWait.Start();
            game.PicPlayedCard.Visible = true;
            game.LblPlayed.Visible = true;
            game.PicPlayedCard.BringToFront();
            if (PickUpBool) //If picking up 5.
            {
                if (discard.GetHowMany() - 5 <= 0) //If deck will be empty after picking up, erase label's text.
                {
                    game.LblLastPlayed.Text = "";
                }
                if (SoundBool)
                {
                    SoundPlayer sndPickUp = new SoundPlayer(Resources.PickUp);
                    sndPickUp.Play();
                }
                game.PicPlayedCard.Location = game.PicDiscard.Location;
                PickUpDiscard(game, playerQueue.GetTopItem().PlayerNum, 0);
                UpdateDiscardPic(game);
            }
            else
            {
                if (discard.GetCardByDistanceFromTop(1) == null)
                {
                    game.PicPlayedCard.Image = Resources.BackOfCard;
                }
                else
                {
                    game.PicPlayedCard.Image = discard.GetCardByDistanceFromTop(1).Image;
                }
            }
        }

        public override void WaitInterval(Game game) //Increments while in waiting phase after a play.
        {
            if (WaitTime > 6 && WaitStatus)
            {
                UpdateHands(game, false);
                game.TimerWait.Stop();
                WaitTime = 0;
                WaitStatus = false;
                if (PlayStatus != 1 || PickUpBool) //If on last action of the turn.
                {
                    DisableAllPics(game);
                    if (discard.GetHowMany() > 0) //If discard pile is not empty, next player much take both plays.
                    {
                        PlayStatus = 1;
                    }
                    else //If discard pile is empty after picking up, next player only takes the second play.
                    {
                        UpdateLastPlayed(game, 0);
                        PlayStatus = 2;
                    }
                    EndTurn(game);
                }
                else
                {
                    PlayStatus = 2;
                    if (playerQueue.GetTopItem().hand.GetCount() == 0) //If player's hand is empty, end their turn.
                    {
                        DisableAllPics(game);
                        EndTurn(game);
                    }
                    else //Else, play second card.
                    {
                        Play(game);
                    }
                }
            }
            else
            {
                if (WaitStatus)
                {
                    WaitTime++;
                    if (WaitTime == 5) //Get rid of the deck's card image slightly later than the discard pile's card.
                    {
                        game.PicDrawnCardDeck.Visible = false;
                        game.LblDeckNum.Visible = true;
                    }
                    if (WaitTime == 3) //Get rid of these elements half way through the wait time.
                    {
                        game.PicPlayedCard.Visible = false;
                        game.LblPlayed.Visible = false;
                        UpdateDiscardPic(game);
                    }
                    if (WaitTime < 5)
                    {
                        Point Loc = game.PicPlayedCard.Location;
                        if (WaitTime < 3)
                        {
                            if (!PickUpBool)
                            {
                                switch (playerQueue.GetTopItem().PlayerNum) //Decides which way card moves towards discard pile.
                                {
                                    case 1: Loc.Y -= 7; game.PicPlayedCard.Location = Loc; break;
                                    case 2: Loc.X += 7; game.PicPlayedCard.Location = Loc; break;
                                    case 3: Loc.Y += 7; game.PicPlayedCard.Location = Loc; break;
                                    case 4: Loc.X -= 7; game.PicPlayedCard.Location = Loc; break;
                                    default: break;
                                }
                            }
                            else
                            {
                                switch (playerQueue.GetTopItem().PlayerNum) //Decides which way card moves away from discard pile.
                                {
                                    case 1: Loc.Y += 7; game.PicPlayedCard.Location = Loc; break;
                                    case 2: Loc.X -= 7; game.PicPlayedCard.Location = Loc; break;
                                    case 3: Loc.Y -= 7; game.PicPlayedCard.Location = Loc; break;
                                    case 4: Loc.X += 7; game.PicPlayedCard.Location = Loc; break;
                                    default: break;
                                }
                            }
                        }
                        if (PickUpDeckBool)
                        {
                            Loc = game.PicDrawnCardDeck.Location;
                            switch (playerQueue.GetTopItem().PlayerNum) //Decides which way card moves away from deck.
                            {
                                case 1: Loc.Y += 7; game.PicDrawnCardDeck.Location = Loc; break;
                                case 2: Loc.X -= 7; game.PicDrawnCardDeck.Location = Loc; break;
                                case 3: Loc.Y -= 7; game.PicDrawnCardDeck.Location = Loc; break;
                                case 4: Loc.X += 7; game.PicDrawnCardDeck.Location = Loc; break;
                                default: break;
                            }
                        }
                    }
                }
            }
        }

        private void PickUpDeck(Game game) //Method for picking up a card from the deck.
        {
            if (deck.GetHowMany() == 0)
            {
                return;
            }
            game.PicDrawnCardDeck.Location = game.PicDeck.Location;
            game.PicDrawnCardDeck.BringToFront();
            game.PicDrawnCardDeck.Visible = true;
            game.LblDeckNum.Visible = false;
            PickUpDeckBool = true;
            while (playerQueue.GetTopItem().hand.GetCount() < 5)
            {
                playerQueue.GetTopItem().hand.Draw(deck.pop()); //Draws from deck until hand contains 5 cards.
                if (deck.GetHowMany() == 0)
                {
                    break;
                }
            }
            game.LblDeckNum.Text = "(" + deck.GetHowMany().ToString() + ")"; //Updates label based on how many cards are in the deck.
            if (deck.GetHowMany() == 0)
            {
                game.LblDeckNum.Dispose();
            }
        }

        private bool CanKill(Card card) //Calcultes if a card can kill the previous card.
        {
            if (discard.GetHowMany() == 0)
            {
                return true;
            }
            if (card.Suit == TrumpCard.Suit && discard.GetCardByDistanceFromTop(1).Suit != TrumpCard.Suit ||
    card.Suit == TrumpCard.Suit && discard.GetCardByDistanceFromTop(1).Suit == TrumpCard.Suit && card.Symbol > discard.GetCardByDistanceFromTop(1).Symbol
    || card.Suit == discard.GetCardByDistanceFromTop(1).Suit && card.Symbol > discard.GetCardByDistanceFromTop(1).Symbol)
            {
                return true;
            }
            return false;
        }

        public override void PlayButtonClick(Game game) //Function for when user choses to play cards in five leaves.
        {
            game.LblAnnotations[0].Visible = true;
            game.LblAnnotations[0].Location = new Point(180, 755);
            game.CbxPlay.Visible = true;
            int howMany = 0;
            game.BtnPickUp.Visible = false;
            Dictionary<Card, string> dicBoxItems = new Dictionary<Card, string>(); //Makes a dictionary to link the text in the combobox with the cards.
            dicBoxItems.Clear();
            foreach (Card card in playerQueue.GetPlayer(1).hand.cards)
            {
                if ((PlayStatus == 1 && CanKill(card)) || PlayStatus == 2)
                {
                    string cardString;
                    if ((int)card.Symbol < 11)
                    {
                        cardString = (int)card.Symbol + " of " + card.Suit;
                    }
                    else
                    {
                        cardString = card.Symbol + " of " + card.Suit;
                    }
                    dicBoxItems.Add(card, cardString); //Adds cards to dictionary that can kill the previous card.
                    howMany++;
                }
            }
            game.CbxPlay.DataSource = new BindingSource(dicBoxItems, null); //Binds combobox to the dictionary.
            game.CbxPlay.DisplayMember = "Value";
            game.CbxPlay.ValueMember = "Key";
            game.CbxPlay.SelectedIndex = 0;
        }

        public override bool Play2ButtonClick(Game game) //Function for when user hits 'play' for the second time in five leaves.
        {
            game.LblAnnotations[0].Visible = false;
            Card cardToPlay = (Card)game.CbxPlay.SelectedValue; //Reads from combobox.
            discard.push(playerQueue.GetPlayer(1).hand.PlayCard(cardToPlay.Name, SoundBool));
            PickUpBool = false;
            WaitInitial(game); //Goes to waiting phase.
            UpdateLastPlayed(game, 1);
            UpdateHands(game, true);
            return true;
        }

        public void PickUpButtonClick(Game game) //Function for when user selects to pick up cards during five leaves.
        {
            game.BtnPickUp.Visible = false;
            game.BtnPlay.Visible = false;
            game.BtnHint.Visible = false;
            game.BtnRules.Visible = false;
            game.BtnGuide.Visible = false;
            PickUpBool = true;
            UpdateLastPlayed(game, 0);
            WaitInitial(game);
        }

        protected override int GetHowManyCardsToDeal() //Gets number of cards to deal in five leaves.
        {
            return 5 * PlayerNum;
        }

        protected override void UpdateDiscardPic(Game game) //Updates the image shown for the discard pile.
        {
            if (discard.GetHowMany() == 0)
            {
                game.PicDiscard.Image = null;
            }
            else
            {
                game.PicDiscard.Image = discard.GetCardByDistanceFromTop(1).Image; //Discard pile shows front of card.
            }
        }

        protected override void PickUpDiscard(Game game, int playerNum, int howMany) //Deals cards in discard pile to a specified player.
        {
            howMany = 0;
            for (int i = 0; i < 5; i++)
            {
                if (discard.GetHowMany() > 0)
                {
                    playerQueue.GetPlayer(playerNum).hand.Draw(discard.pop());
                    howMany++;
                }
            }
            UpdateLastPlayed(game, 0);
            base.PickUpDiscard(game, playerNum, howMany);
        }

        public override string GetHint(Game game) //Returns a hint message specific to five leaves.
        {
            game.BtnHint.Visible = false;
            UpdateScore(game, -5); //Removes 5 points, for asking for a hint.
            string message = "";
            Card suggestion = new Card(1, 1);
            if (PlayStatus == 1)
            {
                if (playerQueue.GetTopItem().hand.CanKillCard(discard.GetCardByDistanceFromTop(1), TrumpCard.Suit) == true)
                {
                    if (discard.GetCardByDistanceFromTop(1).Suit != TrumpCard.Suit && playerQueue.GetTopItem().hand.HowManySuit(discard.GetCardByDistanceFromTop(1).Suit) > 0)
                    {
                        foreach (Card card in playerQueue.GetTopItem().hand.cards)
                        {
                            if (card.Suit == discard.GetCardByDistanceFromTop(1).Suit && card.Symbol > discard.GetCardByDistanceFromTop(1).Symbol)
                            {
                                suggestion = card;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (Card card in playerQueue.GetTopItem().hand.cards)
                        {
                            if (card.Suit == TrumpCard.Suit && card.Symbol > discard.GetCardByDistanceFromTop(1).Symbol)
                            {
                                suggestion = card;
                                break;
                            }
                        }
                    }
                    string suggestionSymbol = suggestion.Symbol.ToString();
                    if ((int)suggestion.Symbol < 11)
                    {
                        int tempInt = (int)suggestion.Symbol;
                        suggestionSymbol = tempInt.ToString(); //Shows int version of symbol if under 11.
                    }
                    message = "You must play a card to kill the top card of the discard pile.\nYou should play your lowest possible card, which is " + suggestionSymbol + " of " + suggestion.Suit + ".";
                }
                else
                {
                    message = "You cannot play a card to kill the previous card.\nTherefore you must 'Pick Up' cards.";
                }
            }
            else
            {
                message = "You can play any card!\nPlay a low card if you wish to get rid of one.\nPlay a high card if you wish to force the next player to pick up.";
            }
            return message;
        }
    }
}