using ETL_ProductionLine_Report.DataExtraction;
using ETL_ProductionLine_Report.DataTranformation;

// Get the base directory of your application
//string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
//string path = "Source\\jedox_new.xlsm";
//string fullPath = Path.Combine(baseDirectory, path);
string fullPath = "C:/jedox/jedox_new.xlsm";

// ETL project
Console.WriteLine("Let's do it !");

ExcelExtractor de = new ExcelExtractor(fullPath, 3);
Console.WriteLine("" + Convert.ToString(de.ReadCell(2,2)));

// Extracting data here
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Test to extract and show data from excel file");
ExcelExtractor ee = new ExcelExtractor(fullPath, 3);
ee.ExtractDataFromExcelFile();
ee.ShowExtractedDataFromExcelFile(5);
//ee.ShowExtractedDataFromExcelFile(0);


// DATA TRANSFORMATION
StructureTransform st = new StructureTransform();
Console.WriteLine("Tranforming data structure");
st.ConvertCsvToListOfStringArrayStructure(ee.GetExtractedDataset());
st.PrintDataset(5);
Console.WriteLine("Tranforming date time ");
st.TransformColumnToDate(0);
st.PrintDataset(5);
