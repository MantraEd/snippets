<Query Kind="Program" />

void Main()
{
DateTime endDate;
DateTime startDate;

Console.WriteLine($"{DateTime.Now.Month:00}{DateTime.Now.Day:00}{DateTime.Now.Year}");

GetReportDates(0, out startDate, out endDate);
Console.WriteLine("Rolling 12 Months " + startDate.ToString() + " " + endDate.ToString());

GetReportDates(1, out startDate, out endDate);
Console.WriteLine("Year to Date (as of most recent completed month)" + startDate.ToString() + " " + endDate.ToString());

GetReportDates(2, out startDate, out endDate);
Console.WriteLine("Month to Date (as of yesterday) " + startDate.ToString() + " " + endDate.ToString());

GetReportDates(3, out startDate, out endDate);
Console.WriteLine("Quarter to Date (as of yesterday) " + startDate.ToString() + " " + endDate.ToString());

GetReportDates(4, out startDate, out endDate);
Console.WriteLine("Previous Year " + startDate.ToString() + " " + endDate.ToString());

GetReportDates(5, out startDate, out endDate);
Console.WriteLine("Previous Month " + startDate.ToString() + " " + endDate.ToString());

GetReportDates(6, out startDate, out endDate);
Console.WriteLine("Previous Quarter " + startDate.ToString() + " " + endDate.ToString());
 
GetReportDates(7, out startDate, out endDate);
Console.WriteLine("Rolling 6 Months (as of most recent completed month)" + startDate.ToString() + " " + endDate.ToString());

GetReportDates(8, out startDate, out endDate);
Console.WriteLine("Previous Week Sunday to Monday" + startDate.ToString() + " " + endDate.ToString());
//change 1
//change 2
//change 3
//change 4
//change 6
}

        private static void GetReportDates(int selectedTimeFrameId, out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            endDate =  new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            switch (selectedTimeFrameId)
            {
                case 0:
                    //Rolling 12 Months					
					if (DateTime.Now.Month > 1)
                    {
                        endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1));
                    }
                    else
                    {
                        endDate = new DateTime(DateTime.Now.Year - 1, 12,DateTime.DaysInMonth(DateTime.Now.Year - 1, 12));
                    }
                    startDate = endDate.AddYears(-1).AddDays(1);					
                    break;
                case 1:
                    //Year to Date (as of most recent completed month) previously "Current Year"
                    startDate = new DateTime(DateTime.Now.Year, 1, 1);
                    				
					if (DateTime.Now.Month > 1)
                    {
                        endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1));
                    }
                    else
                    {
                        endDate = new DateTime(DateTime.Now.Year - 1, 12,DateTime.DaysInMonth(DateTime.Now.Year - 1, 12));
                    }
                    break;
                case 2:
                    //Month to Date (as of yesterday) previously "Current Month"
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    endDate = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, DateTime.DaysInMonth(DateTime.Now.AddMonths(1).Year,DateTime.Now.AddMonths(1).Month ));
                    break;
                case 3:
                    //Quarter to Date (as of yesterday) previously "Current Quarter"
                    int quarterNumber = (DateTime.Now.Month - 1) / 3 + 1;
                    startDate = new DateTime(DateTime.Now.Year, (quarterNumber - 1) * 3 + 1, 1);
                    endDate = startDate.AddMonths(3).AddDays(-1);
                    break;
                case 4:
                    //Previous Year
                    startDate = new DateTime(DateTime.Now.Year - 1, 1, 1);
                    endDate = new DateTime(startDate.Year + 1, 1, 1).AddDays(-1);
                    break;
                case 5:
                    //Previous Month
                    if (DateTime.Now.Month > 1)
                    {
                        startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                    }
                    else
                    {
                        startDate = new DateTime(DateTime.Now.Year - 1, 12, 1);
                    }

                    endDate = startDate.AddMonths(1).AddDays(-1);
                    break;
                case 6:
                    //Previous Quarter
                    switch (DateTime.Now.Month)
                    {
                        case 1:
                        case 2:
                        case 3:
                            startDate = new DateTime(DateTime.Now.Year - 1, 10, 1);
                            break;
                        case 4:
                        case 5:
                        case 6:
                            startDate = new DateTime(DateTime.Now.Year, 1, 1);
                            break;
                        case 7:
                        case 8:
                        case 9:
                            startDate = new DateTime(DateTime.Now.Year, 4, 1);
                            break;
                        case 10:
                        case 11:
                        case 12:
                            startDate = new DateTime(DateTime.Now.Year, 7, 1);
                            break;
                    }

                    endDate = startDate.AddMonths(3).AddDays(-1);
                    break;
                case 7:
                    //Rolling 6 Months
					if (DateTime.Now.Month > 1)
                    {
                        endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1));
                    }
                    else
                    {
                        endDate = new DateTime(DateTime.Now.Year - 1, 12,DateTime.DaysInMonth(DateTime.Now.Year - 1, 12));
                    }
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-6);
                    break;
                case 8:
                    //Previous Week		
					startDate =  startDate.AddDays(-7);
					while(startDate.DayOfWeek != DayOfWeek.Monday) startDate = startDate.AddDays(-1);
					while(endDate.DayOfWeek != DayOfWeek.Sunday) endDate = endDate.AddDays(-1);
                    break;
            }
        }