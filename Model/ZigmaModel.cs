using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_ProductionLine_Report.Model
{
    internal class ZigmaModel : IZigmaModel
    {
        private List<string[]> ZigmaDataset = new List<string[]>();
        private int ZigmaColumnsQuantity;
        private int ZigmaRowsQuantity;

        /// <summary>
        /// Change old dataset with new dataset. Old dataset will be deleted.
        /// </summary>
        /// <param name="newDataset">New Zigma datasaet</param>
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

        public void PrintDataset(int quantityOfRowsToPrint)
        {
            PrintDataset(ZigmaDataset, quantityOfRowsToPrint);
        }

        public void PrintDataset()
        {
            PrintDataset(ZigmaDataset);
        }

        public void PrintDataset(List<string[]> zigmaDataset)
        {
            throw new NotImplementedException();
        }

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
