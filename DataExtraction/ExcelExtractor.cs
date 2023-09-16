using Microsoft.Office.Interop.Excel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
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
        }

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
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null)
                return ws.Cells[i, j].Value2.ToString();
            else
                return "end of excel data";
        }

        public int GetTotalColumns()
        {
            return totalColumns;
        }

        public int GetTotalRows()
        {
            return totalRows;
        }

    }
}