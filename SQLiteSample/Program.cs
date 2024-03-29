﻿using System;
using System.Data.SQLite;

namespace SQLiteSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();

            //CreateTable(sqlite_conn);
            //InsertData(sqlite_conn);
            //only need to call the above two methods the first time we run them through

            ReadData(sqlite_conn);
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
                Console.WriteLine("There is no database connection happening: {0}: ", ex);
            }
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE SampleTable (Col1 VARCHAR(20), Col2 INT)";
            string Createsql1 = "CREATE TABLE SampleTable1 (Col1 VARCHAR(20), Col2 INT)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql1;
            sqlite_cmd.ExecuteNonQuery();
        }

        static void CreateDestinyTable(SQLiteConnection conn)
        {
            SQLiteCommand cmd;
            string makeTable = "CREATE TABLE myTable (Col1 VARCHAR(20), Col2 VARCHAR(20), Col3 INT)";
            cmd = conn.CreateCommand();
            cmd.CommandText = makeTable;
            cmd.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection conn)
        {
            //already called this method - 
            //either delete all anreplace or write and call new method for different datum
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES ('Test Text', 1);";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES ('Test1 Text1', 2);";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES ('Test2 Text2 ', 3);";
            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.CommandText = "INSERT INTO SampleTable1 (Col1, col2) VALUES ('Test3 Text3', 3);";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable1 (Col1, Col2) VALUES ('This is my text 4 text', 4)";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable1 (Col1, Col2) VALUES ('Howdy Text 5', 5)";
            sqlite_cmd.ExecuteNonQuery();
        }

        static void DeleteDuplicates(SQLiteConnection conn)
        {
            SQLiteCommand cmd = conn.CreateCommand();
            //need to write code to delete duplicates
        }

        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT DISTINCT * FROM SampleTable";

            Console.WriteLine("SampleTable holds: ");
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while(sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine("\t{0}", myreader);
            }

            SQLiteCommand cmd;
            cmd = conn.CreateCommand();
            //need a new sqlitecommand for every entry!!

            cmd.CommandText = "SELECT Col1 FROM SampleTable1 ORDER BY Col2 DESC";
            Console.WriteLine("SampleTable1 holds :");
            sqlite_datareader = cmd.ExecuteReader();
            while(sqlite_datareader.Read())
            {
                string myNewReader = sqlite_datareader.GetString(0);
                Console.WriteLine("\t{0}", myNewReader);
            }

            conn.Close();
        }
    }
}
