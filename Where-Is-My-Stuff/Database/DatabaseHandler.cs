using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
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
        public void DeleteItem(int id)
        {
            string command = "UPDATE tbl_items SET is_active = 0 WHERE item_id = @id";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteLocation(int id)
        {
            string command = @"
                WITH RecursiveCTE AS (
                    SELECT location_id 
                    FROM tbl_locations 
                    WHERE location_id = @id
            
                    UNION ALL
            
                    SELECT t.location_id 
                    FROM tbl_locations t 
                    INNER JOIN RecursiveCTE rc ON t.parent_id = rc.location_id
                )
                SELECT location_id INTO #TempIDs FROM RecursiveCTE;

                UPDATE tbl_locations 
                SET is_active = 0 
                WHERE location_id IN (SELECT location_id FROM #TempIDs);

                UPDATE tbl_items 
                SET is_active = 0 
                WHERE location_id IN (SELECT location_id FROM #TempIDs);

                DROP TABLE #TempIDs;";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand(command, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                }
            }
        }
        ///
        /// 
        ///

        ///
        /// DRAG & DROP
        ///

        public void MoveLocation(int locationId, int newParentId)
        {
            string query = "UPDATE tbl_locations SET parent_id = @newParentId WHERE location_id = @id";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", locationId);
                    cmd.Parameters.AddWithValue("@newParentId", newParentId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void MoveItem(int itemId, int newLocationId)
        {
            string query = "UPDATE tbl_items SET location_id = @newLocationId WHERE item_id = @id";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", itemId);
                    cmd.Parameters.AddWithValue("@newLocationId", newLocationId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        ///
        ///
        ///

        ///
        /// LOCATION
        /// 
        public void AddLocation(string locationName, string typeName, int parentId)
        {
            string command = @"INSERT INTO tbl_locations (location_name, location_type_id, parent_id) 
                   VALUES (@name, 
                          (SELECT location_type_id FROM tbl_location_type WHERE location_type_name = @typeName), 
                          @parentId)";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@name", locationName);
                cmd.Parameters.AddWithValue("@typeName", typeName);
                cmd.Parameters.AddWithValue("@parentId", parentId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EditLocation(string locationName, int locationId)
        {
            string command = "UPDATE tbl_locations SET location_name = @newName WHERE location_id = @id";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@newName", locationName);
                cmd.Parameters.AddWithValue("@id", locationId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void AddRoom(string roomName)
        {
            string command = @"INSERT INTO tbl_locations (location_name, location_type_id, parent_id) 
                   VALUES (@name, 
                          1, 
                          NULL)";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@name", roomName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// 
        /// 
        /// 

        ///
        /// ITEM
        /// 
        public void AddItem(int locationId, string categoryName, string ownerName, string itemName, string description)
        {
            string command = @"INSERT INTO tbl_items (location_id, category_id, owner_id, item_name, item_description) 
                       VALUES (
                           @locId, 
                           (SELECT category_id FROM tbl_categories WHERE category_name = @catName), 
                           (SELECT owner_id FROM tbl_owners WHERE owner_name = @ownerName), 
                           @itemName, 
                           @desc
                       )";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@locId", locationId);
                cmd.Parameters.AddWithValue("@catName", categoryName);
                cmd.Parameters.AddWithValue("@ownerName", ownerName);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@desc", (object)description ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EditItem(int itemId, string itemName, string categoryName, string ownerName, string description)
        {
            string command = @"UPDATE tbl_items 
                       SET item_name = @itemName, 
                           item_description = @desc,
                           category_id = (SELECT category_id FROM tbl_categories WHERE category_name = @catName),
                           owner_id = (SELECT owner_id FROM tbl_owners WHERE owner_name = @ownerName)
                       WHERE item_id = @itemId";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@itemId", itemId);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@catName", categoryName);
                cmd.Parameters.AddWithValue("@ownerName", ownerName);
                cmd.Parameters.AddWithValue("@desc", (object)description ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        /// 
        /// 
        /// 

        ///
        /// GET ITEM LOCATION PATH
        /// 
        public string GetLocationPath(int id, string itemName)
        {
            List<string> pathList = new List<string>();
            int currentId = id;
            string fullPath = "";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();

                while (currentId != -1)
                {
                    string command = "SELECT location_name, parent_id FROM tbl_locations WHERE location_id = @id";

                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", currentId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string name = reader["location_name"].ToString();

                                pathList.Add(name);

                                if (reader.IsDBNull(reader.GetOrdinal("parent_id")))
                                {
                                    currentId = -1;
                                }
                                else
                                {
                                    currentId = Convert.ToInt32(reader["parent_id"]);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            pathList.Reverse();

            foreach (string path in pathList)
            {
                fullPath += path+"/";
            }
            fullPath += itemName;

            return fullPath;
        }

        /// 
        /// 
        /// 
        

        ///
        /// COMBOBOX
        ///

        public List<string> GetValueForCombobox(string table_name, string field_name)
        {
            List<string> value = new List<string>();

            string command = $"SELECT * FROM {table_name}";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                conn.Open();
               
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        string name = reader.GetString(reader.GetOrdinal(field_name));                       
                        value.Add(name);
                    }
                }
            }
            return value;
        }
        public string GetNameOfCategory(int id)
        {
            string command = "SELECT category_name FROM tbl_categories WHERE category_id = @id";
            string categoryName = "";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        categoryName = reader["category_name"].ToString();
                    }
                }
            }
            return categoryName;
        }
        public string GetNameOfOwner(int id)
        {
            string command = "SELECT owner_name FROM tbl_owners WHERE owner_id = @id";
            string ownerName = "";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ownerName = reader["owner_name"].ToString();
                    }                
                }
            }
            return ownerName;
        }
        public string GetNameOfType(int id)
        {
            string command = "SELECT location_type_name FROM tbl_location_type WHERE location_type_id = @id";
            string typeName = "";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        typeName = reader["location_type_name"].ToString();
                    }
                }
            }
            return typeName;
        }

        ///
        /// 
        ///

        ///
        ///    GET ITEMS
        ///
        public DataTable GetItmes()
        {
            DataTable dt = new DataTable();
            string command = "SELECT i.item_id, i.item_description, i.item_name as 'Przedmiot', c.category_name as 'Kategoria', o.owner_name as 'Właściciel', l.location_name as 'Lokalizacja' " +
                             "FROM tbl_items as i " +
                             "INNER JOIN tbl_categories as c ON i.category_id = c.category_id " +
                             "INNER JOIN tbl_owners as o ON i.owner_id = o.owner_id " +
                             "INNER JOIN tbl_locations as l on i.location_id = l.location_id " +
                             "WHERE i.is_active = 1";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        ///
        /// 
        ///

        ///
        ///    GET ALL CATEGORIES
        ///
        public List<string> GetCategories()
        {
            List<string> category = new List<string>();

            string command = "SELECT category_name from tbl_categories";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string name = reader.GetString(reader.GetOrdinal("category_name"));
                        category.Add(name);
                    }
                }
            }
            return category;
        }
        ///
        /// 
        ///

        ///
        ///    GET ALL COWNERS
        ///
        public List<string> GetOwners()
        {
            List<string> owner = new List<string>();

            string command = "SELECT owner_name from tbl_owners";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string name = reader.GetString(reader.GetOrdinal("owner_name"));
                        owner.Add(name);
                    }
                }
            }
            return owner;
        }

        ///
        /// 
        ///

        ///
        ///    ADD NEW CATEGORY
        ///   
        public void AddCategory(string category)
        {
            string command = "INSERT INTO tbl_categories (category_name) VALUES (@category_name)";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);               

                cmd.Parameters.AddWithValue("@category_name", category);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }            
        }

        ///
        /// 
        ///

        ///
        ///    ADD NEW OWNER
        ///   
        public void AddOwner(string category)
        {
            string command = "INSERT INTO tbl_owners (owner_name) VALUES (@owner_name)";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@owner_name", category);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        ///
        /// 
        ///

        ///
        ///    LOGI
        ///   
        public DataSet GetLogs()
        {
            DataSet ds = new DataSet();
            string command = @"SELECT 
                                    *,
                                    CASE 
                                        WHEN can_undo = 1 THEN 'Można przywrócić'
                                        ELSE 'Nie można przywrócić'
                                    END AS undo_status
                                FROM tbl_logs 
                                ORDER BY log_id DESC";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command, conn))
                {
                    adapter.Fill(ds, "LogsTable");
                }
            }
            return ds;
        }
        ///
        /// 
        ///

        ///
        ///    LOGI DO ZMIANY
        ///   
        public DataTable GetLogsToUndo(int targetLogId)
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM tbl_logs WHERE log_id >= @targetId AND can_undo = 1 ORDER BY log_id DESC";

            using (SqlConnection conn = new SqlConnection(_conn)) 
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@targetId", targetLogId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        ///
        /// 
        ///

        ///
        ///    DATA SET DO COFNIĘCIA ZMIAN
        ///   
        public DataSet GetDataSetForLogs()
        {
            DataSet ds = new DataSet();

            string query = @"
                            SELECT * FROM tbl_categories;
                            SELECT * FROM tbl_owners;
                            SELECT * FROM tbl_locations;
                            SELECT * FROM tbl_items;";

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    adapter.TableMappings.Add("Table", "tbl_categories");
                    adapter.TableMappings.Add("Table1", "tbl_owners");
                    adapter.TableMappings.Add("Table2", "tbl_locations");
                    adapter.TableMappings.Add("Table3", "tbl_items");

                    adapter.Fill(ds);
                }
            }
            return ds;
        }
        ///
        /// 
        ///

        ///
        ///    ZAPISYWANIE ZMIAN W DATA SET
        ///   
        public void SaveUndoChanges(DataSet dataSetBase, List<int> undoneLogIds)
        {
            DataSet dataSetFinal = new DataSet();
            if (dataSetBase.HasChanges())
            {
                dataSetFinal = dataSetBase.GetChanges();
                if (dataSetFinal.HasErrors)
                {
                    dataSetBase.RejectChanges();
                    throw new Exception("Wykryto błędy w pamięci DataSet. Zmiany odrzucone.");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(_conn))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("EXEC sp_set_session_context N'IsUndo', 1;", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // Usuwanie
                        UpdateRowsByState(dataSetFinal.Tables["tbl_items"], DataViewRowState.Deleted, conn);
                        UpdateRowsByState(dataSetFinal.Tables["tbl_locations"], DataViewRowState.Deleted, conn);
                        UpdateRowsByState(dataSetFinal.Tables["tbl_categories"], DataViewRowState.Deleted, conn);
                        UpdateRowsByState(dataSetFinal.Tables["tbl_owners"], DataViewRowState.Deleted, conn);

                        // Dodawanie
                        UpdateRowsByState(dataSetFinal.Tables["tbl_categories"], DataViewRowState.Added, conn);
                        UpdateRowsByState(dataSetFinal.Tables["tbl_owners"], DataViewRowState.Added, conn);
                        UpdateRowsByState(dataSetFinal.Tables["tbl_locations"], DataViewRowState.Added, conn);
                        UpdateRowsByState(dataSetFinal.Tables["tbl_items"], DataViewRowState.Added, conn);

                        // Modyfikacje
                        UpdateRowsByState(dataSetFinal.Tables["tbl_categories"], DataViewRowState.ModifiedCurrent, conn);
                        UpdateRowsByState(dataSetFinal.Tables["tbl_owners"], DataViewRowState.ModifiedCurrent, conn);
                        UpdateRowsByState(dataSetFinal.Tables["tbl_locations"], DataViewRowState.ModifiedCurrent, conn);
                        UpdateRowsByState(dataSetFinal.Tables["tbl_items"], DataViewRowState.ModifiedCurrent, conn);
                    }
                }
            }

            if (undoneLogIds != null && undoneLogIds.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    string ids = string.Join(",", undoneLogIds);
                    string disableQuery = $"UPDATE tbl_logs SET can_undo = 0 WHERE log_id IN ({ids});";

                    using (SqlCommand cmd = new SqlCommand(disableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string insertLog = @"
                                        INSERT INTO tbl_logs (operation_type_id, log_message, tbl_name, can_undo) 
                                        VALUES (3, 'Cofnięto zmiany z historii operacji', 'System', 0);";

                    using (SqlCommand cmd = new SqlCommand(insertLog, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void UpdateRowsByState(DataTable table, DataViewRowState state, SqlConnection conn)
        {
            if (table == null) return;

            DataRow[] rows = table.Select("", "", state);

            if (rows.Length > 0)
            {
                string pk = table.PrimaryKey.Length > 0 ? table.PrimaryKey[0].ColumnName : table.Columns[0].ColumnName;

                if (state == DataViewRowState.Deleted)
                {
                    rows = rows.OrderByDescending(r => r[pk, DataRowVersion.Original]).ToArray();
                }
                else if (state == DataViewRowState.Added)
                {
                    rows = rows.OrderBy(r => r[pk]).ToArray();
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {table.TableName}", conn))
                {
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                    {
                        adapter.Update(rows);
                    }
                }
            }
        }
    }
}
