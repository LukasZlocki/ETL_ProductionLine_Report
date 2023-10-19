namespace ETL_ProductionLine_Report.Models {
    public class ReportShift {
        public string Date { get; set; }
        public string Shift { get; set; }
        public string PlannedOutput { get; set; }
        public string RealOutput { get; set; }
        public string PlanedPercentage { get; set; }

        // Shifts time frames
        protected static string[] _shiftI = new string[] {"0600-0700", "0700-0800", "0800-0900", "0900-1000", "1000-1100", "1100-1200", "1200-1300", "1300-1400"};
        protected static string[] _shiftII = new string[] {"1400-1500", "1500-1600", "1600-1700", "1700-1800", "1800-1900", "1900-2000", "2000-2100", "2100-2200"};
        protected static string[] _shiftIII = new string[] {"2200-2300", "2300-0000", "0000-0100", "0100-0200", "0200-0300", "0300-0400", "0400-0500", "0500-0600"};

    }
}