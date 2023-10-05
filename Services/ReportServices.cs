using ETL_ProductionLine_Report.Models;

namespace ETL_ProductionLine_Report.Services {
    public class ReportService : IReportService
    {
        public List<ReportDaily> GetListOfDailyReportsBaseOnDataset(List<string[]> dataset, int columnWithDate)
        {
            List<string> listOfDates = GetListOfDatesFromDataset(dataset, columnWithDate);
            List<ReportDaily> dailyReportsList = GetListOfDailyReports(dataset, listOfDates, columnWithDate);
            return dailyReportsList;
        }

        public ReportDaily GetReportForGivenDay(List<string[]> dataset, string day, int columnNumberWithDate)
        {
            List<string[]> _dayData = new();
            _dayData = ExtractDatasetForGivenDay(dataset, day, columnNumberWithDate);

            foreach (string[] row in dataset)
            {
                if (row[columnNumberWithDate] == day)
                {
                    _dayData.Add(row);
                }
                else
                {
                    continue;
                }
            }

            ReportDaily _dailyReport = new();
            // ToDo: Code logic here
            return _dailyReport;
        }

        private List<ReportDaily> GetListOfDailyReports(List<string[]> dataset, List<string> dates, int columnNumberWithDate){
            List<ReportDaily> _listOfDailyReports = new();
            foreach (string date in dates) {
                ReportDaily _newReport = GetReportForGivenDay(dataset, date, columnNumberWithDate);
                _listOfDailyReports.Add(_newReport);
            }
            return _listOfDailyReports;
        }

        private List<string[]> ExtractDatasetForGivenDay(List<string[]> dataset, string day, int columnNumberWithDate)
        {
            List<string[]> _dayData = new();
            foreach (string[] row in dataset)
            {
                if (row[columnNumberWithDate] == day)
                {
                    _dayData.Add(row);
                }
                else
                {
                    continue;
                }
            }
            return _dayData;
        }

        private List<string> GetListOfDatesFromDataset(List<string[]> dataset, int columnNumberWithDate)
        {
            List<string> _listOfDates = new List<string>();
            foreach (string[] row in dataset){
                string _nextDate;
                _nextDate = row[columnNumberWithDate];
                if(_listOfDates.Contains(_nextDate) == true) {
                    continue; // Date is in list of dates.
                }
                else{
                    _listOfDates.Add(_nextDate); // Adding new date to list.
                }
            }
            return _listOfDates;
        }
    }
}