using ETL_ProductionLine_Report.DataExtraction;

// Get the base directory of your application
//string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
//string path = "Source\\jedox_new.xlsm";
//string fullPath = Path.Combine(baseDirectory, path);
string fullPath = "C:/jedox/jedox_new.xlsm";

// ETL project
Console.WriteLine("Let's do it !");

ExcelExtractor de = new ExcelExtractor(fullPath, 3);
Console.WriteLine("" + Convert.ToString(de.ReadCell(2,2)));
Console.WriteLine("Total Columns: " + de.GetTotalColumns());
Console.WriteLine("Total Rows: " + de.GetTotalRows());
