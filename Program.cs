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

// Extracting data here
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Test to extract and show data from excel file");
ExcelExtractor ee = new ExcelExtractor(fullPath, 3);
ee.ExtractDataFromExcelFile();
ee.ShowExtractedDataFromExcelFile(5);
