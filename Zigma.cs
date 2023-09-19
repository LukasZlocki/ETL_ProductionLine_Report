using ETL_ProductionLine_Report.DataExtraction;
using ETL_ProductionLine_Report.DataTranformation;
using ETL_ProductionLine_Report.Model;

namespace ETL_ProductionLine_Report
{
    public class Zigma : ICsvAdapter, IStructureTransform, IZigmaModel
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

        #region ZigmaModel
        /// <summary>
        /// Exchange old dataset with new dataset. Old dataset will be deleted.
        /// </summary>
        /// <param name="newDataset">New Zigma data set.</param>
        public void ChangeDataset(List<string[]> newDataset)
        {
            model.ChangeDataset(newDataset);
        }

        /// <summary>
        /// Printing Zigma whole dataset.
        /// </summary>
        public void PrintDataset()
        {
            model.PrintDataset();
        }

        /// <summary>
        /// Printing Zigma dataset with specific quantity of rows.
        /// </summary>
        /// <param name="zigmaDataset">Zigma dataset.</param>
        /// <param name="quantityOfRowsToPrint">Number of rows to print</param>
        public void PrintDataset(List<string[]> zigmaDataset, int quantityOfRowsToPrint)
        {
            model.PrintDataset(zigmaDataset, quantityOfRowsToPrint);
        }

        /// <summary>
        /// Creating Zigma dataset from csv file.
        /// </summary>
        /// <param name="dataset">List of strings with coma separators</param>
        public void CreateZigmaModel(List<string> csvModel)
        {
            model.CreateZigmaModel(csvModel);
        }
        #endregion

        #region StructureTransform
        // ToDo: Method moved to ZIGMA or convert to zigma during reading from csv
        /// <summary>
        /// Converting csv do Zigma dataset
        /// </summary>
        /// <param name="dataset">list of string with csv</param>
        public void ConvertCsvToListOfStringArrayStructure(List<string> dataset)
        {
            structTransform.ConvertCsvToListOfStringArrayStructure(dataset);
        }

        /// <summary>
        /// Convert Zigma dataset to csv
        /// </summary>
        /// <param name="dataset">Zigma dataset</param>
        /// <returns>List<string></returns>
        public List<string> ConvertListOfStringArrayStructureToCsv(List<string[]> dataset)
        {
            return structTransform.ConvertListOfStringArrayStructureToCsv(dataset);
        }

        /// <summary>
        /// Returns Zigma dataset
        /// </summary>
        /// <returns>Zigma dataset</returns>
        public List<string[]> GetDataset()
        {
            return structTransform.GetDataset();
        }

        // ToDo: Method move to Zigma
        /// <summary>
        /// Prints rows of dataset.
        /// </summary>
        /// <param name="quantityOfRowsToPrint">Quantity of rows to print. 0 - print all rows.</param>
        public void PrintDataset(int quantityOfRowsToPrint)
        {
            structTransform.PrintDataset(quantityOfRowsToPrint);
        }
        #endregion

        #region CsvAdapter
        /// <summary>
        /// Save data from list os strings array (string line in format [data1, data2, data3, data4, ...) to csv file
        /// </summary>
        /// <param name="dataSet">Dataset to convert to csv file as list of strings array.</param>
        /// <param name="filePath">Output file path.</param>
        /// <param name="csvFileName">Output csv file name.</param>
        public void SaveToCsvFile(List<string> dataSet, string filePath, string csvFileName)
        {
            csvAdapter.SaveToCsvFile(dataSet, filePath, csvFileName);
        }
        #endregion

    }
}
