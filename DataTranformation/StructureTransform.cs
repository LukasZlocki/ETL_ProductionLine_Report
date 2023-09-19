namespace ETL_ProductionLine_Report.DataTranformation
{
    internal class StructureTransform : IStructureTransform
    {
        private List<string[]> MainDataset = new List<string[]>();

        // ToDo:  Method moved to ZIGMA or convert to zigma during reading from csv
        /// <summary>
        /// Converting csv do Zigma dataset
        /// </summary>
        /// <param name="dataset">list of string with csv</param>
        public void ConvertCsvToListOfStringArrayStructure(List<string> dataset)
        {
            List<string[]> _newDataList = new List<string[]>();
            // ToDo: Write unit test for the class
            foreach(string element in dataset)
            {
                string[] divString = element.Split(',');
                _newDataList.Add(divString);
            }
            MainDataset = _newDataList;
        }

        // ToDo: Write a method here:
        /// <summary>
        /// Convert Zigma dataset to csv
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<string> ConvertListOfStringArrayStructureToCsv(List<string[]> dataset)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns Zigma dataset
        /// </summary>
        /// <returns>Zigma dataset</returns>
        public List<string[]> GetDataset()
        {
            return MainDataset;
        }

        // ToDo: Method move to ZIGMA
        /// <summary>
        /// Prints rows of dataset.
        /// </summary>
        /// <param name="quantityOfRowsToPrint">Quantity of rows to print. 0 - print all rows.</param>
        public void PrintDataset(int quantityOfRowsToPrint)
        {
            int counter = 0;
            foreach (string[] element in MainDataset)
            {
                if (counter == quantityOfRowsToPrint) {
                    break;
                }
                string _showString = "";
                for (int i = 0; i < element.Count(); i++)
                {
                    _showString = "" + _showString + ", " + "[ " + element[i] + " ]";
                }
                Console.WriteLine("" + _showString);
                counter++;
            }
        }

        /// <summary>
        /// Transforming given column number to date [yyyy/mm/dd].
        /// </summary>
        /// <param name="columnNumber">Column number to transform into date.</param>
        public void TransformColumnToDate(int columnNumber)
        {
            double daysToAdd;
            string formattedDate;
            DateTime dateConverted;
            DateTime baseDate = new DateTime(1900, 1, 1);
            foreach (string[] element in MainDataset) {

                string elementToConvert = element[columnNumber];
                try
                {
                    daysToAdd = Convert.ToDouble(elementToConvert);
                    dateConverted = baseDate + TimeSpan.FromDays(daysToAdd);
                    formattedDate = dateConverted.ToString("yyyy/MM/dd");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                    continue;
                }
                if (formattedDate != "" || formattedDate != null) {
                    element[columnNumber] = formattedDate;
                } 
            }
        }
    }
}
