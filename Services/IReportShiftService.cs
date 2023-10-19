using ETL_ProductionLine_Report.Models;

namespace ETL_ProductionLine_Report.Services {
    interface IReportShiftService {
        // Daily Report
        public List<ReportShift> GetListOfShiftReportsBaseOnDataset(List<string[]> dataset, int columnWithDate); 
        public ReportShift GetShiftReportForGivenDayAndShift(List<string[]> dataset, string Date, int columnNumberWithDate, int shiftNb);
    }
}