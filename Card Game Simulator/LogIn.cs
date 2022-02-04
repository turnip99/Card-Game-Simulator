using System;
using System.Windows.Forms;
using System.Media;
using Card_Game_Simulator.Properties;
using System.Data;

namespace Card_Game_Simulator
{
    public partial class LogIn : Form
    {
        DatabaseConnection objConnect;
        string conString;

        DataSet dataSet;
        DataRow dataRow;

        int maxRows;
        bool valid = false; //Saves if uses details are valid.
        DataRow result;

        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            ActiveControl = txtUsername;
            try
            {
                objConnect = new DatabaseConnection(); //Instantiates database connector class.
                conString = Settings.Default.CardGameDatabaseConnectionString;

                objConnect.connectionString = conString;
                objConnect.SQL = Settings.Default.SqlSelectFromtblUser; //Uses the sql that links to tblUser.

                dataSet = objConnect.GetConnection; //Fills local dataset with data from database.
                maxRows = dataSet.Tables[0].Rows.Count; //Defined by number of rows in table.
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnLogOn_Click(object sender, EventArgs e)
        {
            SoundPlayer sndButtonClick = new SoundPlayer(Resources.ButtonSelect);
            sndButtonClick.Play();
            for (int i = 0; i < maxRows; i++) //Goes through each row of tblUser.
            {
                dataRow = dataSet.Tables[0].Rows[i];
                if (txtUsername.Text == dataRow.ItemArray.GetValue(1).ToString() &&
                    txtPassword.Text == dataRow.ItemArray.GetValue(2).ToString()) //Checks if username and password both match the record.
                {
                    result = dataRow;
                    valid = true;
                    break;
                }
            }
            switch (valid)
            {
                case true: Close(); break; //If valid user, close form.
                case false: MessageBox.Show("Your username or password are incorrect."); txtPassword.Clear(); break; //If invalid user, show error.
                default: break;
            }
        }

        public DataRow GetUser() //Method called by the menu form to get the result of the log-in process.
        {
            if (valid == true)
            {
                return (result);
            }
            else
            {
                return null;
            }
        }
    }
}