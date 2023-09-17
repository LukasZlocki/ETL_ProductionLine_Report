namespace ETL_ProductionLine_Report.DataTranformation
{
    internal interface IStructureTransform
    {
        public List<List<string>> ConvertCsvToListOfListsStructure(List<string> dataset);
    }
}
