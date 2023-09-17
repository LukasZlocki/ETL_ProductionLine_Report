namespace ETL_ProductionLine_Report.DataExtraction
{
    internal interface ICsvAdapter
    {
        public void SaveToCsvFile(List<string> dataSet, string filePath, string csvFileName);
    }
}