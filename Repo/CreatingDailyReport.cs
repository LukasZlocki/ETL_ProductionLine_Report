
// this part was creating to separate of creating daily reports for further data processing
// Steps taken in this part of code:
// - Extracting dates
// - Calculate daily report
// - transfer calculated daily reports to ZigmaModel

using ETL_ProductionLine_Report.Models;
using ETL_ProductionLine_Report.Services;
using Zigma.ExtractionTools;
using Zigma.Models;

namespace ETL_ProductionLine_Report.Repo
{

    public class CreatingDailyReport
    {
        List<string> ListOfDates = new List<string>();
        ZigmaModel DailyReports = new();

        public CreatingDailyReport(ZigmaModel dataset)
        {
            ZigmaModel extractedDates = ExtractingDatesFromRawDataset(dataset);
            List<ReportDaily> DailyRep = CalculateDailyReports(extractedDates, dataset);
            DailyReports = TransferDailyReportsDataToZigmaModel(DailyRep);
        }

        private ZigmaModel ExtractingDatesFromRawDataset(ZigmaModel _dataset)
        {
            ReportService serviceReport = new();
            List<string> _listOfDates = new();
            _listOfDates = serviceReport.GetListOfDatesFromDataset(_dataset.GetRawZigmaDataset(), 0);
            Console.WriteLine("Printing available dates");
            foreach (string element in ListOfDates)
            {
                Console.WriteLine("" + element);
            }
            ZigmaModel _extractedDates = new();
            _extractedDates = ModelTransfer.TransferListOfStringsToZigmaNodel(_listOfDates);
            return _extractedDates;
        }

        private List<ReportDaily> CalculateDailyReports(ZigmaModel extractedDates, ZigmaModel dataset)
        {
            ReportService serviceReport = new();
            List<ReportDaily> DailyReports = new();
            DailyReports = serviceReport.GetListOfDailyReportsBaseOnDataset(dataset.GetRawZigmaDataset(), 0);
            Console.WriteLine("Daily reports calculation:");
            foreach (var report in DailyReports)
            {
                Console.WriteLine(" " + report.Date + " " + " " + report.PlannedOutput + " " + " " + report.RealOutput + " " + " " + report.PlanedPercentage);
            }
            return DailyReports;
        }

        private ZigmaModel TransferDailyReportsDataToZigmaModel(List<ReportDaily> dailyReports)
        {
            ZigmaModel _zModel = new();
            _zModel = ModelTransfer.TransferReportDailyListToZigmaModel(dailyReports);
            return _zModel;
        }


        // Save daily reports to csv file
        ZigmaModel zModel = ModelTransfer.TransferReportDailyListToZigmaModel(DailyReports);
        ExtractionTool saver = new();
        saver.SaveToCsvFile(zModel.GetZigmaDataset(), "C:\\0 VirtualServer\\ETL\\out\\", "DailyReports.csv");



    }
}