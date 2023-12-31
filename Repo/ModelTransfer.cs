using ETL_ProductionLine_Report.Models;
using Zigma.Models;

namespace ETL_ProductionLine_Report.Repo {
public static class ModelTransfer 
{
    public static ZigmaModel TransferReportDailyListToZigmaModel(List<ReportDaily> listOfDailyReports) {
        List<string[]> _zRawModel = new List<string[]>();
        foreach (ReportDaily report in listOfDailyReports){
            string[] row = new string[] {report.Date, report.PlannedOutput, report.RealOutput, report.RealOutput};
            _zRawModel.Add(row);
        }
        ZigmaModel _zModel = new();
        _zModel.CreateZigmaDatasetFromRawDataset(_zRawModel);
        return _zModel;
    }

    }
}