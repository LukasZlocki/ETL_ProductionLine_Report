using ETL_ProductionLine_Report.Models;

namespace ETL_ProductionLine_Report.Services {
    interface IReportService {
        // Daily Report
        public List<ReportDaily> GetListOfDailyReportsBaseOnDataset(List<string[]> dataset, int columnWithDate); 
        public ReportDaily GetReportForGivenDay(List<string[]> dataset, string Date, int columnNumberWithDate);
    }
}