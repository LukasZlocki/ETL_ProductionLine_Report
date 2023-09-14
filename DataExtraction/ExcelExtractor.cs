using Microsoft.Office.Interop.Excel;
using System.Reflection.Metadata.Ecma335;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ETL_ProductionLine_Report.DataExtraction
{
    class ExcelExtractor
    {
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        string path;
        
        // constr
        public ExcelExtractor(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
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
            return ws.UsedRange.Columns.Count;
        }

        public int GetTotalRows()
        {
            return ws.UsedRange.Rows.Count;
        }

    }
}