using Zigma.ExtractionTools;
using Zigma.Models;

// ToDo - Plan
// ToDo: Get data from raw csv
// ToDo: Transform column with date to date format yyyy/mm/dd
// ToDo: Create daily report with summary of units planned / output - daily report / weekly report - ! extend zigma to perform this activities ! 
// ToDo ZIGMA | TransformTool | Add method to create new column (add new column at the end of dataset)
// ToDo ZIGMA | TransformTool | Add method to remove column
// ToDo Zigma | TransformTool | Add method to move particular column to new possition ex: no move column nb 5 to 3) rest columns will move +1 column (ColumnMove(a, c)) 
// ToDo Zigma | TransformTool | Add method to switch columns ex: switch column 3 with column 2 (ColumnSwitch(a, b))
// ToDo Zigma | TransformTool | Add method to divide date by day / week / month and sign what to do with rest of columns (+, -, *, /)
// ToDo Zigma | TransformTool | Add method to do math operation in particular column -ex: have result in particular column (operation +, - , * , /, )

// STEP I : Extracting data from csv row file
ExtractionTool extraction = new();
ZigmaModel model = new ZigmaModel();

string filePath = "C:\\0 VirtualServer\\ETL\\";
string fileName = "raw_raports.csv";
model.CreateZigmaDataset(extraction.LoadFromCsvFile(filePath, fileName));
// Printing dataset
model.PrintZigmaDataset(5);
