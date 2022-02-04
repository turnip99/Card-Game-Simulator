using System;
using System.Windows.Forms;
using Card_Game_Simulator.Properties;
using System.Media;
using System.Data;

namespace Card_Game_Simulator
{
    public partial class Menu : Form
    {
        DataRow currentUser;

        DataRow settingsData;

        SoundPlayer sndButtonClick = new SoundPlayer(Resources.ButtonSelect);

        public Menu()
        {
            InitializeComponent();
            LogIn();             //Goes to 'LogIn' form.
        }

        private void LogIn() //Calls the log-in form and gets the result.
        {
            using (LogIn logIn = new LogIn())
            {
                logIn.ShowDialog();
                DataRow userTemp = logIn.GetUser(); //Gets result of log-in process from the LogIn form.
                if (userTemp != null) //Checks result is not null (if log in was sucessful).
                {
                    currentUser = userTemp;
                }
                if (currentUser != null) //If current user is not null (so if first log on AND log-on process failed),
                {
                    btnGameSettings.Visible = true;
                    GetSettings();
                    txtCurrentUser.Text = currentUser.ItemArray.GetValue(1).ToString(); //Set contents of user textbox.
                }
                else
                {
                    btnGameSettings.Visible = false;
                    settingsData = null;
                    txtCurrentUser.Text = "Guest"; //Set user as 'guest'.
                }
            }
            checkIfAdmin(); //Check if user has admin rights.
        }

        private void GetSettings() //Gets the current settings of the current user.
        {
            int settingsID = (int)currentUser.ItemArray.GetValue(4);
            //Retrieves the settings data for the current user.
            DataSet settingsDataSet = new DataSet();
            try
            {
                DatabaseConnection objConnect;
                string conString;
                objConnect = new DatabaseConnection(); //Instantiates connector to database.
                conString = Settings.Default.CardGameDatabaseConnectionString;

                objConnect.connectionString = conString;

                objConnect.SQL = Settings.Default.SqlSelectFromtblSettings;
                settingsDataSet = objConnect.GetConnection;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            int maxRows = settingsDataSet.Tables[0].Rows.Count; //Defined by number of rows in table.

            for (int i = 0; i < maxRows; i++)
            {
                if ((int)settingsDataSet.Tables[0].Rows[i].ItemArray.GetValue(0) == settingsID)
                {
                    settingsData = settingsDataSet.Tables[0].Rows[i];
                    break;
                }
            }
        }

        private DataRow GetGame(string game) //Gets the game from the database when one is selected by the user.
        {
            DatabaseConnection objConnect = new DatabaseConnection(); //Instantiates database connector class.
            string conString = Settings.Default.CardGameDatabaseConnectionString;

            objConnect.connectionString = conString;
            objConnect.SQL = Settings.Default.SqlSelectFromtblGame; //SQL to get data from tblGame.

            DataSet dataSet = objConnect.GetConnection; //Gets dataset from connector.
            DataRow dataRow;
            int maxRows = dataSet.Tables[0].Rows.Count; //Defined by number of rows in table.

            for (int i = 0; i < maxRows; i++) //Goes through all rows in table until it identifies game with name equal to user selection.
            {
                dataRow = dataSet.Tables[0].Rows[i];
                if (game == dataRow.ItemArray.GetValue(1).ToString()) //If game matches user selection.
                {
                    return dataRow; //Return game.
                }
            }
            return null;
        }

        private void checkIfAdmin() //Checks if the user is an admin.
        {
            if (currentUser != null && currentUser.ItemArray.GetValue(3).ToString() == "True")
            {
                btnDisplayUsers.Visible = true;
                btnAddUsers.Visible = true;
                lblAdmin.Visible = true;
            }
            else
            {
                btnDisplayUsers.Visible = false;
                btnAddUsers.Visible = false;
                lblAdmin.Visible = false;
            }
        }

        private void btnCheat3P_Click(object sender, EventArgs e)
        {
            //Goes to 'Game' form, sending the number of players/username/gametype/speed while playing the buttonClick sound.
            sndButtonClick.Play();
            GetSpeed getSpeed = new GetSpeed();
            getSpeed.ShowDialog();
            int speed = getSpeed.speed; //Gets a game-speed from the getSpeed form.
            sndButtonClick.Play();
            Game game = new Game(3, currentUser, GetGame("Cheat"), settingsData, speed);
            game.ShowDialog();
            Refresh();
        }

        private void btnCheat4P_Click(object sender, EventArgs e)
        {
            sndButtonClick.Play();
            GetSpeed getSpeed = new GetSpeed();
            getSpeed.ShowDialog();
            int speed = getSpeed.speed;
            sndButtonClick.Play();
            Game game = new Game(4, currentUser, GetGame("Cheat"), settingsData, speed);
            game.ShowDialog();
            Refresh();
        }

        private void btnFL3P_Click(object sender, EventArgs e)
        {
            sndButtonClick.Play();
            GetSpeed getSpeed = new GetSpeed();
            getSpeed.ShowDialog();
            int speed = getSpeed.speed;
            sndButtonClick.Play();
            Game game = new Game(3, currentUser, GetGame("Five Leaves"), settingsData, speed);
            game.ShowDialog();
            Refresh();
        }

        private void btnFL4P_Click(object sender, EventArgs e)
        {
            sndButtonClick.Play();
            GetSpeed getSpeed = new GetSpeed();
            getSpeed.ShowDialog();
            int speed = getSpeed.speed;
            sndButtonClick.Play();
            Game game = new Game(4, currentUser, GetGame("Five Leaves"), settingsData, speed);
            game.ShowDialog();
            Refresh();
        }

        private void btnLogIn_Click(object sender, EventArgs e) //Goes to 'LogIn' form.
        {
            sndButtonClick.Play();
            LogIn();
        }

        private void btnDisplayUsers_Click(object sender, EventArgs e) //Goes to 'DisplayUsers' form.
        {
            sndButtonClick.Play();
            DisplayUsers displayUsers = new DisplayUsers();
            displayUsers.ShowDialog();
        }

        private void btnHighScores_Click(object sender, EventArgs e) //Goes to 'Highscores' form.
        {
            sndButtonClick.Play();
            Highscores highscores = new Highscores();
            highscores.ShowDialog();
        }

        private void btnAddUsers_Click(object sender, EventArgs e) //Goes to 'AddUsers' form.
        {
            sndButtonClick.Play();
            AddUsers addUsers = new AddUsers();
            addUsers.ShowDialog();
        }

        private void btnGuide_Click(object sender, EventArgs e) //Goes to 'Instructions' form for general game help.
        {
            sndButtonClick.Play();
            Instructions instructions = new Instructions('G');
            instructions.ShowDialog();
        }

        private void btnCheatRules_Click(object sender, EventArgs e) //Goes to 'Instructions' form for Cheat rules.
        {
            sndButtonClick.Play();
            Instructions instructions = new Instructions('C');
            instructions.ShowDialog();
        }

        private void btnFLRules_Click(object sender, EventArgs e) //Goes to 'Instructions' form for Five Leaves rules.
        {
            sndButtonClick.Play();
            Instructions instructions = new Instructions('F');
            instructions.ShowDialog();
        }

        private void btnGameSettings_Click(object sender, EventArgs e)
        {
            sndButtonClick.Play();
            GameSettings settings = new GameSettings(settingsData);
            settings.ShowDialog();
            GetSettings();
        }
    }
}