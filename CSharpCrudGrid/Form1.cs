using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CSharpCrudGrid
{
    public partial class Form1 : Form
    {
        SQLiteDataAdapter _adapter;
        SQLiteConnection _connection;
        DataTable _fruitTable;

        public Form1()
        {
            _connection = new SQLiteConnection(GetConnectionString());
            _adapter = new SQLiteDataAdapter(
                "SELECT FruitID, FruitName, FruitIsYummy, FruitGrowsOnID FROM Fruit", _connection);
            _fruitTable = new DataTable();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureBindings();
        }

        private void ConfigureBindings()
        {
            //Columns were added from the Designer, do not allow grid
            //to automatically add columns for each column in the bound Table
            dataGridView1.AutoGenerateColumns = false;

            //Give the adapter its commands so it knows how to perform the inserts,
            //updates and deletes as the user makes data changes in the grid.
            _adapter.InsertCommand = GetInsertCommand();
            _adapter.UpdateCommand = GetUpdateCommand();
            _adapter.DeleteCommand = GetDeleteCommand();

            //Get all the fruit data from the database and bind it to the grid
            _adapter.Fill(_fruitTable);
            dataGridView1.DataSource = _fruitTable;

            //The combobox column needs to know what column from the FruitGrowsOn table
            //to show, which one to use as its value and where the records it is filled
            //with is coming from.
            DataGridViewComboBoxColumn growsOnColumn =
                dataGridView1.Columns["colFruitGrownsOnID"] as DataGridViewComboBoxColumn;
            growsOnColumn.DisplayMember = "GrowsOnName";  //The value to show to the user
            growsOnColumn.ValueMember = "FruitGrowsOnID"; //The underlying value in the cell
            growsOnColumn.DataSource = GetGrowsOnTable(); //The records to fill the combo

        }

        private SQLiteCommand GetInsertCommand()
        {
            string qry = @"INSERT INTO Fruit
                (FruitName, FruitIsYummy, FruitGrowsOnID)
                VALUES(@FruitName, @FruitIsYummy, @FruitGrowsOnID)";

            SQLiteCommand insertCmd = new SQLiteCommand(qry, _connection);

            var parFruitName = new SQLiteParameter("@FruitName", DbType.String, "FruitName");
            var parFruitIsYummy = new SQLiteParameter("@FruitIsYummy", DbType.Boolean, "FruitIsYummy");
            var parFruitGrowsOnID = new SQLiteParameter("@FruitGrowsOnID", DbType.Int32, "FruitGrowsOnID");

            insertCmd.Parameters.AddRange(new SQLiteParameter[]
            {
                parFruitName, parFruitIsYummy, parFruitGrowsOnID
            });

            return insertCmd;
        }

        private SQLiteCommand GetUpdateCommand()
        {
            string qry = @"UPDATE Fruit
                SET FruitName = @FruitName,
                    FruitIsYummy = @FruitIsYummy,
                    FruitGrowsOnID = @FruitGrowsOnID
                WHERE FruitID = @FruitID";

            SQLiteCommand updateCmd = new SQLiteCommand(qry, _connection);

            var parFruitID = new SQLiteParameter("@FruitID", DbType.Int32, "FruitID");
            var parFruitName = new SQLiteParameter("@FruitName", DbType.String, "FruitName");
            var parFruitIsYummy = new SQLiteParameter("@FruitIsYummy", DbType.Boolean, "FruitIsYummy");
            var parFruitGrowsOnID = new SQLiteParameter("@FruitGrowsOnID", DbType.Int32, "FruitGrowsOnID");

            updateCmd.Parameters.AddRange(new SQLiteParameter[]
            {
                parFruitID, parFruitName, parFruitIsYummy, parFruitGrowsOnID
            });

            return updateCmd;
        }

        private SQLiteCommand GetDeleteCommand()
        {
            string qry = @"DELETE FROM Fruit WHERE FruitID = @FruitID";

            SQLiteCommand deleteCmd = new SQLiteCommand(qry, _connection);

            var parFruitID = new SQLiteParameter("@FruitID", DbType.Int32, "FruitID");

            deleteCmd.Parameters.Add(parFruitID);

            return deleteCmd;
        }

        /// <summary>
        /// Returns a DataTable of FruitGrowsOn records.
        /// We could put this in our data adapter but since
        /// we are not editing FruitGrowsOn data we just keep
        /// it separate and bind the grid column to it.
        /// </summary>
        /// <returns></returns>
        private DataTable GetGrowsOnTable()
        {
            DataTable growsOnTable = new DataTable();

            string connectionStr = GetConnectionString();

            using (SQLiteConnection con = new SQLiteConnection(connectionStr))
            using (SQLiteCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT FruitGrowsOnID, GrowsOnName FROM FruitGrowsOn";
                con.Open();
                SQLiteDataReader rdr = cmd.ExecuteReader();
                growsOnTable.Load(rdr);
                return growsOnTable;
            }
        }

        /// <summary>
        /// Builds a connection string to the project's database. 
        /// </summary>
        /// <returns></returns>
        private string GetConnectionString()
        {
            SQLiteConnectionStringBuilder bldr = new SQLiteConnectionStringBuilder();
            bldr.DataSource = Path.Combine(Environment.CurrentDirectory, "Data", "FruitDB.sqlite3");
            bldr.Version = 3;

            return bldr.ConnectionString;
        }

        /// <summary>
        /// Simply calls Update on the data adapter. The data adapter
        /// will call the appropriate commands (insert, update, delete)
        /// based on the row state of the rows in the FruitTable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            _adapter.Update(_fruitTable);
        }

        /// <summary>
        /// Not much point in doing this if your entire application is a single
        /// form, but you should always dispose resources.
        /// Typically all this data access code would not be in the Form
        /// code-behind, but in some kind of repository class. The repository
        /// should then implement IDisposable itself and these things would be 
        /// disposed of in it's Dispose method.
        /// see: https://msdn.microsoft.com/en-us/library/ms244737.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.Dispose();
            _adapter.Dispose();
            _fruitTable.Dispose();
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                sb.Append($"Column Name: {col.Name}, DataPropertyName: {col.DataPropertyName}");
                sb.AppendLine();
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
