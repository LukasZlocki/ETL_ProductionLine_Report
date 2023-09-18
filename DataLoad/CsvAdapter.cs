namespace ETL_ProductionLine_Report.DataLoad
{
    internal class CsvAdapter : ICsvAdapter
    {
        public List<string[]> LoadDataset(string pathName, string fileName)
        {
            throw new NotImplementedException();
        }

        public void SaveDataset(string pathName, string fileName, List<string[]> dataSet)
        {
            string fullPath = pathName + fileName;
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
