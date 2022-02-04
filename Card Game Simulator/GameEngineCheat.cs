using Card_Game_Simulator.Properties;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    class GameEngineCheat : GameEngine
    {
        private NPCAICheat npcai = new NPCAICheat(); //Creates class with npc's decision algorithms.

        private Symbol nextSymbol = (Symbol)14;
        internal Symbol NextSymbol
        {
            get { return nextSymbol; }
            set { nextSymbol = value; }
        }

        private int revealTime;
        public int RevealTime
        {
            get { return revealTime; }
            set { revealTime = value; }
        }

        private Player caller = null;
        public Player Caller
        {
            get { return caller; }
            set { caller = value; }
        }

        private bool cheatBool = false;
        public bool CheatBool
        {
            get { return cheatBool; }
            set { cheatBool = value; }
        }

        protected override void NewTurn(Game game) //Override for new turn algorithm.
        {
            CheatBool = false;
            game.BtnCallCheat.Visible = false;
            base.NewTurn(game);
        }

        public override void TimerMainInterval(Game game) //Main timer algorithm for cheat.
        {
            if (GameEnd == false) //Draw buttons unless game is over.
            {
                DrawButtons(game);
            }
            if (ShuffleStatus) //If shuffling, count to 16 ticks then stop.
            {
                if (ShuffleTime == 16)
                {
                    foreach (PictureBox box in game.PicHand)
                    {
                        box.Visible = true;
                    }
                    HandLabelActivate(game);
                    ShuffleStatus = false; NewTurn(game);
                }
                ShuffleTime++;
            }
            base.TimerMainInterval(game);
        }

        protected override void UpdateLastPlayed(Game game, int howMany)//Updates UI with last played cards in a format suitable for cheat.
        {
            StringBuilder builder = new StringBuilder(); //String holds what will be display in 'lblLastPlayed'.
            npcai.HowManyLastPlayed = howMany;
            if (playerQueue.GetTopItem().PlayerNum != 1)
            {
                game.BtnCallCheat.Visible = true; //If not player's turn, makes 'call cheat' button active.
            }
            switch (howMany) //Changes numbers into their word equivalent.
            {
                case 1: builder.Append("One "); break;
                case 2: builder.Append("Two "); break;
                case 3: builder.Append("Three "); break;
                case 4: builder.Append("Four "); break;
                default: break;
            }
            if (NextSymbol > (Symbol)10)
            {
                builder.Append(NextSymbol.ToString()); //If a word-symbol, add the word to the stringbuilder.
            }
            else
            {
                builder.Append((int)NextSymbol); //If a number-symbol, add the number to the stringbuilder.
            }
            if (howMany > 1)
            {
                builder.Append("s");
            }
            PlayedString = builder.ToString();
            game.LblPlayed.Text = "\"" + PlayedString + "\"";
            game.LblLastPlayed.Text = "Last Played:\n" + PlayedString;
            base.UpdateLastPlayed(game, howMany);
            switch (playerQueue.GetTopItem().PlayerNum) //Changes position of lblPlayed/picPlayedCard based on current player.
            {
                case 1: game.LblPlayed.Location = new Point(448, 510);
                    game.PicPlayedCard.Location = new Point(448, 340); break;
                case 2: game.LblPlayed.Location = new Point(73, 193);
                    game.PicPlayedCard.Location = new Point(423, 315); break;
                case 3: game.LblPlayed.Location = new Point(454, 39);
                    game.PicPlayedCard.Location = new Point(448, 290); break;
                case 4: game.LblPlayed.Location = new Point(822, 193);
                    game.PicPlayedCard.Location = new Point(473, 315); break;
                default: break;
            }
        }

        protected override void Play(Game game) //Method for playing cards during cheat.
        {
            if (playerQueue.GetTopItem().PlayerNum == 1) //If it's the player's turn.
            {
                PlayPlayer(game);
            }
            else
            {
                if (discard.GetHowMany() == 0) //If free move.
                {
                    nextSymbol = npcai.GetSymbolToPlay(playerQueue.GetTopItem().hand); //Finds how many cards the npc can legally play.
                }
                int howMany = playerQueue.GetTopItem().hand.HowManySymbol(NextSymbol); //Finds how many cards the npc can legally play.
                int chance = npcai.Decide(howMany, playerQueue.GetTopItem().hand.GetCount()); //Finds chance that it will play or cheat.
                int random = (rnd.Next(1, 100));
                if ((random < chance && rnd.Next(1, 10) < 7) || discard.GetHowMany() == 0) //If user plays legally.
                {
                    npcai.Play(ref playerQueue, NextSymbol, ref playerQueue.GetTopItem().hand, ref discard, SoundBool); //NPCAI method to play cards.
                }
                else //If user cheats.
                {
                    howMany = npcai.HowManyCheat(playerQueue.GetTopItem().hand, NextSymbol);
                    CheatBool = npcai.Cheat(ref playerQueue, ref playerQueue.GetTopItem().hand, ref discard, howMany, NextSymbol, SoundBool); //NPCAI method to cheat.
                }
                UpdateLastPlayed(game, howMany);
                WaitInitial(game);
            }
        }

        protected override void PlayPlayer(Game game) //Method for starting player's turn during cheat.
        {
            if (discard.GetHowMany() == 0) //If free move.
            {
                game.BtnCheat.Enabled = false;
                game.BtnCheat.BackColor = Color.WhiteSmoke;
                game.BtnPlay.Enabled = true;
                game.BtnPlay.BackColor = Colours[0];
            }
            else //Else (if not free move)
            {
                game.BtnCheat.Enabled = true; //Enabled play button if not free move.
                game.BtnCheat.BackColor = Colours[0];
                if (playerQueue.GetPlayer(1).hand.HowManySymbol(NextSymbol) > 0)
                {
                    game.BtnPlay.Enabled = true; //Enabled play button if legal move can be made.
                    game.BtnPlay.BackColor = Colours[0];
                }
                else
                {
                    game.BtnPlay.Enabled = false;
                    game.BtnPlay.BackColor = Color.WhiteSmoke;
                }
            }
            game.BtnPlay.Visible = true; //Makes main buttons visible.
            game.BtnCheat.Visible = true;
            game.BtnHint.Visible = true;
            game.BtnRules.Visible = true;
            game.BtnGuide.Visible = true;
            if (discard.GetHowMany() > 0)
            {
                if ((int)NextSymbol < 11) //Setting values of button's text.
                {
                    game.BtnPlay.Text = "Play " + (int)NextSymbol + "s";
                }
                else
                {
                    game.BtnPlay.Text = "Play " + NextSymbol + "s";
                }
            }
            else
            {
                game.BtnPlay.Text = "Play Any Card Type";
            }
        }

        protected override void WaitInitial(Game game) //Initiate waiting phase.
        {
            UpdateHands(game, false);
            game.BtnHint.Visible = false;
            game.BtnRules.Visible = false;
            game.BtnGuide.Visible = false;
            WaitTime = 0;
            WaitStatus = true;
            game.TimerWait.Start();
            game.PicPlayedCard.Visible = true;
            game.LblPlayed.Visible = true;
            game.PicPlayedCard.BringToFront();
        }

        public override void WaitInterval(Game game) //Increments while in waiting phase after a play.
        {
            if (WaitTime > 6 && WaitStatus)
            {
                DisableAllPics(game);
                game.TimerWait.Stop();
                WaitTime = 0;
                WaitStatus = false;
                IncreaseSymbol();
                EndTurn(game);
            }
            else
            {
                if (WaitStatus)
                {
                    WaitTime++;
                    if (WaitTime == 2)
                    {
                        Caller = npcai.Callout(playerQueue.items, playerQueue.GetPlayer(1), playerQueue.GetTopItem(), discard.GetHowMany(), NextSymbol, playerQueue.CheckLength());
                    }
                    if (WaitTime > 2 && WaitTime < 5)
                    {
                        if (rnd.Next(1, 3) == 1 && Caller != null)
                        {
                            if (Caller != null) //If someone has called out.
                            {
                                RevealInitial(game); //Go to card revealing function.
                            }
                        }
                    }
                    if (WaitTime == 5)
                    {
                        if (Caller != null) //If someone has called out.
                        {
                            RevealInitial(game); //Go to card revealing function.
                        }
                    }
                    if (WaitTime == 3) //Get rid of these elements half way through the wait time.
                    {
                        UpdateDiscardPic(game);
                        game.PicPlayedCard.Visible = false;
                        game.LblPlayed.Visible = false;
                    }
                    if (WaitTime < 3)
                    {
                        Point Loc = game.PicPlayedCard.Location;
                        switch (playerQueue.GetTopItem().PlayerNum) //Decides which way card moves towards discard pile.
                        {
                            case 1: Loc.Y -= 7; game.PicPlayedCard.Location = Loc; break;
                            case 2: Loc.X += 7; game.PicPlayedCard.Location = Loc; break;
                            case 3: Loc.Y += 7; game.PicPlayedCard.Location = Loc; break;
                            case 4: Loc.X -= 7; game.PicPlayedCard.Location = Loc; break;
                            default: break;
                        }
                    }
                }
            }
        }

        public void RevealInitial(Game game) //Initiate reveal phase.
        {
            if (SoundBool)
            {
                SoundPlayer sndCallOut = new SoundPlayer(Resources.CheatCallOut);
                sndCallOut.Play(); //Play call-out sound.
            }
            game.LblPlayed.ForeColor = Color.Red;
            game.LblPlayed.Text = "\"Cheat!\"";
            switch (Caller.PlayerNum) //Changes position of lblPlayed based on caller.
            {
                case 1: game.LblPlayed.Location = new Point(448, 510); break;
                case 2: game.LblPlayed.Location = new Point(73, 193); break;
                case 3: game.LblPlayed.Location = new Point(454, 39); break;
                case 4: game.LblPlayed.Location = new Point(822, 193); break;
                default: break;
            }
            game.LblPlayed.Visible = true;
            game.LblStatus.Text = caller.Name + " Has Accused " + playerQueue.GetTopItem().Name + "!";
            game.LblStatus.ForeColor = Color.Red;
            DisableAllPics(game);
            game.TimerWait.Stop(); //Stop the wait timer and associated variables.
            WaitTime = 0;
            WaitStatus = false;
            UpdateDiscardPic(game);
            game.PicPlayedCard.Visible = false;
            game.BtnCallCheat.Visible = false;
            game.PicDiscard.Visible = false;
            game.PicDeck.Visible = false;
            game.LblLastPlayed.Visible = false;
            RevealTime = 0;
            game.TimerReveal.Start(); //Start the reveal timer.
        }

        public void RevealInterval(Game game) //Increments while in reveal phase (after a cheat call-out).
        {
            if (RevealTime > 16) //End of timer.
            {
                Caller = null;
                UpdateHands(game, false);
                game.LblLastPlayed.Text = "";
                game.LblPlayed.Font = new Font("Tahoma", 14);
                game.LblPlayed.ForeColor = Color.Black;
                game.PicDiscard.Visible = true;
                game.PicDeck.Visible = true;
                game.LblLastPlayed.Visible = true;
                game.LblPlayed.Visible = false;
                game.LblPlayed.ForeColor = Color.Black;
                game.LblStatus.ForeColor = Color.RoyalBlue;
                game.TimerReveal.Stop();
                IncreaseSymbol();
                EndTurn(game);
            }
            else
            {
                RevealTime++;
                if (RevealTime == 3)
                {
                    game.LblPlayed.Visible = false;
                    game.LblRevealPlayed[0].Visible = true;
                    game.LblRevealPlayed[0].Text = "Claimed: " + PlayedString;
                }
                if (RevealTime == 4)
                {
                    game.LblRevealPlayed[1].Visible = true;
                    for (int i = 0; i < npcai.HowManyLastPlayed; i++)
                    {
                        game.PicReveal[i].Visible = true;
                    }
                }
                if (RevealTime == 5)
                {
                    for (int i = 0; i < npcai.HowManyLastPlayed; i++)
                    {
                        if (discard.GetCardByDistanceFromTop(i + 1) != null)
                        {
                            game.PicReveal[i].Image = discard.GetCardByDistanceFromTop(i + 1).Image;
                        }
                    }
                }
                if (RevealTime == 8)
                {
                    game.LblPlayed.Font = new Font("IMPACT", 14);
                    if (CheatBool)
                    {
                        if (SoundBool)
                        {
                            SoundPlayer sndCheat = new SoundPlayer(Resources.CheatReveal);
                            sndCheat.Play();
                        }
                        game.LblPlayed.Text = "CHEAT";
                        game.LblPlayed.Visible = true;
                        switch (playerQueue.GetTopItem().PlayerNum) //Changes position of lblPlayed based on current player.
                        {
                            case 1: game.LblPlayed.Location = new Point(448, 510); break;
                            case 2: game.LblPlayed.Location = new Point(73, 193); break;
                            case 3: game.LblPlayed.Location = new Point(454, 39); break;
                            case 4: game.LblPlayed.Location = new Point(822, 193); break;
                            default: break;
                        }
                    }
                    else
                    {
                        if (SoundBool)
                        {
                            SoundPlayer sndBadCall = new SoundPlayer(Resources.BadCallReveal);
                            sndBadCall.Play();
                        }
                        game.LblPlayed.Text = "FALSE CALL";
                        game.LblPlayed.Visible = true;
                        switch (Caller.PlayerNum) //Changes position of lblPlayed based on caller.
                        {
                            case 1: game.LblPlayed.Location = new Point(448, 510); break;
                            case 2: game.LblPlayed.Location = new Point(73, 193); break;
                            case 3: game.LblPlayed.Location = new Point(454, 39); break;
                            case 4: game.LblPlayed.Location = new Point(822, 193); break;
                            default: break;
                        }
                    }
                }
                if (RevealTime > 8 && RevealTime < 15) //Flashing coloued alert.
                {
                    if (RevealTime == 11)
                    {
                        if (CheatBool)
                        {
                            PickUpDiscard(game, playerQueue.GetTopItem().PlayerNum, 0);
                        }
                        else
                        {
                            PickUpDiscard(game, Caller.PlayerNum, 0);
                        }
                    }
                    if (game.LblPlayed.ForeColor == Color.Red)
                    {
                        if (CheatBool)
                        {
                            game.LblPlayed.ForeColor = Color.RoyalBlue;
                        }
                        else
                        {
                            game.LblPlayed.ForeColor = Color.Green;
                        }
                        return;
                    }
                    else
                    {
                        game.LblPlayed.ForeColor = Color.Red;
                        return;
                    }
                }
                if (RevealTime == 15)
                {
                    foreach (Label label in game.LblRevealPlayed)
                    {
                        label.Visible = false;
                    }
                    foreach (PictureBox box in game.PicReveal)
                    {
                        box.Visible = false;
                        box.Image = Resources.BackOfCard;
                    }
                }
            }
        }

        private void IncreaseSymbol() //Ascends nextSymbol to next value.
        {
            if (NextSymbol == (Symbol)14)
            {
                NextSymbol = (Symbol)2; //If symbol = 13 (king), loop back to 1 (ace).
            }
            else
            {
                NextSymbol++; //otherwise, add one to symbol.
            }
        }

        public void UpdateCheatComboBox(Game game, object box) //Updates values in the comboboxes when selecting cards to cheat with.
        {
            ComboBox cbx = (ComboBox)box; //Object of sender combobox.
            if (cbx.Location.X == game.CbxCheat[0, 0].Location.X) //Only applies to symbol comboboxes (have same x value).
            {
                for (int i = 0; i < 4; i++)
                {
                    if (cbx.Location != game.CbxCheat[0, i].Location && cbx.SelectedItem != null && game.CbxCheat[0, i].SelectedItem != null)
                    {
                        if (cbx.SelectedIndex == game.CbxCheat[0, i].SelectedIndex)
                        {
                            cbx.SelectedItem = null; //Clears the symbol combobox if it shares value with another.
                        }
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    game.CbxCheat[1, i].Items.Clear(); //Clears combobox.
                    game.CbxCheat[1, i].Items.Add(0);
                    if (game.CbxCheat[0, i].SelectedItem != null)
                    {
                        for (int j = 1; j <= playerQueue.GetPlayer(1).hand.HowManySymbol((Symbol)game.CbxCheat[0, i].SelectedItem); j++)
                        {
                            game.CbxCheat[1, i].Items.Add(j); //Assigns values to quantity comboboxes.
                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++) //Sets null default values to 0 for quantities.
            {
                if (game.CbxCheat[1, i].SelectedItem == null)
                {
                    game.CbxCheat[1, i].SelectedItem = 0;
                }
            }
        }

        public void UpdatePlayComboBox(Game game, object box) //Updates values in the comboboxes when selecting cards to play with after discard is emptied.
        {
            game.CbxPlayFree[1].Items.Clear();
            for (int i = 1; i < playerQueue.GetPlayer(1).hand.HowManySymbol((Symbol)game.CbxPlayFree[0].SelectedItem) + 1; i++)
            {
                game.CbxPlayFree[1].Items.Add(i);
            }
            game.CbxPlayFree[1].SelectedIndex = game.CbxPlayFree[1].Items.Count - 1;
        }

        public override void PlayButtonClick(Game game) //Function for when user choses to play legally in cheat.
        {
            game.BtnCheat.Visible = false;
            if (discard.GetHowMany() > 0) //If player must play consecutive symbol.
            {
                game.LblAnnotations[1].Visible = true;
                game.LblAnnotations[1].Location = new Point(180, 755);
                int howMany = 0;
                game.CbxPlay.Visible = true;
                game.CbxPlay.Items.Clear(); //Empties combobox.
                howMany = playerQueue.GetPlayer(1).hand.HowManySymbol(NextSymbol); //Finds how many cards the npc can legally play.
                for (int i = 1; i < howMany + 1; i++) //Add every number up to and including the number of cards playable to combobox.
                {
                    game.CbxPlay.Items.Add(i);
                }
                game.CbxPlay.SelectedIndex = game.CbxPlay.FindString(howMany.ToString()); //Sets default combobox value as highest.
            }
            else //Else, player may play any symbol.
            {
                game.LblAnnotations[0].Visible = true;
                game.LblAnnotations[0].Location = new Point(180, 765);
                game.LblAnnotations[1].Visible = true;
                game.LblAnnotations[1].Location = new Point(150, 810);
                foreach (ComboBox box in game.CbxPlayFree)
                {
                    box.Visible = true;
                    box.Items.Clear();
                }
                for (int i = 2; i < 15; i++) //Assigns values to symbol combobox.
                {
                    if (playerQueue.GetPlayer(1).hand.HowManySymbol((Symbol)i) > 0)
                    {
                        if (i > 1 && i < 11)
                        {
                            game.CbxPlayFree[0].Items.Add(i);
                        }
                        else
                        {
                            game.CbxPlayFree[0].Items.Add((Symbol)i);
                        }
                    }
                }
                game.CbxPlayFree[0].SelectedIndex = 0;
            }
        }

        public void CheatButtonClick(Game game) //Function for when user decides to cheat.
        {
            game.LblAnnotations[0].Visible = true;
            game.LblAnnotations[0].Location = new Point(165, 739);
            game.LblAnnotations[1].Visible = true;
            game.LblAnnotations[1].Location = new Point(295, 739);
            game.BtnPlay.Visible = false; //Makes main buttons invisible.
            game.BtnCheat.Visible = false;
            game.BtnPlay2.Visible = true; //Makes new objects visible.
            foreach (ComboBox box in game.CbxCheat)
            {
                box.Visible = true;
            }
            foreach (ComboBox box in game.CbxCheat)
            {
                box.Items.Clear();
            }
            for (int i = 2; i < 15; i++) //Assgins values to symbol comboboxes.
            {
                if (playerQueue.GetPlayer(1).hand.HowManySymbol((Symbol)i) > 0)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i > 1 && i < 11)
                        {
                            game.CbxCheat[0, j].Items.Add(i);
                        }
                        else
                        {
                            game.CbxCheat[0, j].Items.Add((Symbol)i);
                        }
                    }
                }
            }
            int numOfSymbols = 0;
            for (int i = 2; i < 15; i++) //Checks how many types of symbols are in hand (if less than 4, it prevents crashing in next loop).
            {
                if (playerQueue.GetPlayer(1).hand.HowManySymbol((Symbol)i) > 0)
                {
                    numOfSymbols++;
                }
            }
            for (int Position = 0; Position < 4; Position++) //Sets default values for symbol comboboxes.
            {
                if (Position < numOfSymbols)
                {
                    game.CbxCheat[0, Position].Visible = true;
                    game.CbxCheat[1, Position].Visible = true;
                    game.CbxCheat[0, Position].SelectedIndex = Position;
                }
                else
                {
                    game.CbxCheat[0, Position].Visible = false;
                    game.CbxCheat[1, Position].Visible = false;
                }
            }
        }

        public override bool Play2ButtonClick(Game game) //Function for when user hits 'play' for the second time in five leaves.
        {
            foreach (Label label in game.LblAnnotations)
            {
                label.Visible = false;
            }
            int howManyShift;
            if (!game.CbxCheat[0, 0].Visible) //If playing legal card.
            {
                int howManyPlay = 0;
                int howManyPlayed = 0;
                if (discard.GetHowMany() > 0) //If not free move.
                {
                    howManyPlay = int.Parse(game.CbxPlay.SelectedItem.ToString()); //Reads from combobox.
                    for (int i = 0; i < playerQueue.GetPlayer(1).hand.GetCount(); i++) //Plays correct number of cards from hand.
                    {
                        if (playerQueue.GetPlayer(1).hand.cards[i].Symbol == NextSymbol && howManyPlayed < howManyPlay)
                        {
                            discard.push(playerQueue.GetPlayer(1).hand.PlaySymbol(playerQueue.GetPlayer(1).hand.cards[i].Symbol, SoundBool));
                            i--;
                            howManyPlayed++;
                        }
                    }
                }
                else //Else (if free move).
                {
                    howManyPlay = int.Parse(game.CbxPlayFree[1].SelectedItem.ToString()); //Reads from combobox.
                    for (int i = 0; i < playerQueue.GetPlayer(1).hand.GetCount(); i++) //Plays correct number of cards from hand.
                    {
                        if (playerQueue.GetPlayer(1).hand.cards[i].Symbol == (Symbol)game.CbxPlayFree[0].SelectedItem && howManyPlayed < howManyPlay)
                        {
                            discard.push(playerQueue.GetPlayer(1).hand.PlaySymbol(playerQueue.GetPlayer(1).hand.cards[i].Symbol, SoundBool));
                            i--;
                            howManyPlayed++;
                        }
                    }
                    NextSymbol = (Symbol)game.CbxPlayFree[0].SelectedItem;
                    foreach (ComboBox box in game.CbxPlayFree) //Makes all comboboxes in array invisible.
                    {
                        box.Visible = false;
                    }
                }
                UpdateLastPlayed(game, howManyPlay);
                howManyShift = howManyPlay;
            }
            else //If cheating.
            {
                int howManyPlay = 0;
                for (int i = 0; i < 4; i++)
                {
                    howManyPlay += (int)game.CbxCheat[1, i].SelectedItem;
                }
                if (howManyPlay == 0) //Leave event if no cards were selected.
                {
                    MessageBox.Show("You must select at least one card!");
                    return false;
                }
                if (howManyPlay > 4) //Leave event if too many cards were selected.
                {
                    MessageBox.Show("You can only play a maximum of four cards!");
                    return false;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (game.CbxCheat[1, i].SelectedItem != null)
                    {
                        for (int j = 0; j < (int)game.CbxCheat[1, i].SelectedItem; j++)
                        {
                            if (CheatBool == false && (Symbol)game.CbxCheat[0, i].SelectedItem != NextSymbol)
                            {
                                CheatBool = true;
                            }
                            discard.push(playerQueue.GetPlayer(1).hand.PlaySymbol((Symbol)game.CbxCheat[0, i].SelectedItem, SoundBool));
                        }
                    }
                }
                UpdateLastPlayed(game, howManyPlay);
                foreach (ComboBox box in game.CbxCheat) //Makes all comboboxes in array invisible.
                {
                    box.Visible = false;
                }
                howManyShift = howManyPlay;
            }
            for (int i = 0; i < howManyShift; i++)
            {
                if (playerQueue.GetPlayer(1).StartPosition > 0)
                {
                    playerQueue.GetPlayer(1).StartPosition--;
                }
            }
            WaitInitial(game); //Goes to waiting phase.
            return true;
        }

        protected override int GetHowManyCardsToDeal()
        {
            return 52;
        } //Gets number of cards to deal in cheat.

        protected override void UpdateDiscardPic(Game game) //Updates the image shown for the discard pile.
        {
            if (discard.GetHowMany() == 0)
            {
                game.PicDiscard.Image = null;
            }
            else
            {
                game.PicDiscard.Image = Resources.BackOfCard; //Discard pile shows back of card.
            }
        }

        protected override void PickUpDiscard(Game game, int playerNum, int howMany) //Deals cards in discard pile to a specified player.
        {
            howMany = discard.GetHowMany();
            while (discard.GetHowMany() > 0)
            {
                playerQueue.GetPlayer(playerNum).hand.Draw(discard.pop()); //Deal card from discard pile to player.
            }
            base.PickUpDiscard(game, playerNum, howMany);
        }

        public override string GetHint(Game game) //Returns a hint message specific to cheat.
        {
            game.BtnHint.Visible = false;
            UpdateScore(game, -5); //Removes 5 points, for asking for a hint.
            string nextSymbolString = NextSymbol.ToString(); //Shows next symbol as a string, used for hint messages for certain situations.
            if ((int)NextSymbol <= 11)
            {
                int temp = (int)NextSymbol;
                nextSymbolString = temp.ToString(); //Shows int version of symbol if under 11.
            }
            string message = "";
            if (discard.GetHowMany() > 0) //If cannot do free move.
            {
                if (playerQueue.GetPlayer(1).hand.HowManySymbol(NextSymbol) > 0)
                {
                    message = "You are able to play a card, so there is little point in cheating.\nPlay your " + nextSymbolString.ToString() + "s.";
                }
                else
                {
                    if (discard.pointer > 20)
                    {
                        message = "You are able unable to play a card, and so you must cheat.\nAs the other players have relatively few cards in their hands,\nthey will be less likely to know if you cheat.\nIt may be possible to get away with playing 2 or 3 cards.";
                    }
                    else
                    {

                    }
                    message = "You are able unable to play a card, and so you must cheat.\nIn order to avoid suspicion, it may be wise to only play 1 card.";
                }
            }
            else
            {
                message = "You can play any card. Play the symbol that you have the most of.";
            }
            return message;
        }
    }
}