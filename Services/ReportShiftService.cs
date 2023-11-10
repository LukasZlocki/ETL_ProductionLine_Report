using ETL_ProductionLine_Report.Services;
using Zigma.Models;

namespace ETL_ProductionLine_Report.Models {
    public class ReportShiftService : ReportShift, IReportShiftService
    {
        // ToDo : Code service here
        //[20.10.2023]
        public List<ReportShift> GetListOfShiftReportsBaseOnDataset(List<string[]> dataset, int columnWithDate, ZigmaModel _datesModel) 
        {
            List<ReportShift> _reportShift = new();
            foreach( var date in _datesModel.GetRawZigmaDataset()){
                string _date = string.Join("", date);
                _reportShift.Add(GetShiftReportForGivenDayAndShift(dataset, _date, columnWithDate, 1));
            }
            return _reportShift;
        }

        // InProgress
        public ReportShift GetShiftReportForGivenDayAndShift(List<string[]> dataset, string Date, int columnNumberWithDate, int shiftNb)
        {
            ReportShift shiftReport = new ReportShift();
            switch (shiftNb)
            {
                case 1:
                    shiftReport = CalculateShiftReportForGivenShiftTimeFrameSetAndDate(dataset, Date, columnNumberWithDate, _shiftI, shiftNb);
                    break;
                case 2:
                    shiftReport = CalculateShiftReportForGivenShiftTimeFrameSetAndDate(dataset, Date, columnNumberWithDate, _shiftI, shiftNb);
                    break;
                case 3:
                    shiftReport = CalculateShiftReportForGivenShiftTimeFrameSetAndDate(dataset, Date, columnNumberWithDate, _shiftI, shiftNb);
                    break;                    
            }
            return shiftReport;
        }

        // Calculate shift report base on given day and shift number.
        private ReportShift CalculateShiftReportForGivenShiftTimeFrameSetAndDate(List<string[]> dataset, string Date, int columnNumberWithDate, string[] shiftTmeFrameSet, int shiftNumber) {
            ReportShift _shiftReport = new ReportShift();
            int _plannedOutput = 0;
            int _realOutput = 0;
            double _percentageOfRealToPlanned = 0.00;

            // ToDO: Code logic of extraction shift report here.
            foreach (var row in dataset) {
                if(row[columnNumberWithDate] == Date && shiftTmeFrameSet.Contains(row[1])) {
                    _plannedOutput = _plannedOutput + Convert.ToInt16(row[2]);
                    _realOutput = _realOutput + Convert.ToInt16(row[3]);
                }
            }
            _percentageOfRealToPlanned = Math.Round((Convert.ToDouble(_realOutput) / Convert.ToDouble(_plannedOutput)), 2);

            _shiftReport.Date = Date;
            _shiftReport.Shift = Convert.ToString(shiftNumber);
            _shiftReport.PlannedOutput = Convert.ToString(_plannedOutput);
            _shiftReport.RealOutput = Convert.ToString(_realOutput);
            _shiftReport.PlanedPercentage = Convert.ToString(_percentageOfRealToPlanned);

            return _shiftReport;
        }

    }
}