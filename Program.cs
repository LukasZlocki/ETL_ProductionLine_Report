﻿using ETL_ProductionLine_Report.Models;
using ETL_ProductionLine_Report.Repo;
using ETL_ProductionLine_Report.Services;
using Zigma.ExtractionTools;
using Zigma.Models;
using Zigma.TransformationTools;

// ToDo - Plan
// ToDo: Get data from raw csv
// ToDo: Transform column with date to date format yyyy/mm/dd
// ToDo: Create daily report with summary of units planned / output - daily report / weekly report - ! extend zigma to perform this activities ! 
// ToDo ZIGMA | TransformTool | Add method to create new column (add new column at the end of dataset)
// ToDo Zigma | TransformTool | Add method to move particular column to new possition ex: no move column nb 5 to 3) rest columns will move +1 column (ColumnMove(a, c)) 
// ToDo Zigma | TransformTool | Add method to switch columns ex: switch column 3 with column 2 (ColumnSwitch(a, b))
// ToDo Zigma | TransformTool | Add method to divide date by day / week / month and sign what to do with rest of columns (+, -, *, /)
// ToDo Zigma | TransformTool | Add method to do math operation in particular column -ex: have result in particular column (operation +, - , * , /, )

string filePath = "C:\\0 VirtualServer\\ETL\\";
string fileName = "raw_raports.csv";

// STEP I : Extracting data from csv row file
PreparingData dataPreparation = new();
ZigmaModel dateDatasetWithDateSimplify = dataPreparation.model;

// *************** PreparingData part (all upper)

// STEP II : Creating daily report
ReportService serviceReport = new();
List<string> ListOfDates = new();
ListOfDates = serviceReport.GetListOfDatesFromDataset(dateDatasetWithDateSimplify.GetRawZigmaDataset(), 0);
Console.WriteLine("Printing available dates");
foreach (string element in ListOfDates)
{
    Console.WriteLine("" + element);
}
List<ReportDaily> DailyReports = new();
DailyReports = serviceReport.GetListOfDailyReportsBaseOnDataset(dateDatasetWithDateSimplify.GetRawZigmaDataset(), 0);
Console.WriteLine("Daily reports calculation:");
foreach (var report in DailyReports)
{
    Console.WriteLine(" " + report.Date + " " + " " + report.PlannedOutput + " " + " " + report.RealOutput + " " + " " + report.PlanedPercentage);
}

// Save daily reports to csv file
ZigmaModel zModel = ModelTransfer.TransferReportDailyListToZigmaModel(DailyReports);
ExtractionTool saver = new();
saver.SaveToCsvFile(zModel.GetZigmaDataset(), "C:\\0 VirtualServer\\ETL\\out\\", "DailyReports.csv");

// *********** Creating daily report (all upper)

// Creating shift report
Console.WriteLine("*** Shift Report test - first shift report extraction ***");
ZigmaModel shiftModel = new ZigmaModel();
shiftModel.CreateZigmaDataset(extraction.LoadFromCsvFile(filePath, fileName));
// Printing dataset
shiftModel.PrintZigmaDataset(7);
// removing not needed column nb 0
shiftModel = transform.ColumnRemove(shiftModel, 0);
Console.WriteLine("*** Removing  column with numeration - column nb 0 ***");
shiftModel.PrintZigmaDataset(5);
Console.WriteLine("*** Simplify date ***");
shiftModel = transform.TransformColumnToDate(shiftModel, 0);
shiftModel.PrintZigmaDataset(9);
// Calculate shift report for given day
ReportShiftService shiftService = new ReportShiftService();
ReportShift shiftReport = new ReportShift();
shiftReport = shiftService.GetShiftReportForGivenDayAndShift(shiftModel.GetRawZigmaDataset(), "2022-02-21", 0, 1);
Console.WriteLine("Shift Report example and test:");
Console.WriteLine(" " + shiftReport.Date + " " + " " + shiftReport.PlannedOutput + " " + " " + shiftReport.RealOutput + " " + " " + shiftReport.PlanedPercentage + " " + shiftReport.Shift);

// [20.10.2023]
// Generate list of shift reports for all available days and shifts
Console.WriteLine("*** Generating shif reports from all available days and all available shifts ***");
ZigmaModel csvBaseModel = new ZigmaModel();
csvBaseModel.CreateZigmaDataset(extraction.LoadFromCsvFile(filePath, fileName));
// Printing dataset
Console.WriteLine("*** Printing csv data - printing 3 rows ***");
csvBaseModel.PrintZigmaDataset(3);
// removing not needed column nb 0
Console.WriteLine("*** Removing  not needed column nb 0 ***");
csvBaseModel = transform.ColumnRemove(csvBaseModel, 0);
csvBaseModel.PrintZigmaDataset(3);
Console.WriteLine("*** Simplify date ***");
csvBaseModel = transform.TransformColumnToDate(csvBaseModel, 0);
csvBaseModel.PrintZigmaDataset(9);
// add extracting column with date and removing column description in order to achive pure list of dates | Working on Zigma library to have it avialble in lib
ZigmaModel datesOnly;
datesOnly = transform.ColumnExtract(csvBaseModel, 0);
Console.WriteLine("*** Printing extracted dates ***");
datesOnly.PrintZigmaDataset(3); // printing dataset  // << ! AA !
// extracting shift reports basis on collected dates.
ReportShiftService _shiftService = new ReportShiftService();
List<ReportShift> shiftRep = _shiftService.GetListOfShiftReportsBaseOnDataset(csvBaseModel.GetRawZigmaDataset(), 0, datesOnly);

ZigmaModel shiftZigmaReportModel = new();
List<string[]> _reportList = new();
foreach (var report in shiftRep)
{
    string[] _shiftReport = new string[] { report.Date, report.PlannedOutput, report.RealOutput, report.PlanedPercentage, report.Shift };
    _reportList.Add(_shiftReport);
}
shiftZigmaReportModel.CreateZigmaDatasetFromRawDataset(_reportList);
Console.WriteLine("*** Printing final reports for 1st shift, 10 samples ***");
shiftZigmaReportModel.PrintZigmaDataset(50);
// see results - need to remove recurence dates from zigma model : ToDo : add removing recurence in column in Zigma transformation tool
// after researching the problem i can see that dates list is recurrence one with the same dates - this need to bi fixed -- see mark ! AA ! for error
// [03112023]
// OK task ned to be done to implement method of removing recurrence data from dataset example RemoveRecurrenceData(dataset, columnWithReccurence)
// [06112023]
Console.WriteLine("*** Removing reccurence and printing 20 results from new model ***");
ZigmaModel reccureneceRemoved = transform.RemoveRecurrenceData(shiftZigmaReportModel, 0);
reccureneceRemoved.PrintZigmaDataset(20);

// [06112023]
// Create shift reports for each shift for each day (ex day xxx , report shift 1,2,3 and then next day) and put it into file
