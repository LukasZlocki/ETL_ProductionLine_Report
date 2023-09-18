namespace ETL_ProductionLine_Report.Model
{
    internal interface IZigmaModel
    {
        // Create
        public void CreateZigmaModel(List<string> csvModel);
        // Get
        public List<string[]> GetDataset();
        // Update
        public void ChangeDataset(List<string[]> newDataset);
        // Print
        public void PrintDataset(List<string> dataset, int rowsToPrint);
        public void PrintDataset(List<string> dataset);
    }
}
