using System;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;

namespace FetchLeagueStats
{
    public static class StatsToExcel
    {
        public const int NAME_COL = 1;
        public const int IRON_COL = 2;
        public const int IRON50_COL = 3;
        public const int BRONZE_COL = 4;
        public const int BRONZE50_COL = 5;
        public const int SILVER_COL = 6;
        public const int SILVER50_COL = 7;
        public const int Gold_COL = 8;
        public const int Gold50_COL = 9;
        public const int Platinum_COL = 10;
        public const int Platinum50_COL = 11;
        public const int DIAMOND_COL = 12;
        public const int DIAMOND50_COL = 13;
        public const int MASTERS_COL = 14;
        public const int MASTERS50_COL = 15;

        public static void Export()
        {
            // Creating an instance
            // of ExcelPackage
            using (ExcelPackage excel = new ExcelPackage())
            {
                // name of the sheet
                var dataWorkSheet = excel.Workbook.Worksheets.Add("Champ Data");
                var recordCount = FillData(dataWorkSheet);

                var chartWorkSheet = excel.Workbook.Worksheets.Add("Chart Data");
                FillChartData(chartWorkSheet, dataWorkSheet, recordCount);

                // file name with .xlsx extension 
                string p_strPath = Path.Combine(Program.SaveDirectory, $"League Champ Data {DateTime.Now.ToString("yyyyMMdd")}.xlsx");

                // Create excel file on physical disk 
                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                // Write content to excel file 
                File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
                //Close Excel package
                excel.Dispose();
            }
        }


        private static int FillData(ExcelWorksheet workSheet)
        {
            // setting the properties
            // of the work sheet 
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            workSheet.Columns.Style.Numberformat.Format = "0.00%";
            workSheet.Column(1).Style.Numberformat.Format = "General";
            workSheet.Row(1).Style.Numberformat.Format = "General";

            // Setting the properties
            // of the first row
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            // Header of the Excel sheet
            workSheet.Cells[1, NAME_COL].Value = "Champ Name";
            workSheet.Cells[1, IRON_COL].Value = "Iron";
            workSheet.Cells[1, IRON50_COL].Value = "Iron After 50";
            workSheet.Cells[1, BRONZE_COL].Value = "Bronze";
            workSheet.Cells[1, BRONZE50_COL].Value = "Bronze After 50";
            workSheet.Cells[1, SILVER_COL].Value = "Silver";
            workSheet.Cells[1, SILVER50_COL].Value = "Silver After 50";
            workSheet.Cells[1, Gold_COL].Value = "Gold";
            workSheet.Cells[1, Gold50_COL].Value = "Gold After 50";
            workSheet.Cells[1, Platinum_COL].Value = "Platinum";
            workSheet.Cells[1, Platinum50_COL].Value = "Platinum After 50";
            workSheet.Cells[1, DIAMOND_COL].Value = "Diamond";
            workSheet.Cells[1, DIAMOND50_COL].Value = "Diamond After 50";
            workSheet.Cells[1, MASTERS_COL].Value = "Masters";
            workSheet.Cells[1, MASTERS50_COL].Value = "Masters After 50";

            // Inserting the article data into excel
            // sheet by using the for each loop
            // As we have values to the first row 
            // we will start with second row
            int recordIndex = 2;

            foreach (var champion in Program.Champions)
            {
                Console.WriteLine($"Exporting data for {champion.Name}");
                workSheet.Cells[recordIndex, NAME_COL].Value = champion.Name;
                workSheet.Cells[recordIndex, IRON_COL].Value = champion.WinRates.GetWinRate(Elo.Iron, Site.LOG);
                workSheet.Cells[recordIndex, IRON50_COL].Value = champion.WinRates.GetWinRate(Elo.Iron, Site.Log50);
                workSheet.Cells[recordIndex, BRONZE_COL].Value = champion.WinRates.GetWinRate(Elo.Bronze, Site.LOG);
                workSheet.Cells[recordIndex, BRONZE50_COL].Value = champion.WinRates.GetWinRate(Elo.Bronze, Site.Log50);
                workSheet.Cells[recordIndex, SILVER_COL].Value = champion.WinRates.GetWinRate(Elo.Silver, Site.LOG);
                workSheet.Cells[recordIndex, SILVER50_COL].Value = champion.WinRates.GetWinRate(Elo.Silver, Site.Log50);
                workSheet.Cells[recordIndex, Gold_COL].Value = champion.WinRates.GetWinRate(Elo.Gold, Site.LOG);
                workSheet.Cells[recordIndex, Gold50_COL].Value = champion.WinRates.GetWinRate(Elo.Gold, Site.Log50);
                workSheet.Cells[recordIndex, Platinum_COL].Value = champion.WinRates.GetWinRate(Elo.Platinum, Site.LOG);
                workSheet.Cells[recordIndex, Platinum50_COL].Value = champion.WinRates.GetWinRate(Elo.Platinum, Site.Log50);
                workSheet.Cells[recordIndex, DIAMOND_COL].Value = champion.WinRates.GetWinRate(Elo.Diamond, Site.LOG);
                workSheet.Cells[recordIndex, DIAMOND50_COL].Value = champion.WinRates.GetWinRate(Elo.Diamond, Site.Log50);
                workSheet.Cells[recordIndex, MASTERS_COL].Value = champion.WinRates.GetWinRate(Elo.Master, Site.LOG);
                workSheet.Cells[recordIndex, MASTERS50_COL].Value = champion.WinRates.GetWinRate(Elo.Master, Site.Log50);
                recordIndex++;
            }

            // By default, the column width is not 
            // set to auto fit for the content
            // of the range, so we are using
            // AutoFit() method here. 
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();
            workSheet.Column(7).AutoFit();
            workSheet.Column(8).AutoFit();
            workSheet.Column(9).AutoFit();
            workSheet.Column(10).AutoFit();
            workSheet.Column(11).AutoFit();
            workSheet.Column(12).AutoFit();
            workSheet.Column(13).AutoFit();
            workSheet.Column(14).AutoFit();
            workSheet.Column(15).AutoFit();

            using (ExcelRange autoFilterCells = workSheet.Cells[1, 1, NAME_COL, MASTERS50_COL])
            {
                autoFilterCells.AutoFilter = true;
            }

            Console.WriteLine("Finished exporting champ data.");

            return recordIndex;
        }

