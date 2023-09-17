namespace ETL_ProductionLine_Report.DataExtraction
{
    internal class CsvAdapter : ICsvAdapter
    {
        /// <summary>
        /// Save data from list os strings array (string line in format [data1, data2, data3, data4, ...) to csv file
        /// </summary>
        /// <param name="dataSet">Dataset to convert to csv file as list of strings array.</param>
        /// <param name="filePath">Output file path.</param>
        /// <param name="csvFileName">Output csv file name.</param>
        public void SaveToCsvFile(List<string> dataSet, string filePath, string csvFileName)
        {
            string fullPath = filePath + csvFileName;
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    foreach (string line in dataSet)
                    {
                        sw.WriteLine(line);
                    }
                }
                Console.WriteLine("Data has been successfully saved to CSV file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving to CSV file: {ex.Message}");
            }
        }
    }
}