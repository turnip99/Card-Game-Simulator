using Card_Game_Simulator.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    public partial class Game : Form
    {
        GameEngine gameEngine;

        //Makes various form objects for later use.
        private Timer timerWait = new Timer();
        public Timer TimerWait
        {
            get { return timerWait; }
            set { timerWait = value; }
        }

        private Timer timerReveal = new Timer();
        public Timer TimerReveal
        {
            get { return timerReveal; }
            set { timerReveal = value; }
        }

        private Label[] lblNames = new Label[4];
        public Label[] LblNames
        {
            get { return lblNames; }
            set { lblNames = value; }
        }

        private Button btnLeft = new Button(); //Creates the custom buttons.
        public Button BtnLeft
        {
            get { return btnLeft; }
            set { btnLeft = value; }
        }

        private Button btnRight = new Button();
        public Button BtnRight
        {
            get { return btnRight; }
            set { btnRight = value; }
        }

        private Button btnPlay = new Button();
        public Button BtnPlay
        {
            get { return btnPlay; }
            set { btnPlay = value; }
        }

        private Button btnCheat = new Button();
        public Button BtnCheat
        {
            get { return btnCheat; }
            set { btnCheat = value; }
        }

        private ComboBox cbxPlay = new ComboBox();
        public ComboBox CbxPlay
        {
            get { return cbxPlay; }
            set { cbxPlay = value; }
        }

        private Button btnPlay2 = new Button();
        public Button BtnPlay2
        {
            get { return btnPlay2; }
            set { btnPlay2 = value; }
        }

        private ComboBox[] CbxplayFree = new ComboBox[2];
        public ComboBox[] CbxPlayFree
        {
            get { return CbxplayFree; }
            set { CbxplayFree = value; }
        }

        private ComboBox[,] cbxCheat = new ComboBox[2, 4];
        public ComboBox[,] CbxCheat
        {
            get { return cbxCheat; }
            set { cbxCheat = value; }
        }

        private Label lblPlayed = new Label();
        public Label LblPlayed
        {
            get { return lblPlayed; }
            set { lblPlayed = value; }
        }

        private PictureBox picPlayedCard = new PictureBox();
        public PictureBox PicPlayedCard
        {
            get { return picPlayedCard; }
            set { picPlayedCard = value; }
        }

        private Label[] lblRevealPlayed = new Label[2];
        public Label[] LblRevealPlayed
        {
            get { return lblRevealPlayed; }
            set { lblRevealPlayed = value; }
        }

        private PictureBox[] picReveal = new PictureBox[4];
        public PictureBox[] PicReveal
        {
            get { return picReveal; }
            set { picReveal = value; }
        }

        private PictureBox[] picHand = new PictureBox[7];
        public PictureBox[] PicHand
        {
            get { return picHand; }
            set { picHand = value; }
        }

        private PictureBox picTrump = new PictureBox();
        public PictureBox PicTrump
        {
            get { return picTrump; }
            set { picTrump = value; }
        }

        private Button btnPickUp = new Button();
        public Button BtnPickUp
        {
            get { return btnPickUp; }
            set { btnPickUp = value; }
        }

        private Label lblDeckNum = new Label();
        public Label LblDeckNum
        {
            get { return lblDeckNum; }
            set { lblDeckNum = value; }
        }

        PictureBox picDrawnCardDeck = new PictureBox();
        public PictureBox PicDrawnCardDeck
        {
            get { return picDrawnCardDeck; }
            set { picDrawnCardDeck = value; }
        }

        private Label[] lblAnnotations = new Label[2];
        public Label[] LblAnnotations
        {
            get { return lblAnnotations; }
            set { lblAnnotations = value; }
        }

        //Universal Methods.

        public Game(int playerNum, DataRow userData, DataRow gameData, DataRow settingsData, int speed) //Constructor.
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            timerMain.Tick += new EventHandler(timerMain_Tick);
            char gameType = ((gameData.ItemArray.GetValue(1).ToString()).ToCharArray())[0];
            switch (gameType) //Choses which type of GameEngine object is required, depending on game type.
            {
                case 'C': gameEngine = new GameEngineCheat(); break;
                case 'F': gameEngine = new GameEngineFiveLeaves(); break;
                default: break;
            }
            gameEngine.Initialise(this, playerNum, userData, gameData, settingsData, speed, gameType);
        }

        public void SetUpElements() //Sets key properties of custom form objects not specific to a game.
        {
            TimerWait.Tick += new EventHandler(Wait_Tick);
            PicDeck.SizeMode = PictureBoxSizeMode.Zoom;
            PicDiscard.SizeMode = PictureBoxSizeMode.Zoom;
            PicPlayedCard.SizeMode = PictureBoxSizeMode.Zoom;
            PicPlayedCard.Image = Resources.BackOfCard;
            PicPlayedCard.Size = new Size(60, 88);
            PicPlayedCard.Location = PicDiscard.Location;
            PicPlayedCard.Visible = false;
            PicPlayedCard.BackColor = Color.Transparent;
            Controls.Add(PicPlayedCard);
            BtnLeft.Size = new Size(75, 138);
            BtnLeft.Location = new Point(180, 580);
            BtnLeft.BackgroundImage = Resources.ButtonLeft;
            BtnLeft.Click += new EventHandler(btnLeft_Click);
            Controls.Add(BtnLeft);
            BtnRight.Click += new EventHandler(btnRight_Click);
            BtnRight.Size = new Size(75, 138);
            BtnRight.Location = new Point(726, 580);
            BtnRight.BackgroundImage = Resources.ButtonRight;
            Controls.Add(BtnRight);
            Point startShowPosition = new Point(260, 612); //position of the first item in the display.
            {
                for (int counter = 0; counter < 7; counter++)
                {
                    PicHand[counter] = new PictureBox();
                    PicHand[counter].SizeMode = PictureBoxSizeMode.Zoom;
                    PicHand[counter].Location = new Point(startShowPosition.X + 67 * counter, startShowPosition.Y);
                    PicHand[counter].Size = new Size(60, 88);
                    PicHand[counter].BackColor = Color.Transparent;
                    PicHand[counter].Visible = false;
                    Controls.Add(PicHand[counter]);
                }
            }
            BtnCallCheat.Visible = false;
            BtnPlay.Size = new Size(220, 110);
            BtnPlay.Location = new Point(170, 760);
            BtnPlay.Font = new Font("Tahoma", 16);
            BtnPlay.Visible = false;
            BtnPlay.Text = "Play";
            BtnPlay.Click += new EventHandler(btnPlay_Click);
            Controls.Add(BtnPlay);
            BtnPlay2.Size = new Size(250, 130);
            BtnPlay2.Location = new Point(440, 740);
            BtnPlay2.Font = new Font("Tahoma", 16);
            BtnPlay2.Text = "Play Cards";
            BtnPlay2.Visible = false;
            BtnPlay2.Click += new EventHandler(btnPlay2_Click);
            Controls.Add(BtnPlay2);
            LblPlayed.Size = new Size(162, 50);
            LblPlayed.BackColor = Color.Transparent;
            LblPlayed.Font = new Font("Tahoma", 12);
            Controls.Add(LblPlayed);
            for (int i = 0; i < 2; i++)
            {
                LblAnnotations[i] = new Label();
                LblAnnotations[i].BackColor = Color.Transparent;
                lblAnnotations[i].ForeColor = gameEngine.Colours[1];
                LblAnnotations[i].Font = new Font("Tahoma", 12);
                LblAnnotations[i].Visible = false;
                Controls.Add(LblAnnotations[i]);
            }
            LblAnnotations[0].Text = "Card:";
            LblAnnotations[1].Text = "Quantity:";
            LblAnnotations[0].Size = new Size(50, 20);
            LblAnnotations[1].Size = new Size(80, 20);
            BtnHint.BackColor = gameEngine.Colours[0];
            BtnHint.ForeColor = gameEngine.Colours[1];
            BtnGuide.BackColor = gameEngine.Colours[0];
            BtnGuide.ForeColor = gameEngine.Colours[1];
            BtnRules.BackColor = gameEngine.Colours[0];
            BtnRules.ForeColor = gameEngine.Colours[1];
            lblUser.ForeColor = gameEngine.Colours[1];
            TxtUser.ForeColor = gameEngine.Colours[1];
            TxtUser.BackColor = gameEngine.Colours[0];
            lblScore.ForeColor = gameEngine.Colours[1];
            TxtScore.ForeColor = gameEngine.Colours[1];
            TxtScore.BackColor = gameEngine.Colours[0];
            LblStatus.ForeColor = gameEngine.Colours[1];
            btnPlay.BackColor = gameEngine.Colours[0];
            btnPlay.ForeColor = gameEngine.Colours[1];
            btnPlay2.BackColor = gameEngine.Colours[0];
            btnPlay2.ForeColor = gameEngine.Colours[1];
            LblLastPlayed.ForeColor = gameEngine.Colours[2];
            cbxPlay.BackColor = gameEngine.Colours[0];
            cbxPlay.ForeColor = gameEngine.Colours[1];
        }

        public void CheatSetUpElements(int speed) //Sets properties of the custom form objects specific to cheat.
        {
            //Destroys cheat-specific form objects.
            PicTrump.Dispose();
            BtnPickUp.Dispose();
            LblDeckNum.Dispose();
            PicDrawnCardDeck.Dispose();

            TimerReveal.Tick += new EventHandler(Reveal_Tick);
            TimerWait.Interval = speed * 35; //The intervals for the timers are calculated from the 'speed' chosen by the user before the game.
            TimerReveal.Interval = 250 + speed * 22;
            BtnCheat.Size = new Size(220, 110);
            BtnCheat.Location = new Point(470, 760);
            BtnCheat.Font = new Font("Tahoma", 16);
            BtnCheat.Text = "Cheat";
            BtnCheat.Click += new EventHandler(btnCheat_Click);
            BtnCheat.Visible = false;
            Controls.Add(BtnCheat);
            CbxPlay.Location = new Point(260, 750);
            CbxPlay.Font = new Font("Tahoma", 16);
            CbxPlay.Visible = false;
            CbxPlay.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(CbxPlay);
            Point point = new Point(230, 760);
            for (int i = 0; i < 2; i++)
            {
                CbxPlayFree[i] = new ComboBox();
                CbxPlayFree[i].Location = point;
                CbxPlayFree[i].Font = CbxPlay.Font = new Font("Tahoma", 15);
                CbxPlayFree[i].BackColor = gameEngine.Colours[0];
                CbxPlayFree[i].ForeColor = gameEngine.Colours[1];
                CbxPlayFree[i].Visible = false;
                CbxPlayFree[i].DropDownStyle = ComboBoxStyle.DropDownList;
                Controls.Add(CbxPlayFree[i]);
                point.Y += 45;
            }
            CbxPlayFree[0].SelectedIndexChanged += new EventHandler(CbxPlayFree_Update);
            point = new Point(160, 732);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    point.Y += 30;
                    CbxCheat[i, j] = new ComboBox();
                    CbxCheat[i, j].Location = point;
                    CbxCheat[i, j].Font = new Font("Tahoma", 11);
                    cbxCheat[i, j].BackColor = gameEngine.Colours[0];
                    cbxCheat[i, j].ForeColor = gameEngine.Colours[1];
                    CbxCheat[i, j].Visible = false;
                    CbxCheat[i, j].SelectedIndexChanged += new EventHandler(cbxCheat_Update);
                    CbxCheat[i, j].DropDownStyle = ComboBoxStyle.DropDownList;
                    Controls.Add(CbxCheat[i, j]);
                }
                point.Y = 732;
                point.X += 130;
            }
            point.X = 280;
            point.Y = 305;
            for (int i = 0; i < 2; i++)
            {
                LblRevealPlayed[i] = new Label();
                LblRevealPlayed[i].Location = new Point(point.X, point.Y);
                LblRevealPlayed[i].BackColor = Color.Transparent;
                lblRevealPlayed[i].ForeColor = gameEngine.Colours[1];
                LblRevealPlayed[i].Font = new Font("Tahoma", 14);
                LblRevealPlayed[i].Visible = false;
                if (i == 0)
                {
                    LblRevealPlayed[i].Size = new Size(250, 35);
                }
                else
                {
                    LblRevealPlayed[i].Text = "Played:";
                    LblRevealPlayed[i].Size = new Size(86, 35);
                }
                Controls.Add(LblRevealPlayed[i]);
                point.Y = 340;
            }
            point.X = 367;
            for (int i = 0; i < 4; i++)
            {
                PicReveal[i] = new PictureBox();
                PicReveal[i].Size = new Size(60, 88);
                PicReveal[i].Location = new Point(point.X, point.Y);
                PicReveal[i].SizeMode = PictureBoxSizeMode.Zoom;
                PicReveal[i].Image = Resources.BackOfCard;
                PicReveal[i].BackColor = Color.Transparent;
                PicReveal[i].BringToFront();
                PicReveal[i].Visible = false;
                Controls.Add(picReveal[i]);
                point.X += 65;
            }
            BtnCallCheat.ForeColor = gameEngine.Colours[0];
            btnCheat.BackColor = gameEngine.Colours[0];
            btnCheat.ForeColor = gameEngine.Colours[1];
        }

        public void FLSetUpElements(int speed) //Sets properties of the custom form objects specific to five leaves.
        {
            //Destroys cheat-specific form objects.
            TimerReveal.Dispose();
            BtnCheat.Dispose();
            BtnCallCheat.Dispose();            

            TimerWait.Interval = speed * 45; //The intervals for the timers are calculated from the 'speed' chosen by the user before the game.
            GameEngineFiveLeaves gameEngineFL = (GameEngineFiveLeaves)gameEngine;
            gameEngineFL.TrumpCard = gameEngine.deck.GetCardByDistanceFromTop(1); //Selects trump card.
            BtnPickUp.Size = new Size(220, 110);
            BtnPickUp.Location = new Point(470, 760);
            BtnPickUp.Font = new Font("Tahoma", 16);
            BtnPickUp.Text = "Pick Up";
            BtnPickUp.Click += new EventHandler(btnPickUp_Click);
            BtnPickUp.Visible = false;
            Controls.Add(BtnPickUp);
            CbxPlay.Size = new Size(185, 50);
            CbxPlay.Location = new Point(230, 750);
            CbxPlay.Font = new Font("Tahoma", 13);
            CbxPlay.Visible = false;
            CbxPlay.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(CbxPlay);
            PicTrump.Size = new Size(217, 93);
            PicTrump.Location = new Point(750, 755);
            PicTrump.BackColor = Color.Transparent;
            Controls.Add(PicTrump);
            PicDrawnCardDeck.SizeMode = PictureBoxSizeMode.Zoom;
            PicDrawnCardDeck.Image = Resources.BackOfCard;
            PicDrawnCardDeck.Size = new Size(60, 88);
            PicDrawnCardDeck.Location = PicDeck.Location;
            PicDrawnCardDeck.Visible = false;
            PicDrawnCardDeck.BackColor = Color.Transparent;
            Controls.Add(PicDrawnCardDeck);
            LblDeckNum.Location = new Point(338, 341);
            LblDeckNum.Size = new Size(63, 50);
            LblDeckNum.ForeColor = Color.RoyalBlue;
            LblDeckNum.Font = new Font("Tahoma", 19);
            Controls.Add(LblDeckNum);
            var pos = PointToScreen(LblDeckNum.Location);
            pos = PicDeck.PointToClient(pos);
            LblDeckNum.Parent = PicDeck;
            LblDeckNum.Location = pos;
            LblDeckNum.BackColor = Color.Transparent;
            gameEngine.PlayStatus = 2;
            btnPickUp.BackColor = gameEngine.Colours[0];
            btnPickUp.ForeColor = gameEngine.Colours[1];
        }

        private void timerMain_Tick(object sender, EventArgs e) //Event every 100ms. Calls method in GameEngine.
        {
            gameEngine.TimerMainInterval(this);
        }

        protected override void OnPaint(PaintEventArgs e) //Overrides the original OnPaint to draw a rectangle.
        {
            Graphics formGraphics = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush, 4);
            formGraphics.DrawRectangle(pen, 130, 730, 600, 160); //Draws rectangle in which buttons will appear.
        }

        private void CbxPlayFree_Update(object sender, EventArgs e) //Runs whenever item in a combobox is changed.
        {
            GameEngineCheat gameEngineCheat = (GameEngineCheat)gameEngine;
            gameEngineCheat.UpdatePlayComboBox(this, sender);
        }

        private void cbxCheat_Update(object sender, EventArgs e) //Runs whenever item in a combobox is changed.
        {
            GameEngineCheat gameEngineCheat = (GameEngineCheat)gameEngine;
            gameEngineCheat.UpdateCheatComboBox(this, sender);
        }

        private void btnLeft_Click(object sender, EventArgs e) //Calls method in GameEngine to move displayed hand left.
        {
            gameEngine.ButtonLeftClick(this);
        }

        private void btnRight_Click(object sender, EventArgs e) //Calls method in GameEngine to move displayed hand right.
        {
            gameEngine.ButtonRightClick(this);
        }

        private void btnPlay_Click(object sender, EventArgs e) //When player choses to play legally, calls methods in GameEngine.
        {
            btnPlay.Visible = false; //Makes main buttons invisible.
            btnPlay2.Visible = true; //Makes new objects visible.
            gameEngine.PlayButtonClick(this);
        }

        private void btnCheat_Click(object sender, EventArgs e) //When player choses to cheat, calls method in GameEngine.
        {
            GameEngineCheat gameEngineCheat = (GameEngineCheat)gameEngine;
            gameEngineCheat.CheatButtonClick(this);
        }

        private void btnPlay2_Click(object sender, EventArgs e) //Play button after choosing number of cards to play, calls method in GameEngine.
        {
            bool validSelection = false;
            validSelection = gameEngine.Play2ButtonClick(this); 
            if (validSelection == true)
            {
                CbxPlay.Visible = false;
                BtnPlay2.Visible = false;
                if (gameEngine.PlayStatus == 2)
                {
                    BtnHint.Visible = false;
                    BtnRules.Visible = false;
                    BtnGuide.Visible = false;
                }
            }
        }

        private void btnCallCheat_Click(object sender, EventArgs e) //Calls method in GameEngine when player calls out cheat.
        {
            GameEngineCheat gameEngineCheat = (GameEngineCheat)gameEngine;
            gameEngineCheat.Caller = gameEngine.playerQueue.GetPlayer(1);
            gameEngineCheat.RevealInitial(this);
        }

        private void btnPickUp_Click(object sender, EventArgs e) //Calls method in GameEngine when player choses to pick cards up during five leaves.
        {
            GameEngineFiveLeaves gameEngineFL = (GameEngineFiveLeaves)gameEngine;
            gameEngineFL.PickUpButtonClick(this);
        }

        private void btnGuide_Click(object sender, EventArgs e) //Goes to the instructions page to show the general game usage guide.
        {
            if (gameEngine.SoundBool)
            {
                SoundPlayer sndButton = new SoundPlayer(Resources.ButtonSelect);
                sndButton.Play();
            }

            Instructions instructions = new Instructions('G');
            instructions.ShowDialog();
        }

        private void btnRules_Click(object sender, EventArgs e) ////Goes to the instructions page to show the current game's rules.
        {
            if (gameEngine.SoundBool)
            {
                SoundPlayer sndButton = new SoundPlayer(Resources.ButtonSelect);
                sndButton.Play();
            }
            Instructions instructions = new Instructions(gameEngine.GameType);
            instructions.ShowDialog();
        }

        private void btnHint_Click(object sender, EventArgs e) //Brings up message box giving hints to the player, depending on situation.
        {
            MessageBox.Show("Hint:\n" + gameEngine.GetHint(this)); //Shows message box, calling method in GameEngine to get message.
        }

        private void Wait_Tick(object sender, EventArgs e) //Increments while in waiting phase after a play.
        {
            gameEngine.WaitInterval(this);
        }

        private void Reveal_Tick(object sender, EventArgs e) //Increments while in waiting phase after a play.
        {
            GameEngineCheat gameEngineCheat = (GameEngineCheat)gameEngine;
            gameEngineCheat.RevealInterval(this);
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e) //Closes form.
        {
            gameEngine.GameEnd = true;
            Dispose();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //Override method to prevent A/D from performing default functions.
        {
            switch (keyData)
            {
                case Keys.A: gameEngine.ButtonLeftClick(this); return true;
                case Keys.D: gameEngine.ButtonRightClick(this); return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}