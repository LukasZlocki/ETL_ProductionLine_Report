namespace ETL_ProductionLine_Report.DataLoad
{
    internal interface ICsvAdapter
    {
        public void SaveDataset(string pathName, string fileName, List<string[]> dataSet);
        public List<string[]> LoadDataset(string pathName, string fileName);
    }
}
