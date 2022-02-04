using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Card_Game_Simulator.Properties;

namespace Card_Game_Simulator
{
    public partial class GameSettings : Form
    {
        DataRow settingsData;
        public GameSettings(DataRow data)
        {
            InitializeComponent();
            settingsData = data;
            AddValues();
            RetrieveDataSettings();
            UpdateNameValues();
        }

        private void NameValueChanged(object sender, EventArgs e) //When name textboxes/comboboxes are updated.
        {
            UpdateNameValues();
        }

        private void AddValues() //Adds values to comboboxes.
        {
            Dictionary<string, string> dicColours = new Dictionary<string, string>(); //Makes a dictionary to link the text in the combobox with the colour schemes.
            dicColours.Add("Orange", "Orange and Blue");
            dicColours.Add("Yellow", "Yellow and Purple");
            dicColours.Add("Green", "Green and Red");
            cbxColour.DataSource = new BindingSource(dicColours, null); //Binds combobox to the dictionary.
            cbxColour.DisplayMember = "Value";
            cbxColour.ValueMember = "Key";

            cbxP2Gender.Items.Add("Default");
            cbxP2Gender.Items.Add("Male");
            cbxP2Gender.Items.Add("Female");

            cbxP3Gender.Items.Add("Default");
            cbxP3Gender.Items.Add("Male");
            cbxP3Gender.Items.Add("Female");

            cbxP4Gender.Items.Add("Default");
            cbxP4Gender.Items.Add("Male");
            cbxP4Gender.Items.Add("Female");
        }

        private void RetrieveDataSettings() //Applies previously saved settings to the form objects.
        {
            if ((bool)settingsData.ItemArray.GetValue(1) == true)
            {
                radTrue.Checked = true;
            }
            else
            {
                radFalse.Checked = true;
            }
            switch (settingsData.ItemArray.GetValue(2).ToString())
            {
                case "Orange": cbxColour.SelectedIndex = 0; break;
                case "Yellow": cbxColour.SelectedIndex = 1; break;
                case "Green": cbxColour.SelectedIndex = 2; break;
                default: break;
            }

            txtP2Name.Text = settingsData.ItemArray.GetValue(3).ToString();
            txtP3Name.Text = settingsData.ItemArray.GetValue(4).ToString();
            txtP4Name.Text = settingsData.ItemArray.GetValue(5).ToString();
            switch ((bool)settingsData.ItemArray.GetValue(6))
            {
                case true: cbxP2Gender.SelectedIndex = 1; break;
                case false: cbxP2Gender.SelectedIndex = 2; break;
                default: break;
            }
            switch ((bool)settingsData.ItemArray.GetValue(7))
            {
                case true: cbxP3Gender.SelectedIndex = 1; break;
                case false: cbxP3Gender.SelectedIndex = 2; break;
                default: break;
            }
            switch ((bool)settingsData.ItemArray.GetValue(8))
            {
                case true: cbxP4Gender.SelectedIndex = 1; break;
                case false: cbxP4Gender.SelectedIndex = 2; break;
                default: break;
            }
        }

        private void UpdateNameValues() //Updates values of textboxes/comboboxes associated with name settings when they are editted.
        {
            if (txtP2Name.Text == "")
            {
                txtP2Name.Text = "Random";
            }

            if (txtP3Name.Text == "")
            {
                txtP3Name.Text = "Random";
            }

            if (txtP4Name.Text == "")
            {
                txtP4Name.Text = "Random";
            }

            if (txtP2Name.Text == "Random")
            {
                cbxP2Gender.SelectedIndex = 0;
            }
            else if (cbxP2Gender.Text == "Default")
            {
                cbxP2Gender.SelectedIndex = 1;
            }

            if (txtP3Name.Text == "Random")
            {
                cbxP3Gender.SelectedIndex = 0;
            }
            else if (cbxP3Gender.Text == "Default")
            {
                cbxP3Gender.SelectedIndex = 1;
            }

            if (txtP4Name.Text == "Random")
            {
                cbxP4Gender.SelectedIndex = 0;
            }
            else if (cbxP4Gender.Text == "Default")
            {
                cbxP4Gender.SelectedIndex = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) //Saves updated settings.
        {
            DatabaseConnection objConnect = new DatabaseConnection(); //Instantiates the database connection.
            objConnect.connectionString = Settings.Default.CardGameDatabaseConnectionString;
            objConnect.SQL = Settings.Default.SqlSelectFromtblSettings; //Uses sql string that links to tblScore.
            DataSet dataSet = objConnect.GetConnection; //Gets datset from the string/sql sent to the connection class.
            int maxRows = dataSet.Tables[0].Rows.Count; //Defined by number of rows in table.

            int row = 0;
            for (int i = 0; i < maxRows; i++) //Finds row to replace.
            {
                if ((int)dataSet.Tables[0].Rows[i].ItemArray.GetValue(0) == (int)settingsData.ItemArray.GetValue(0))
                {
                    row = i;
                    break;
                }
            }

            switch (radTrue.Checked) //First row = sound effects bool.
            {
                case true: dataSet.Tables[0].Rows[row][1] = true; break;
                case false: dataSet.Tables[0].Rows[row][1] = false; break;
                default: break;
            }
            switch (cbxColour.SelectedIndex) //Second row = colour scheme.
            {
                case 0: dataSet.Tables[0].Rows[row][2] = "Orange"; break;
                case 1: dataSet.Tables[0].Rows[row][2] = "Yellow"; break;
                case 2: dataSet.Tables[0].Rows[row][2] = "Green"; break;
                default: break;
            }
            dataSet.Tables[0].Rows[row][3] = txtP2Name.Text; //Third row = player 2 name.
            dataSet.Tables[0].Rows[row][4] = txtP3Name.Text; //Fourth row = player 3 name.
            dataSet.Tables[0].Rows[row][5] = txtP4Name.Text; //Fifth row = player 4 name.
            switch (cbxP2Gender.Text) //Sixth row = player 2 gender.
            {
                case "Female": dataSet.Tables[0].Rows[row][6] = false; break;
                default: dataSet.Tables[0].Rows[row][6] = true; break;
            }
            switch (cbxP3Gender.Text) //Seventh row = player 3 gender.
            {
                case "Female": dataSet.Tables[0].Rows[row][7] = false; break;
                default: dataSet.Tables[0].Rows[row][7] = true; break;
            }
            switch (cbxP4Gender.Text) //Eighth row = player 4 gender.
            {
                case "Female": dataSet.Tables[0].Rows[row][8] = false; break;
                default: dataSet.Tables[0].Rows[row][8] = true; break;
            }

            try
            {
                objConnect.UpdateDatabase(dataSet); //Uses connector to update database using local dataset.
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            Close(); //Closes form once data is saved.
        }
    }
}