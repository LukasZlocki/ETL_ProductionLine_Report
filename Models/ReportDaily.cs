namespace ETL_ProductionLine_Report.Models {
    public class ReportDaily {
        public string Date { get; set; }
        public string PlannedOutput { get; set; }
        public string RealOutput { get; set; }
        public string PlanedPercentage { get; set; }
    }
}