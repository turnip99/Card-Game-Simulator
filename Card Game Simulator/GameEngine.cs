using Card_Game_Simulator.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    enum NpcName
    {
        Bob = 1, Jim, Jack, Alan, Joel, Max, Harry, Luke, Bryan, Greg,
        Chris, Billy, Alex, Fred, Josh, Tony, Caleb, Felix, Hugo, Han,
        Ellie, Abbie, Kate, Helen, Alice, Jean, Amy, Carla, Carol, Lara,
        Lucy, Lynn, Haley, Wendy, Jill, Cara, Nikki, Selby, Holly, Grace
    } //This enum links the associated numbers with their npc names.

    class GameEngine
    {
        public Stack discard = new Stack(52); //Creates discard pile.

        public Stack deck = new Stack(52); //Creates deck.

        public Queue playerQueue; //Creates turns queue.

        public Random rnd = new Random(); //Creates random number generator object.

        private DataRow UserData;

        private DataRow GameData;

        //Makes various variables for later use.

        private bool soundBool;
        public bool SoundBool
        {
            get { return soundBool; }
            set { soundBool = value; }
        }

        private Color[] colours = new Color[3];
        public Color[] Colours
        {
            get { return colours; }
            set { colours = value; }
        }

        private int shuffleTime;
        public int ShuffleTime
        {
            get { return shuffleTime; }
            set { shuffleTime = value; }
        }

        private bool shuffleStatus;
        public bool ShuffleStatus
        {
            get { return shuffleStatus; }
            set { shuffleStatus = value; }
        }

        private int waitTime;
        public int WaitTime
        {
            get { return waitTime; }
            set { waitTime = value; }
        }

        private bool waitStatus;
        public bool WaitStatus
        {
            get { return waitStatus; }
            set { waitStatus = value; }
        }

        private int score = 100;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private char gameType;
        public char GameType
        {
            get { return gameType; }
            set { gameType = value; }
        }

        private int playerNum;
        public int PlayerNum
        {
            get { return playerNum; }
            set { playerNum = value; }
        }

        private int playStatus; //Holds which part of the turn the player is on during certain games.
        public int PlayStatus
        {
            get { return playStatus; }
            set { playStatus = value; }
        }

        private string playedString = "";
        public string PlayedString
        {
            get { return playedString; }
            set { playedString = value; }
        }

        private bool gameEnd = false; //Bool saves if game is ended.
        public bool GameEnd
        {
            get { return gameEnd; }
            set { gameEnd = value; }
        }

        public void Initialise(Game game, int playerNum, DataRow userData, DataRow gameData, DataRow settingsData, int speed, char gameType) //Sets Up Game.
        {
            DisableAllPics(game);
            if (userData != null)
            {
                game.TxtUser.Text = userData.ItemArray.GetValue(1).ToString();
            }
            else
            {
                game.TxtUser.Text = "Guest";
            }

            AssignSettings(settingsData);
            UserData = userData;
            GameData = gameData;
            GameType = gameType;
            playerQueue = new Queue(playerNum, GameType); //Creates queue.
            //Creates the 52 cards using a nested for loop.
            for (int suitNum = 1; suitNum < 5; suitNum++)
            {
                for (int symbolNum = 2; symbolNum < 15; symbolNum++)
                {
                    Card card = new Card(suitNum, symbolNum);
                    deck.push(card);
                }
            }
            ShuffleStart(game);
            PlayerNum = playerNum;
            if (playerNum == 3) //If only 3 players, destroy 3rd.
            {
                ThreePlayersOnly(game);
            }
            SelectNpcNames(game, game.TxtUser.Text, settingsData);
            DealCards(playerNum);
            game.SetUpElements();
            switch (GameType) //Choses which set-up method to call, depending on game type.
            {
                case 'C': game.CheatSetUpElements(speed); break;
                case 'F': game.FLSetUpElements(speed); break;
                default: break;
            }
            game.TxtScore.Text = Score.ToString();
            UpdateHands(game, false);
            game.LblLastPlayed.Text = "Last Played:\n" + PlayedString;
        }

        private void AssignSettings(DataRow settingsData)
        {
            if (settingsData == null)
            {
                soundBool = true;
                Colours[0] = Color.Orange;
                Colours[1] = Color.Blue;
                Colours[2] = Color.Cyan;
            }
            else
            {
                soundBool = (bool)settingsData.ItemArray.GetValue(1);
                switch (settingsData.ItemArray.GetValue(2).ToString())
                {
                    case "Orange": Colours[0] = Color.Orange; Colours[1] = Color.Blue; Colours[2] = Color.Cyan; break;
                    case "Yellow": Colours[0] = Color.Yellow; Colours[1] = Color.Purple; Colours[2] = Color.BlueViolet; break;
                    case "Green": Colours[0] = Color.LawnGreen; Colours[1] = Color.DarkRed; Colours[2] = Color.SandyBrown; break;
                    default: break;
                }
            }
        }

        private void SelectNpcNames(Game game, string username, DataRow settingsData) //selects non-duplicate randomised names for the npc players.
        {
            int[] namesTemp = new int[3]; //Stores numbers of names.
            int num = 0;
            bool repeated = false; //Saves if the number is a duplicate.
            for (int i = 0; i < 3; i++) //Loops for all three npcs.
            {
                if (settingsData == null || settingsData.ItemArray.GetValue(i + 3).ToString() == "Random") //If npcs are to be randomised.
                {
                    do
                    {
                        repeated = false;
                        num = rnd.Next(0, 41); //Selects random number between 0 and number of available names.
                        foreach (int name in namesTemp)
                        {
                            if (name == num) //If selected number is a duplicate.
                            {
                                repeated = true;
                                break;
                            }
                        }
                    } while (repeated == true);
                } //Loops until number isn't duplicate.
                else //Else, use assigned name (-1 is place-holder number)
                {
                    num = -1;
                }
                namesTemp[i] = num; //Saves number to array.
            }
            SetNpcImages(game, namesTemp, settingsData);
            playerQueue.GetPlayer(1).Name = username; //Sets username as name of first player.
            for (int i = 0; i < 4; i++)
            {
                game.LblNames[i] = new Label();
                game.LblNames[i].BackColor = Color.Transparent;
                game.LblNames[i].ForeColor = Colours[1];
                game.LblNames[i].Font = new Font("Tahoma", 13);
                game.LblNames[i].Size = new Size(155, 35);
                game.Controls.Add(game.LblNames[i]);
                game.LblNames[0].Size = new Size(190, 35);
                if (!(PlayerNum == 3 && i == 2))
                {
                    if (i != 0)
                    {
                        if (namesTemp[i - 1] > 0)
                        {
                            playerQueue.GetPlayer(i + 1).Name = ((NpcName)namesTemp[i - 1]).ToString(); //Converts numbers into names and places in name array.
                        }
                        else
                        {
                            playerQueue.GetPlayer(i + 1).Name = settingsData.ItemArray.GetValue(i + 2).ToString();
                        }
                    }
                    game.LblNames[i].Text = (playerQueue.GetPlayer(i + 1).Name).ToString();
                }
            }
            game.LblNames[0].Location = new Point(446, 558);
            game.LblNames[1].Location = new Point(25, 578);
            if (PlayerNum == 3)
            {
                game.LblNames[2].Visible = false;
            }
            else
            {
                game.LblNames[2].Location = new Point(510, 210);
                game.LblNames[2].BringToFront();
            }
            game.LblNames[3].Location = new Point(804, 578);
        }

        private void SetNpcImages(Game game, int[] namesInt, DataRow settingsData) //Sets male/female images for npcs depending on gender.
        {
            for (int i = 0; i < 3; i++)
            {
                //game.PicPlayer[i] = new PictureBox();
                if (namesInt[i] > 0)
                {
                    if (namesInt[i] > 20)
                    {
                        switch (i)
                        {
                            case 0: game.PicPlayer[i].Image = Resources.FRight; break;
                            case 1: game.PicPlayer[i].Image = Resources.FDown; break;
                            case 2: game.PicPlayer[i].Image = Resources.FLeft; break;
                            default: break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0: game.PicPlayer[i].Image = Resources.MRight; break;
                            case 1: game.PicPlayer[i].Image = Resources.MDown; break;
                            case 2: game.PicPlayer[i].Image = Resources.MLeft; break;
                            default: break;
                        }
                    }
                }
                else
                {
                    if ((bool)settingsData.ItemArray.GetValue(i + 6) == true)
                    {
                        switch (i)
                        {
                            case 0: game.PicPlayer[i].Image = Resources.MRight; break;
                            case 1: game.PicPlayer[i].Image = Resources.MDown; break;
                            case 2: game.PicPlayer[i].Image = Resources.MLeft; break;
                            default: break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0: game.PicPlayer[i].Image = Resources.FRight; break;
                            case 1: game.PicPlayer[i].Image = Resources.FDown; break;
                            case 2: game.PicPlayer[i].Image = Resources.FLeft; break;
                            default: break;
                        }
                    }
                }
            }
        }

        private void DealCards(int playerNum) //deals cards to hands.
        {
            int playerToRecieve = 0;
            int quantityToDeal = GetHowManyCardsToDeal();
            for (int i = 0; i < quantityToDeal; i++)
            {
                playerQueue.items[playerToRecieve].hand.Draw(deck.pop());
                if (playerToRecieve == playerNum - 1)
                {
                    playerToRecieve = 0;
                }
                else
                {
                    playerToRecieve++;
                }
            }
        }

        public virtual void TimerMainInterval(Game game) //Called by timer in form every 100ms. Mostly used for algorithms associated with the deck.
        {
            if (deck.GetHowMany() == 0) //If deck is empty, show no picture.
            {
                if (!ShuffleStatus)
                {
                    game.PicDeck.Image = null;
                }
            }
            else if (!ShuffleStatus) //If deck is not empty and is not shuffling, show back of card.
            {
                game.PicDeck.Image = Resources.BackOfCard;
            }
        }

        protected virtual void NewTurn(Game game) //Loops every turn.
        {
            if (GameEnd == true) //if game is over, stop the cycle of turns.
            {
                return;
            }
            if (playerQueue.CheckLength() > 1) //If there is more than 1 player remaining.
            {
                game.LblStatus.Text = playerQueue.GetTopItem().Name + "'s Turn!"; //Displays on screen the players turn.
                switch (playerQueue.GetTopItem().PlayerNum) //Enables animation of relevant player.
                {
                    case 1: if (playerQueue.GetPlayer(1).hand.GetCount() > 0) { UpdateScore(game, -1); } break;
                    default: game.PicPlayer[playerQueue.GetTopItem().PlayerNum - 2].Enabled = true; break;
                }
                Play(game);
            }
            else
            {
                SaveScore(game);
            }
        }

        protected void EndTurn(Game game) //Method that runs at the end of a turn (primarily to check if any players are out of cards).
        {
            UpdateHands(game, true);
            UpdateDiscardPic(game);
            if (playerQueue.GetTopItem().hand.GetCount() == 0) //If player has run out of cards.
            {
                MessageBox.Show(playerQueue.GetTopItem().Name + " is out of Cards!");
                if (playerQueue.GetTopItem().PlayerNum != 1)
                {
                    if (playerQueue.GetPlayer(1).hand.GetCount() > 0)
                    {
                        UpdateScore(game, -10);
                    }
                    game.LblValue[playerQueue.GetTopItem().PlayerNum - 1].Dispose(); //Dispose of objects associated with finished player/decrease user's score.
                    game.PicPlayer[playerQueue.GetTopItem().PlayerNum - 2].Dispose();
                    game.LblNames[playerQueue.GetTopItem().PlayerNum - 2].Dispose();
                    game.LblNames[playerQueue.GetTopItem().PlayerNum - 2].Text = "";
                }
                else
                {
                    SaveScore(game);
                }
                playerQueue.pop();
            }
            else
            {
                do  //Pushes player back onto queue.
                {
                    playerQueue.push(playerQueue.pop());
                } while (playerQueue.GetTopItem() == null);
            }
            NewTurn(game);
        }

        protected virtual void PickUpDiscard(Game game, int playerNum, int howMany) //Deals cards in discard pile to a specified player.
        {
            game.LblValue[playerNum - 1].Text = "(+" + howMany + ")"; //Changes text of player value labels based on player cheated.
            game.LblValue[playerNum - 1].ForeColor = Color.RoyalBlue;
        }

        private void UpdateHandPics(Game game)  //Updates images in picHand.
        {
            if (GameEnd == true)
            {
                return;
            }
            if (playerQueue.GetPlayer(1).hand.GetCount() <= 7)
            {
                playerQueue.GetPlayer(1).StartPosition = 0;
            }
            int position = playerQueue.GetPlayer(1).StartPosition;
            for (int i = 0; i < 7; i++)
            {
                if (i < GetHowManyShow())
                {
                    if (position < playerQueue.GetPlayer(1).hand.GetCount() && position >= 0)
                    {
                        game.PicHand[i].Image = playerQueue.GetPlayer(1).hand.cards[position].Image;
                        position++;
                    }
                }
                else
                {
                    game.PicHand[i].Image = null;
                }
            }
        }

        protected void DisableAllPics(Game game) //Stops all animations of npcs.
        {
            foreach (PictureBox pic in game.PicPlayer)
            {
                pic.Enabled = false;
            }
        }

        private void ThreePlayersOnly(Game game) //If 3 players, remove player 3.
        {
            game.PicPlayer[1].Dispose();
            game.LblValue[2].Dispose();
        }

        protected void HandLabelActivate(Game game) //Show all hand value labels.
        {
            foreach (Label label in game.LblValue)
            {
                label.Visible = true;
            }
        }

        protected void HandLabelDeactivate(Game game) //Hides all hand value labels.
        {
            foreach (Label label in game.LblValue)
            {
                label.Visible = false;
            }
        }

        private void ShuffleStart(Game game) //Starts off the shuffle.
        {
            if (deck.GetHowMany() != 0)
            {
                deck.MergeShuffleInitial(soundBool);
                game.PicDeck.Image = Resources.ShuffleGif;
                ShuffleStatus = true;
                ShuffleTime = 0;
                game.LblStatus.Text = "Shuffling...";
                HandLabelDeactivate(game);
            }
        }

        protected virtual void UpdateLastPlayed(Game game, int howMany) //Updates 'lblLastPlayed' and other form objects. Overridden by derived classes.
        {
            switch (playerQueue.GetTopItem().PlayerNum) //Changes position of lblPlayed/picPlayedCard based on current player.
            {
                case 1: game.LblPlayed.Location = new Point(448, 510); game.PicPlayedCard.Location = new Point(448, 340); break;
                case 2: game.LblPlayed.Location = new Point(73, 193); game.PicPlayedCard.Location = new Point(423, 315); break;
                case 3: game.LblPlayed.Location = new Point(454, 39); game.PicPlayedCard.Location = new Point(448, 290); break;
                case 4: game.LblPlayed.Location = new Point(822, 193); game.PicPlayedCard.Location = new Point(473, 315); break;
                default: break;
            }
        }

        protected void UpdateHands(Game game, bool currentPlayerOnly) //Used to update the count label of all hands and calls mathod to update P1's hand images.
        {
            if (currentPlayerOnly == false || playerQueue.GetTopItem().PlayerNum == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (playerQueue.GetPlayer(i + 1) != null)
                    {
                        game.LblValue[i].Text = "(" + playerQueue.GetPlayer(i + 1).hand.GetCount() + ")";
                        if (game.LblValue[i].ForeColor != Color.Black) { game.LblValue[i].ForeColor = Color.Black; }
                    }
                }
            }
            UpdateHandPics(game);
        }

        private int GetHowManyShow() //Calculates how many cards will be shown on screen.
        {
            int howManyShow;
            if (playerQueue.GetPlayer(1).hand.GetCount() < 7)
            {
                howManyShow = playerQueue.GetPlayer(1).hand.GetCount();
            }
            else
            {
                howManyShow = 7;
            }
            return howManyShow;
        }

        protected void DrawButtons(Game game) //Decides which buttons should be visible based on what part of the hand is displayed.
        {
            if (playerQueue.GetPlayer(1).StartPosition > 0 && !ShuffleStatus)
            {
                game.BtnLeft.Visible = true;
            }
            else
            {
                game.BtnLeft.Visible = false;
            }
            if (playerQueue.GetPlayer(1).StartPosition < playerQueue.GetPlayer(1).hand.GetCount() - 7 && !ShuffleStatus)
            {
                game.BtnRight.Visible = true;
            }
            else
            {
                game.BtnRight.Visible = false;
            }
        }

        protected void UpdateScore(Game game, int change) //Changes score and updates scoretext box.
        {
            Score += change;
            if (Score < 0)
            {
                Score = 0;
            }
            game.TxtScore.Text = Score.ToString();
        }

        public void ButtonLeftClick(Game game) //Left button moves displayed cards left by one.
        {
            if (playerQueue.GetPlayer(1).StartPosition > 0)
            {
                playerQueue.GetPlayer(1).StartPosition--;
                UpdateHandPics(game);
            }
        }

        public void ButtonRightClick(Game game) //Right button moves displayed cards right by one.
        {
            if (playerQueue.GetPlayer(1).StartPosition < playerQueue.GetPlayer(1).hand.GetCount() - 7)
            {
                playerQueue.GetPlayer(1).StartPosition++;
                UpdateHandPics(game);
            }
        }

        private void SaveScore(Game game) //Saves scores and closes form.
        {
            if (UserData != null)
            {
                DatabaseConnection objConnect = new DatabaseConnection(); //Instantiates the database connection.
                objConnect.connectionString = Settings.Default.CardGameDatabaseConnectionString;
                objConnect.SQL = Settings.Default.SqlSelectFromtblScore; //Uses sql string that links to tblScore.
                DataSet dataSet = objConnect.GetConnection; //Gets datset from the string/sql sent to the connection class.
                DataRow row = dataSet.Tables[0].NewRow(); //Creates new row for local dataset.
                row[1] = UserData.ItemArray.GetValue(1); //First row = user.
                row[2] = GameData.ItemArray.GetValue(1); //Second row = game.
                row[3] = Score; //Third row = score.
                row[4] = DateTime.Now; //Fourth row = date/time.
                row[5] = PlayerNum - playerQueue.CheckLength() + 1; //Fifth row = position (eg 1st/2nd/3rd).
                dataSet.Tables[0].Rows.Add(row); //Adds row to local dataset.
                try
                {
                    objConnect.UpdateDatabase(dataSet); //Uses connector to update database using local dataset.
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            game.Close();
            GameEnd = true;
            MessageBox.Show("Game Over!\nScore = " + Score); //Show finishing message.
        }

        //Virtual methods for derived classes to override.

        protected virtual void Play(Game game) { }

        protected virtual void PlayPlayer(Game game) { }

        protected virtual void WaitInitial(Game game) { }

        public virtual void WaitInterval(Game game) { }

        public virtual void PlayButtonClick(Game game) { }

        public virtual bool Play2ButtonClick(Game game) { MessageBox.Show(""); return true; }

        protected virtual int GetHowManyCardsToDeal() { return 0; }

        protected virtual void UpdateDiscardPic(Game game) { }

        public virtual string GetHint(Game game) { return ""; }
    }
}