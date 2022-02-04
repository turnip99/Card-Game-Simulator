using System;
using System.Windows.Forms;
using System.Data;
using Card_Game_Simulator.Properties;

namespace Card_Game_Simulator
{
    public partial class DisplayUsers : Form
    {
        DatabaseConnection objConnect;
        string conString;

        DataSet dataSet;
        int maxRows;

        public DisplayUsers()
        {
            InitializeComponent();
        }

        private void DisplayUsers_Load(object sender, EventArgs e)
        {
            try
            {
                objConnect = new DatabaseConnection(); //Instantiates connector to database.
                conString = Settings.Default.CardGameDatabaseConnectionString;

                objConnect.connectionString = conString;

                objConnect.SQL = Settings.Default.SqlSelectFromtblUser;
                dataSet = objConnect.GetConnection;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            cbxAdmin.Items.Add("Any");
            cbxAdmin.Items.Add("Admin Only");
            cbxAdmin.Items.Add("Non-admin Only");
            ResetComboBox();
            UpdateDataGrid();
        }

        private void Filter(object sender, EventArgs e) //Filters datagrid based on contents of comboboxes.
        {
            ResetDataSet();
            UpdateDataGrid();
            maxRows = dataSet.Tables[0].Rows.Count; //Defined by number of rows in table.
            for (int i = 0; i < maxRows; i++)
            {
                if (dataSet.Tables[0].Rows.Count <= i)
                {
                    break;
                }
                if (((bool)dataSet.Tables[0].Rows[i].ItemArray.GetValue(3) != true && cbxAdmin.SelectedIndex == 1) ||
                    ((bool)dataSet.Tables[0].Rows[i].ItemArray.GetValue(3) != false && cbxAdmin.SelectedIndex == 2))
                {
                    dataSet.Tables[0].Rows.RemoveAt(i);
                    i--;
                }
            }
            UpdateDataGrid();
        }

        private void ResetComboBox() //Resets combobox values.
        {
            cbxAdmin.SelectedIndex = 0;
        }

        private void ResetDataSet() //Resets datagrid.
        {
            objConnect.SQL = Settings.Default.SqlSelectFromtblUser;
            dataSet = objConnect.GetConnection;
        }

        private void UpdateDataGrid() //Updates data grid with the (potentially filtered) dataset.
        {
            dgdUsers.DataSource = dataSet.Tables[0];
        }
    }
}