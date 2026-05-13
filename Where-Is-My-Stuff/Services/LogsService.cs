using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using Where_Is_My_Stuff.Database;


namespace Where_Is_My_Stuff.Services
{
    internal class LogsService
    {
        public bool UndoLogs(int logId)
        {
            try
            {
                var dh = DatabaseHandler.Instance;

                DataTable logsToUndo = dh.GetLogsToUndo(logId);
                DataSet originalData = dh.GetDataSetForLogs();
                DataSet workingData = originalData.Copy();

                List<int> undoneLogIds = new List<int>();

                foreach (DataRow log in logsToUndo.Rows)
                {
                    int currentLogId = Convert.ToInt32(log["log_id"]);
                    undoneLogIds.Add(currentLogId);

                    string tbl = log["tbl_name"].ToString();
                    int op = Convert.ToInt32(log["operation_type_id"]);
                    string old_value = log["old_value"].ToString();
                    string new_value = log["new_value"].ToString();

                    GetChanges(workingData, tbl, op, old_value, new_value);
                }

                DataSet differences = workingData.GetChanges();
                dh.SaveUndoChanges(workingData, undoneLogIds);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Błąd w LogsService: " + ex.Message);
                return false;
            }
        }

        private void GetChanges(DataSet workingData, string tbl, int op, string old_value, string new_value)
        {
            DataTable table = workingData.Tables[tbl];

            string primaryKeyCol = table.PrimaryKey.Length > 0 ? table.PrimaryKey[0].ColumnName : table.Columns[0].ColumnName;

            var oldDict = string.IsNullOrEmpty(old_value) ? null : JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(old_value);
            var newDict = string.IsNullOrEmpty(new_value) ? null : JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(new_value);

            if (op == 1) // 1 - DELETE 
            {
                DataRow newRow = table.NewRow();
                foreach (var kvp in oldDict)
                {
                    if (table.Columns.Contains(kvp.Key))
                    {
                        if (table.Columns[kvp.Key].ReadOnly)
                        {
                            continue;
                        }

                        newRow[kvp.Key] = kvp.Value.ToString();
                    }
                }
                table.Rows.Add(newRow);
            }
            else if (op == 2) // 2 - INSERT
            {
                string idToDelete = newDict[primaryKeyCol].ToString();
                DataRow[] rowsToDel = table.Select($"{primaryKeyCol} = '{idToDelete}'");
                if (rowsToDel.Length > 0)
                {
                    rowsToDel[0].Delete();
                }
            }
            else if (op == 3) // 3 - UPDATE
            {
                string idToUpdate = oldDict[primaryKeyCol].ToString();
                DataRow[] rowsToUpd = table.Select($"{primaryKeyCol} = '{idToUpdate}'");

                if (rowsToUpd.Length > 0)
                {
                    foreach (var kvp in oldDict)
                    {
                        if (table.Columns.Contains(kvp.Key))
                        {
                            if (kvp.Key == primaryKeyCol || table.Columns[kvp.Key].ReadOnly)
                            {
                                continue;
                            }
                            rowsToUpd[0][kvp.Key] = kvp.Value.ToString();
                        }
                    }
                }
            }
        }
    }

}
