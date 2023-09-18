using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_ProductionLine_Report.Model
{
    internal interface IZigmaModel
    {
        public List<string[]> GetDataset();
        public void ChangeDataset(List<string[]> newDataset);
        public void PrintDataset(List<string> dataset, int rowsToPrint);
        public void PrintDataset(List<string> dataset);
    }
}
