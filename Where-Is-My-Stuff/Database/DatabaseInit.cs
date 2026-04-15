using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Where_Is_My_Stuff.Database
{
    internal class DatabaseInit
    {
        private static readonly string _databaseName = "wismDb.mdf";
        private static readonly string _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _databaseName);

        private static readonly string _sqlSchemaName = "schema.sql";
        private static readonly string _sqlSchemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", _sqlSchemaName);

        private static readonly string _sqlSeedName = "seed.sql";
        private static readonly string _sqlSeedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", _sqlSeedName);

        private static readonly string _connStringMaster = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
        private static readonly string _connStringWims = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_databasePath};Integrated Security=True;Connect Timeout=30";
        
        public DatabaseInit()
        {
            try
            {
                if (!CheckIfDataBaseExist())
                {
                    CreateDatabaseFile();
                    ExecuteSqlFile(_sqlSchemaPath, _connStringWims); //SCHEMA FILE
                    ExecuteSqlFile(_sqlSeedPath, _connStringWims); //SEED FILE - COMMENT THIS LINE IF YOU WANT EMPTY DATABASE
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            } 
        }

        public string GetConn()
        {
            return _connStringWims;
        }
        private bool CheckIfDataBaseExist()
        {
            try
            {
                if (File.Exists(_databasePath)) {  return true; }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return false;
        }

        private void CreateDatabaseFile()
        {
            //CREATING EMPTY DATABASE FILE
            try
            {
                using (SqlConnection connMaster = new SqlConnection(_connStringMaster))
                {
                    connMaster.Open();

                    string dbName = Path.GetFileNameWithoutExtension(_databasePath);

                    string createDatabaseSql = $@"CREATE DATABASE [{dbName}] ON PRIMARY 
                                       (NAME = {dbName}_Data, FILENAME = '{_databasePath}')";

                    using (SqlCommand cmd = new SqlCommand(createDatabaseSql, connMaster))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand detachCmd = new SqlCommand($"EXEC sp_detach_db '{dbName}'", connMaster))
                    {
                        detachCmd.ExecuteNonQuery();
                    }
                }
                Debug.WriteLine("Database created!");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }
        private void ExecuteSqlFile(string sqlFilePath, string connString)
        {
            try
            {
                //SLICING THE FILE INFO SINGULAR COMMANDS, EXECUTENONQUERY CANT HANDLE WHOLE FILE WITH GO STATEMANT
                IEnumerable<string> sqlFile = File.ReadLines(sqlFilePath);

                List<string> singleCommands = new List<string>();
                string comandText = "";

                foreach (string line in sqlFile)
                {
                    if (line.Trim().ToUpper() != "GO")
                    {
                        comandText += line + "\n";
                    }
                    else
                    {
                        singleCommands.Add(comandText);
                        comandText = "";
                    }
                }

                //EXECUTING SINGULAR COMMANDS
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    foreach (string command in singleCommands)
                    {
                        using (SqlCommand cmd = new SqlCommand(command, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                Debug.WriteLine("File: " + sqlFilePath + "\nExecuted succesfully");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
