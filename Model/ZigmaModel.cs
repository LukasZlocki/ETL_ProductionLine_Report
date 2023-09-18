using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_ProductionLine_Report.Model
{
    internal class ZigmaModel : IZigmaModel
    {
        private List<string[]> Model = new List<string[]>();

        public void ChangeDataset(List<string[]> newDataset)
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

        public void PrintDataset(List<string> dataset, int rowsToPrint)
        {
            throw new NotImplementedException();
        }

        public void PrintDataset(List<string> dataset)
        {
            throw new NotImplementedException();
        }
    }
}
