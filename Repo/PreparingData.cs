// [06112023]
// this part was creating to separate of preparation data process from further data processing
// Steps taken in this part of code:
// - Extracting raw data from csv file
// - Removing not needed column
// - Simplify date description in dataset
// - 

using Zigma.ExtractionTools;
using Zigma.Models;
using Zigma.TransformationTools;

namespace ETL_ProductionLine_Report.Repo 
{

        public class PreparingData 
        {
            public ZigmaModel model = new();

            static string filePath = "C:\\0 VirtualServer\\ETL\\";
            static string fileName = "raw_raports.csv";

            public PreparingData()
            {
                model = ExtractingRawDataFromCsvFile(model, filePath, fileName);
                model = RemovingNotNeededColumn(model);
                model = SimplifyDateDescriptionInDataset(model);
            }

            private ZigmaModel ExtractingRawDataFromCsvFile(ZigmaModel _model, string _filePath, string _fileName)
            {
                ExtractionTool _extraction = new();
                // Extracting raw data from csv file to ZigmaModel
                _model.CreateZigmaDataset(_extraction.LoadFromCsvFile(_filePath, _fileName));
                return _model;
            }

            private ZigmaModel RemovingNotNeededColumn(ZigmaModel _model)
            {
                TransformationTool _transform = new();
                // Removing col 0 with row nummber
                _model = _transform.ColumnRemove(model, 0);
                return _model;
            }

            private ZigmaModel SimplifyDateDescriptionInDataset(ZigmaModel _model)
            {
                // Change date in dataset
                // is [2022-02-21 00:00:00]
                // will be [2022-02-21]
                TransformationTool _transform = new();
                _model = _transform.TransformColumnToDate(_model, 0);
                return _model;
            }

    }
}