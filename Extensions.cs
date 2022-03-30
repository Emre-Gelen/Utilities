using System.Data;
namespace UtilProject
{
    public static class Extensions
    {
        /// <summary>
        /// This extension returns transpose of given multiple column datatable.
        /// </summary>
        /// <returns>DataTable</returns>
        /// <param name="keyColumnName">Column name that row values became columns of transposed datatable.</param>
        /// <param name="dataColumnName">Column name that row values became rows of transposed datatable.</param>
        public static DataTable Transpose(this DataTable table, string keyColumnName, string dataColumnName)
        {
            DataTable result = new DataTable();
            List<string> newColumns = table.Rows.ToList(keyColumnName);

            foreach (string column in newColumns)
            {
                result.Columns.Add(new DataColumn(column));
            }

            int maxRowCount = 0;
            foreach (string columnName in newColumns)
            {
                int rowCounter = 0;
                foreach (DataRow currentRow in table.Rows)
                {
                    if (columnName.Equals(currentRow[keyColumnName].ToString()))
                    {
                        if (maxRowCount > rowCounter)
                        {
                            result.Rows[rowCounter][columnName] = currentRow[dataColumnName];
                        }
                        else
                        {
                            DataRow dr = result.NewRow();
                            dr[columnName] = currentRow[dataColumnName];
                            result.Rows.Add(dr);
                            maxRowCount++;
                        }
                        rowCounter++;
                    }
                }
            }
            return result;
        }
        public static List<string> ToList(this DataRowCollection dataRows, string keyColumnName)
        {
            List<string> result = new List<string>();
            foreach (DataRow row in dataRows)
            {
                if (!result.Any(column => column.Equals(row[keyColumnName])))
                {
                    result.Add(row[keyColumnName].ToString());
                }
            }
            return result;
        }
    }
}