        private static void FillChartData(ExcelWorksheet chartWorkSheet, ExcelWorksheet dataWorkSheet, int recordCount)
        {
            Console.WriteLine("Creating chart...");

            //create a new piechart of type Line
            ExcelLineChart lineChart = chartWorkSheet.Drawings.AddChart("lineChart", eChartType.Line) as ExcelLineChart;

            //set the title
            lineChart.Title.Text = "All Champ Data";

            var rangeHeader = dataWorkSheet.Cells[1, IRON_COL, NAME_COL, MASTERS50_COL];

            for (int rowIndex = 2; rowIndex < recordCount; rowIndex++)
            {
                Console.WriteLine($"Setting up chart for row {rowIndex}");
                var champName = dataWorkSheet.Cells[rowIndex, NAME_COL].Value.ToString();
                var champRange = dataWorkSheet.Cells[rowIndex, IRON_COL, rowIndex, MASTERS50_COL];
                lineChart.Series.Add(champRange, rangeHeader);
                lineChart.Series[rowIndex - 2].Header = champName;
            }

            lineChart.Legend.Position = eLegendPosition.Right;
            lineChart.SetSize(1000, 500);
            lineChart.SetPosition(1, 0, 1, 0);

            //create a new line chart of type Line
            ExcelLineChart filteredLineChart = chartWorkSheet.Drawings.AddChart("filteredLineChart", eChartType.Line) as ExcelLineChart;

            //set the title
            filteredLineChart.Title.Text = $"{Program.StartElo.EnumToString()} & {Program.StopElo.EnumToString()} + 50 Champ Data";

            var filteredRangeHeader = dataWorkSheet.Cells[1, (int)Program.StartElo * 2, NAME_COL, (int)Program.StopElo * 2 + 1];

            for (int rowIndex = 2; rowIndex < recordCount; rowIndex++)
            {
                Console.WriteLine($"Setting up chart for row {rowIndex}");
                var champName = dataWorkSheet.Cells[rowIndex, NAME_COL].Value.ToString();
                var champRange = dataWorkSheet.Cells[rowIndex, (int)Program.StartElo * 2, rowIndex, (int)Program.StopElo * 2 + 1];
                filteredLineChart.Series.Add(champRange, filteredRangeHeader);
                filteredLineChart.Series[rowIndex - 2].Header = champName;
            }

            filteredLineChart.Legend.Position = eLegendPosition.Right;
            filteredLineChart.SetSize(1000, 500);
            filteredLineChart.SetPosition(1, 0, 18, 0);

            Console.WriteLine("Finished creating chart...");
        }
    }
}
