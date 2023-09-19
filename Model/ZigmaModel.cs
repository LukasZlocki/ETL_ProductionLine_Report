namespace ETL_ProductionLine_Report.Model
{
    public class ZigmaModel : IZigmaModel
    {
        private List<string[]> ZigmaDataset = new List<string[]>();
        private int ZigmaColumnsQuantity;
        private int ZigmaRowsQuantity;

        /// <summary>
        /// Exchange old dataset with new dataset. Old dataset will be deleted.
        /// </summary>
        /// <param name="newDataset">New Zigma data set</param>
        public void ChangeDataset(List<string[]> newDataset)
        {
            if (newDataset != null)
            {
                ZigmaDataset.Clear();
                ZigmaDataset = newDataset;
            }
            else
            {
                Console.Write("Error. Not able to change dataset. Given data set is empty.");
            }

        }

        /// <summary>
        /// Creating Zigma dataset from csv file.
        /// </summary>
        /// <param name="dataset">List of strings with coma separators</param>
        public void CreateZigmaModel(List<string> dataset)
        {
            List<string[]> _newDataList = new List<string[]>();
            // ToDo: Write unit test for the class
            foreach (string element in dataset)
            {
                string[] divString = element.Split(',');
                _newDataList.Add(divString);
            }
            ZigmaDataset = _newDataList;
        }

        /// <summary>
        /// Return Zigma dataset
        /// </summary>
        /// <returns>List<string[]></string></returns>
        public List<string[]> GetDataset()
        {
            return ZigmaDataset;
        }

        /// <summary>
        /// Printing Zigma dataset.
        /// </summary>
        /// <param name="zigmaDataset">Zigma dataset</param>
        /// <param name="quantityOfRowsToPrint">Number of rows to print</param>
        public void PrintDataset(int quantityOfRowsToPrint)
        {
            PrintDataset(ZigmaDataset, quantityOfRowsToPrint);
        }

        /// <summary>
        /// Printing Zigma whole dataset.
        /// </summary>
        public void PrintDataset()
        {
            PrintDataset(ZigmaDataset);
        }

        /// <summary>
        /// Printing Zigma whole dataset.
        /// </summary>
        public void PrintDataset(List<string[]> zigmaDataset)
        {
            PrintDataset(zigmaDataset, 0);
        }

        /// <summary>
        /// Printing Zigma dataset with specific quantity of rows.
        /// </summary>
        /// <param name="zigmaDataset"></param>
        /// <param name="quantityOfRowsToPrint">Number of rows to print.</param>
        public void PrintDataset(List<string[]> zigmaDataset, int quantityOfRowsToPrint)
        {
            int counter = 0;
            foreach (string[] element in ZigmaDataset)
            {
                if (counter == quantityOfRowsToPrint)
                {
                    break;
                }
                string _showString = "" + counter + " ";
                for (int i = 0; i < element.Count(); i++)
                {
                    _showString = "" + _showString + ", " + "[ " + element[i] + " ]";
                }
                Console.WriteLine("" + _showString);
                counter++;
            }
        }

        private int CalculateColumnsQuantity(List<string[]> dataset)
        {
            int _columnsQuantity = dataset[0].Length;
            return _columnsQuantity;
        }
       private int CalculateRowsQuantity(List<string[]> dataset)
        {
            int _rowsQuantity = dataset.Count;
            return _rowsQuantity;
        }
    }
}
