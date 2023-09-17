using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ETL_ProductionLine_Report.DataExtraction
{
    class ExcelExtractor
    {
        private _Application excel = new _Excel.Application();
        private Workbook wb;
        private Worksheet ws;
        private string path;
        private int totalColumns;
        private int totalRows;
        
        private List<string> dataSet = new List<string>(); 

        // constr
        public ExcelExtractor(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
            totalColumns = ws.UsedRange.Columns.Count;
            totalRows = ws.UsedRange.Rows.Count;
        }

        /// <summary>
        /// Extracts data from excel file.
        /// </summary>
        public void ExtractDataFromExcelFile()
        {
            string oneDataStringLine = "";

            for (int i = 0; i <= 50; i++)
            {
                for (int j = 0; j <= totalColumns; j++)
                {
                    string dataString = Convert.ToString(ReadCell(i, j));
                    if (dataString != "end of excel data")
                    {
                        oneDataStringLine = oneDataStringLine + dataString + ",";
                        continue;
                    }           
                }
                oneDataStringLine = oneDataStringLine.TrimEnd(',');
                dataSet.Add(oneDataStringLine); // Adding row of data string to main dataset
                oneDataStringLine = "";
            }
            Console.WriteLine("Data extracted.");
            ShowQuantityOfRowsAndColumnsInDataset();
        }

        /// <summary>
        /// Show rows with extracted data. 
        /// </summary>
        /// <param name="rowsToShow">Quantity of rows to show. 0 - show all rows.</param>
        public void ShowExtractedDataFromExcelFile(int rowsToShow)
        {
            int counter = 0;
            foreach(string element in dataSet)
            {
                Console.WriteLine(element);
                counter++;
                if (counter == rowsToShow) {
                    break;
                }
            }
            ShowQuantityOfRowsAndColumnsInDataset();
        }

        /// <summary>
        /// Reading data from one cell.
        /// </summary>
        /// <param name="i">Column number.</param>
        /// <param name="j">Row number.</param>
        /// <returns>Data from excel cell.</returns>
        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null)
                return ws.Cells[i, j].Value2.ToString();
            else
                return "end of excel data";
        }

        // GET
        /// <summary>
        /// Get total quantity of columns in extracted data from excel file.
        /// </summary>
        /// <returns>Quantity of columns.</returns>
        public int GetTotalColumns()
        {
            return totalColumns + 1;
        }

        // GET
        /// <summary>
        /// Get total quantity of rows in extracted data from excel file.
        /// </summary>
        /// <returns>Quantity of rows.</returns>
        public int GetTotalRows()
        {
            return totalRows + 1;
        }

        // GET
        /// <summary>
        /// Send dataSet with extracted data from excel file.
        /// </summary>
        /// <returns>list of strings arrays as data set.</returns>
        public List<string> GetExtractedDataset()
        {
            return dataSet;
        }

        private void ShowQuantityOfRowsAndColumnsInDataset()
        {
            Console.WriteLine();
            Console.WriteLine("Extracted data set information:");
            Console.WriteLine("Total Columns: " + (totalColumns + 1));
            Console.WriteLine("Total Rows: " + (totalRows + 1));
        }
    }
}