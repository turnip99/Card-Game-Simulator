using System.Data;
using System.Data.OleDb;

namespace Card_Game_Simulator
{
    class DatabaseConnection //Connects to the database.
    {
        private string sql_string; //Holds the sql query.
        public string SQL
        {
            set { sql_string = value; }
        }

        private string strCon; //Holds the connection string.
        public string connectionString
        {
            set { strCon = value; }
        }

        OleDbDataAdapter adapter; //Table adapter to fill dataset.

        public DataSet GetConnection //Public method the other classes can use to get the private dataset when requestwed.
        {
            get { return MyDataSet(); }
        }

        private DataSet MyDataSet() //Creates the dataset retrieved from the database.
        {
            OleDbConnection con = new OleDbConnection(strCon); //Creates connection using the connection string.
            con.Open(); //Opens connection.
            adapter = new OleDbDataAdapter(sql_string, con); //Adapter accesses database.
            DataSet dataSet = new DataSet(); //Makes dataset.
            adapter.Fill(dataSet); //Adpter fills the dataset with data from database.
            con.Close(); //Closes connection.
            return dataSet;
        }

        public void UpdateDatabase(DataSet dataSet) //Updates the database using the new data sent from another class.
        {
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            builder.QuotePrefix = "["; //Fixes the inbuilt query using []s.
            builder.QuoteSuffix = "]";
            builder.DataAdapter.Update(dataSet.Tables[0]); //Uses pre-defined query to update table with the new dataset.
        }
    }
}