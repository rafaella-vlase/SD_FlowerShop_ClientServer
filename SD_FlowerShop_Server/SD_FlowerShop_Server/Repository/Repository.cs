using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Server.Repository
{
    public class Repository
    {
        protected SqlConnection connection;
        private static Repository instance = null;

        private Repository()
        {
            string s = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=FlowerShopProiect";
            s += ";Integrated Security=True;";
            this.connection = new SqlConnection(s);
        }

        public static Repository GetInstance()
        {
            if (instance == null)
                instance = new Repository();
            return instance;
        }

        public SqlConnection Connection
        {
            get { return this.connection; }
            set { this.connection = value; }
        }

        public void OpeningConnection()
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
        }

        public void ClosingConnection()
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }

        public bool CommandSQL(string commandSQL)
        {
            bool result = true;
            try
            {
                this.OpeningConnection();
                SqlCommand command = new SqlCommand(commandSQL, this.connection);
                if (command.ExecuteNonQuery() == 0)
                    result = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                this.ClosingConnection();
            }
            return result;
        }

        public DataTable GetTable(string commandSQL)
        {
            DataTable result = null;
            try
            {
                this.OpeningConnection();
                SqlCommand command = new SqlCommand(commandSQL, this.connection);
                SqlDataAdapter readData = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                readData.Fill(table);
                result = table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.ClosingConnection();
            }
            return result;
        }
    }
}
