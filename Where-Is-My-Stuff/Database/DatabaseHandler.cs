using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Where_Is_My_Stuff.Services;

namespace Where_Is_My_Stuff.Database
{
    internal class DatabaseHandler
    {
        private static readonly DatabaseHandler _instance = new DatabaseHandler();
        private string _conn;
        private DatabaseHandler() {} 

        public static DatabaseHandler Instance => _instance;

        
        public void SetConnection(string connString)
        {
            _conn = connString;
        }
        /// <summary>
        /// EXECUTING COMMAND / DRY RULE
        /// </summary>
        /// <param name="command"></param>
        private void ExecuteSqlCommand(string command)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                Debug.WriteLine("COMMAND" + command  + "EXECUTED");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private void AddLog(string operationType, string message, string oldValue, string newValue) { }

        ///
        /// TREE VIEW
        ///
        public List<TreeNodeLocation> GetAllLocationsForTreeView()
        {
            List<TreeNodeLocation> locations = new List<TreeNodeLocation>();

            string command = "SELECT * FROM tbl_locations WHERE is_active = 1";
            
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("location_id"));
                        string name = reader.GetString(reader.GetOrdinal("location_name"));
                        int typeId = reader.GetInt32(reader.GetOrdinal("location_type_id"));
                        int parentId;

                        if (reader.IsDBNull(reader.GetOrdinal("parent_id")))
                        {
                            parentId = -1;
                        }
                        else
                        {
                            parentId = reader.GetInt32(reader.GetOrdinal("parent_id"));
                        }

                        TreeNodeLocation location = new TreeNodeLocation(id, name, parentId, typeId);
                        locations.Add(location);
                    }
                }
            }

            return locations;
        }

        public List<TreeNodeItem> GetAllItemsForTreeView()
        {
            List<TreeNodeItem> items = new List<TreeNodeItem>();

            string command = "SELECT * FROM tbl_items WHERE is_active = 1";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("item_id"));
                        int location_id = reader.GetInt32(reader.GetOrdinal("location_id"));
                        int category_id = reader.GetInt32(reader.GetOrdinal("category_id"));
                        int owner_id = reader.GetInt32(reader.GetOrdinal("owner_id"));
                        string name = reader.GetString(reader.GetOrdinal("item_name"));
                        string description;

                        if (reader.IsDBNull(reader.GetOrdinal("item_description")))
                        {
                            description = null;
                        }
                        else
                        {
                            description = reader.GetString(reader.GetOrdinal("item_description"));
                        }

                        TreeNodeItem item = new TreeNodeItem(id, name, location_id, description, category_id, owner_id);
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        //GET ALL ROOT+
        //GET ALL NODES FOR ROOT

        ///
        /// 
        ///
    }
}
