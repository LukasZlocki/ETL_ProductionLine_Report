using ETL_ProductionLine_Report.Models;
using Zigma.Models;

namespace ETL_ProductionLine_Report.Services {
    public class ReportService : IReportService
    {

        // [10.11.2023]
        /// <summary>
        /// Calculate daily reports for given dataset and list of dates for which reports will be calculated.
        /// </summary>
        /// <param name="dataset">ZigmaModel dataset</param>
        /// <param name="dateSet">ZigmaModel dates list</param>
        /// <returns>ZigmaModel daily reports</returns>
        public ZigmaModel GetDailyReportsForGivenListOfDates(ZigmaModel dataset, ZigmaModel dateSet)
        {
            ZigmaModel _zModel = new();
            List<ReportDaily> DailyReportsList = new();
            List<string> datesConverted = new();
            datesConverted = ConvertZigmaModelDatasetToListOfStrings(dateSet);
            DailyReportsList = GetListOfDailyReports(dataset.GetRawZigmaDataset(), datesConverted, 0);
            return _zModel;
        }

        // [10.11.2023]
        /// <summary>
        /// Calculate daily report for given day.
        /// </summary>
        /// <param name="dataset">ZigmaModel dataset</param>
        /// <param name="date">Day to calculate daily report</param>
        /// <returns></returns>
        public ZigmaModel GetDailyReportForGivenDay(ZigmaModel dataset, string date)
        {
            ZigmaModel _zModel = new();
            ZigmaModel _zDate = new();
            _zDate = ConvertStringToZigmaModel(date);
            _zModel = GetDailyReportsForGivenListOfDates(dataset, _zDate);
            return _zModel;
        }

        //[10.11.2023]
        private ZigmaModel ConvertStringToZigmaModel(string toConvert)
        {
            ZigmaModel _zModel = new();
            List<string[]> _zmod = new();
            _zmod.Add(new string[] {toConvert});
            _zModel.CreateZigmaDatasetFromRawDataset(_zmod);
            return _zModel;
        }
        private List<string> ConvertZigmaModelDatasetToListOfStrings(ZigmaModel zModelToConvert)
        {
            List<string> datasetList = new();
            foreach(var item in zModelToConvert.GetRawZigmaDataset())
            {
                string _str = item[0];
                datasetList.Add(_str);
            }
            return datasetList;
        }

        // [06.10.2023] - InProgress
        public List<ReportDaily> GetListOfDailyReportsBaseOnDataset(List<string[]> dataset, int columnWithDate)
        {
            List<string> listOfDates = GetListOfDatesFromDataset(dataset, columnWithDate);
            List<ReportDaily> dailyReportsList = GetListOfDailyReports(dataset, listOfDates, columnWithDate);
            return dailyReportsList;
        }

        //[09.10.2023]  - Done
        public ReportDaily GetReportForGivenDay(List<string[]> dataset, string day, int columnNumberWithDate)
        {
            List<string[]> _dayData;
            _dayData = ExtractDatasetForGivenDay(dataset, day, columnNumberWithDate);
            ReportDaily _dailyReportBuild = new();
            foreach(string[] element in _dayData) {
                int _plannedOutput = Convert.ToInt32(_dailyReportBuild.PlannedOutput) + Convert.ToInt32(element[2]);
                _dailyReportBuild.PlannedOutput =  Convert.ToString(_plannedOutput);
                int _realOutput = Convert.ToInt32(_dailyReportBuild.RealOutput) + Convert.ToInt32(element[3]);
                _dailyReportBuild.RealOutput = Convert.ToString(_realOutput);
            }
            // Calculation of planned production to real production
            double _plannedPercentage = Convert.ToDouble(_dailyReportBuild.RealOutput) / Convert.ToDouble(_dailyReportBuild.PlannedOutput);
            _plannedPercentage = Math.Round(_plannedPercentage, 2);
            _dailyReportBuild.PlanedPercentage = Convert.ToString(_plannedPercentage);
            // Add user date to daily report
            _dailyReportBuild.Date = day;

            return _dailyReportBuild;
        }

        // [09.10.2023]
        private List<string[]> ExtractDatasetForGivenDay(List<string[]> dataset, string day, int columnNumberWithDate) {
            List<string[]> _dayData = new();
            if (CheckIsDigit(day) == false) // this is not a date
            {
                return _dayData; // return ampty data
            }
            foreach(string[] row in dataset) {
                if (row[columnNumberWithDate] == day) {
                    _dayData.Add(row);
                }
                else {
                    continue;
                }
            }
            return _dayData;
        }

        private List<ReportDaily> GetListOfDailyReports(List<string[]> dataset, List<string> dates, int columnNumberWithDate){
            List<ReportDaily> _listOfDailyReports = new();
            foreach (string date in dates) {
                ReportDaily _newReport = GetReportForGivenDay(dataset, date, columnNumberWithDate);
                _listOfDailyReports.Add(_newReport);
            }
            return _listOfDailyReports;
        }

        public List<string> GetListOfDatesFromDataset(List<string[]> dataset, int columnNumberWithDate)
        {
            List<string> _listOfDates = new List<string>();
            foreach (string[] row in dataset){
                string _nextDate;
                _nextDate = row[columnNumberWithDate];
                if(CheckIsDigit(_nextDate) == false){ // checking if it is date or column name
                    continue;
                }
                if(_listOfDates.Contains(_nextDate) == true) {
                    continue; // Date is in list of dates.
                }
                else{
                    _listOfDates.Add(_nextDate); // Adding new date to list.
                }
            }
            return _listOfDates;
        }

        // [09.10.2023] check if string is digit
        private bool CheckIsDigit(string sample){
            bool _isDigit = char.IsDigit(sample[0]);
            return _isDigit;
        }
    }
}