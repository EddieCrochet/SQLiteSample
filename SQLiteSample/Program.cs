using System;
using System.Data.SQLite;

namespace SQLiteSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            //create a new database connection
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

            //Now, open the connection
            try
            {
                sqlite_conn.Open();
            }
            catch(Exception ex)
            {

            }
            return sqlite_conn;
        }
    }
}
