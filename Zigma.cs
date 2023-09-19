using ETL_ProductionLine_Report.DataExtraction;
using ETL_ProductionLine_Report.DataTranformation;
using ETL_ProductionLine_Report.Model;

namespace ETL_ProductionLine_Report
{
    internal class Zigma : ICsvAdapter, IStructureTransform, IZigmaModel
    {
    {
        private ZigmaModel model;
        private CsvAdapter csvAdapter;
        private StructureTransform structTransform;

        public Zigma()
        {
            model = new ZigmaModel();
            csvAdapter = new CsvAdapter();
            structTransform = new StructureTransform();
        }

        public void ChangeDataset(List<string[]> newDataset)
        {
            throw new NotImplementedException();
        }

        public void ConvertCsvToListOfStringArrayStructure(List<string> dataset)
        {
            throw new NotImplementedException();
        }

        public List<string> ConvertListOfStringArrayStructureToCsv(List<string[]> dataset)
        {
            throw new NotImplementedException();
        }

        public void CreateZigmaModel(List<string> csvModel)
        {
            throw new NotImplementedException();
        }

        public List<string[]> GetDataset()
        {
            throw new NotImplementedException();
        }

        public void PrintDataset(int quantityOfRowsToPrint)
        {
            throw new NotImplementedException();
        }

        public void PrintDataset()
        {
            throw new NotImplementedException();
        }

        public void PrintDataset(List<string[]> zigmaDataset, int quantityOfRowsToPrint)
        {
            throw new NotImplementedException();
        }

        public void SaveToCsvFile(List<string> dataSet, string filePath, string csvFileName)
        {
            csvAdapter.SaveToCsvFile(dataSet, filePath, csvFileName);
        }
    }
}
