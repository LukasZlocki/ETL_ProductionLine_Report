namespace ETL_ProductionLine_Report.DataTranformation
{
    internal interface IStructureTransform
    {
        public void ConvertCsvToListOfStringArrayStructure(List<string> dataset);
        
        // GET
        public List<string[]> GetDataset();

        public void PrintDataset(int quantityOfRowsToPrint);

    }
}
