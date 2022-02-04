using Card_Game_Simulator.Properties;
using System;
using System.Data;
using System.Media;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    public partial class AddUsers : Form
    {
        DatabaseConnection objConnect;
        string conString;

        DataSet dataSet;
        int maxRows;

        public AddUsers()
        {
            InitializeComponent();
        }

        private void AddUsers_Load(object sender, EventArgs e)
        {
            ActiveControl = txtUsername;
            try
            {
                objConnect = new DatabaseConnection(); //Instantiates connector to database.
                conString = Settings.Default.CardGameDatabaseConnectionString;

                objConnect.connectionString = conString;
                objConnect.SQL = Settings.Default.SqlSelectFromtblUser;

                dataSet = objConnect.GetConnection;
                maxRows = dataSet.Tables[0].Rows.Count; //Defined by number of rows in table.
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SoundPlayer sndButtonClick = new SoundPlayer(Resources.ButtonSelect);
            sndButtonClick.Play();
            DataRow row = dataSet.Tables[0].NewRow(); //Creates a new row of data.
            if (txtUsername.Text.Length > 15 || txtUsername.Text == "" || txtPassword.Text == "") //Checks that both boxes are filled and username is not too long.
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }
            for (int i = 0; i < maxRows; i++) //Checks username is not already taken.
            {
                if (txtUsername.Text == dataSet.Tables[0].Rows[i].ItemArray.GetValue(1).ToString())
                {
                    MessageBox.Show("This username is not available.");
                    return;
                }
            }
            row[1] = txtUsername.Text; //First row = username.
            row[2] = txtPassword.Text; //Second row = password.
            row[3] = chkAdmin.Checked; //Third row = admin status.
            row[4] = CreateSettings(); //Fourth row = setting ID.
            dataSet.Tables[0].Rows.Add(row); //Adds data to local dataset.
            try
            {
                objConnect.UpdateDatabase(dataSet); //Uses connector to update database using local dataset.
                MessageBox.Show("New user successfully added!");
                Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private int CreateSettings() //Creates new settings row and returns the ID.
        {
            DatabaseConnection objConnect = new DatabaseConnection(); //Instantiates the database connection.
            objConnect.connectionString = Settings.Default.CardGameDatabaseConnectionString;
            objConnect.SQL = Settings.Default.SqlSelectFromtblSettings; //Uses sql string that links to tblSettings.
            DataSet dataSetSettings = objConnect.GetConnection; //Gets dataset from the string/sql sent to the connection class.
            DataRow row = dataSetSettings.Tables[0].NewRow(); //Creates new row before assigning default values.
            row[1] = true;
            row[2] = "Orange";
            row[3] = "Random";
            row[4] = "Random";
            row[5] = "Random";
            row[6] = true;
            row[7] = true;
            row[8] = true;
            dataSetSettings.Tables[0].Rows.Add(row); //Adds new default row.
            try
            {
                objConnect.UpdateDatabase(dataSetSettings); //Uses connector to update database using local dataset.
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            dataSetSettings = objConnect.GetConnection; //Gets new data.
            maxRows = dataSetSettings.Tables[0].Rows.Count; //Defined by number of rows in table.
            int highestRow = (int)dataSetSettings.Tables[0].Rows[0][0];
            for (int i = 1; i < maxRows; i++) //Loop to find newest row on table.
            {
                if ((int)dataSetSettings.Tables[0].Rows[i][0] > highestRow)
                {
                    highestRow = (int)dataSetSettings.Tables[0].Rows[i][0];
                }
            }
            return highestRow;
        }
    }
}