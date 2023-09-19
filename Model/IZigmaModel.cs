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
        public void PrintDataset(int quantityOfRowsToPrint);
        public void PrintDataset();
        public void PrintDataset(List<string[]> zigmaDataset, int quantityOfRowsToPrint);
    }
}
