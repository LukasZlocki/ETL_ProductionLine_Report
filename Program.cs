using ETL_ProductionLine_Report.DataExtraction;

// Get the base directory of your application
string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
string path = "Source\\jedox_new.xlsm";
string fullPath = Path.Combine(baseDirectory, path);
fullPath = "C:/jedox/jedox_new.xlsm";

// ETL project
Console.WriteLine("Let's do it !");

ExcelExtractor de = new ExcelExtractor(fullPath, 3);
Console.WriteLine("" + Convert.ToString(de.ReadCell(2,2)));
Console.WriteLine("Total Columns: " + de.GetTotalColumns());
Console.WriteLine("Total Rows: " + de.GetTotalRows());

// Testing loading data from excel to strings
Console.WriteLine("Testing loading data from excel to strings");
string oneDataStringLine = "";
for (int i=0; i<=50; i++)
{
    for (int j=0; j<=de.GetTotalColumns(); j++)
    {
        string dataString = Convert.ToString(de.ReadCell(i, j));
        if (dataString != "end of excel data")
        {
            oneDataStringLine = oneDataStringLine + dataString + ",";
            continue;
        }
        oneDataStringLine = oneDataStringLine.TrimEnd(',');
    }
    Console.WriteLine("" + oneDataStringLine);
    oneDataStringLine = "";
}