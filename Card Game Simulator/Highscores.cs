using System;
using System.Windows.Forms;
using System.Data;
using Card_Game_Simulator.Properties;

namespace Card_Game_Simulator
{
    public partial class Highscores : Form
    {
        DatabaseConnection objConnect;
        string conString;

        DataSet dataSetGame;
        DataSet dataSetUser;
        DataSet dataSetScore;
        int maxRows;

        public Highscores()
        {
            InitializeComponent();
        }

        private void Highscores_Load(object sender, EventArgs e) //Establishes connection with database and fills comboboxes with data upon loading form.
        {
            try
            {
                objConnect = new DatabaseConnection(); //Instantiates connector to database.
                conString = Settings.Default.CardGameDatabaseConnectionString;

                objConnect.connectionString = conString;

                objConnect.SQL = Settings.Default.SqlSelectFromtblScore;
                dataSetScore = objConnect.GetConnection;

                objConnect.SQL = Settings.Default.SqlSelectFromtblGame;
                dataSetGame = objConnect.GetConnection;

                objConnect.SQL = Settings.Default.SqlSelectFromtblUser;
                dataSetUser = objConnect.GetConnection;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            cbxGame.Items.Add("All");
            cbxUser.Items.Add("All");

            DataRow dataRow;
            maxRows = dataSetGame.Tables[0].Rows.Count; //Defined by number of rows in table.
            for (int i = 0; i < maxRows; i++)
            {
                dataRow = dataSetGame.Tables[0].Rows[i];
                cbxGame.Items.Add(dataRow.ItemArray.GetValue(1).ToString());
            }

            maxRows = dataSetUser.Tables[0].Rows.Count; //Defined by number of rows in table.
            for (int i = 0; i < maxRows; i++)
            {
                dataRow = dataSetUser.Tables[0].Rows[i];
                cbxUser.Items.Add(dataRow.ItemArray.GetValue(1).ToString());
            }
            ResetComboBox();
            UpdateDataGrid();
        }

        private void Filter(object sender, EventArgs e) //Filters datagrid based on contents of comboboxes.
        {
            ResetDataSet();
            UpdateDataGrid();
            maxRows = dataSetScore.Tables[0].Rows.Count; //Defined by number of rows in table.
            for (int i = 0; i < maxRows; i++)
            {
                if (dataSetScore.Tables[0].Rows.Count <= i)
                {
                    break;
                }
                if ((dataSetScore.Tables[0].Rows[i].ItemArray.GetValue(1).ToString() != cbxUser.SelectedItem.ToString() && cbxUser.SelectedIndex != 0) ||
                    (dataSetScore.Tables[0].Rows[i].ItemArray.GetValue(2).ToString() != cbxGame.SelectedItem.ToString() && cbxGame.SelectedIndex != 0))
                {
                    dataSetScore.Tables[0].Rows.RemoveAt(i);
                    i--;
                }
            }            
            UpdateDataGrid();
        }

        private void btnReset_Click(object sender, EventArgs e) //Resets combobox/datagrid values to default.
        {
            ResetComboBox();
            ResetDataSet();
            UpdateDataGrid();
        }

        private void ResetComboBox() //Resets combobox values.
        {
            cbxGame.SelectedIndex = 0;
            cbxUser.SelectedIndex = 0;
        }

        private void ResetDataSet() //Resets datagrid.
        {
            objConnect.SQL = Settings.Default.SqlSelectFromtblScore;
            dataSetScore = objConnect.GetConnection;
        }

        private void UpdateDataGrid() //Updates data grid with the (potentially filtered) dataset.
        {
            dgdHighScores.DataSource = dataSetScore.Tables[0];
            dgdHighScores.Sort(scoreDataGridViewTextBoxColumn, System.ComponentModel.ListSortDirection.Descending); //Sorts data by score.
        }
    }
}