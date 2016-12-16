<Query Kind="VBProgram" />

Sub Main
Dim  endDate As DateTime
Dim  startDate As DateTime

Console.WriteLine($"{DateTime.Now.Month:00}{DateTime.Now.Day:00}{DateTime.Now.Year}")

GetReportDates(0, startDate, endDate)
Console.WriteLine("Rolling 12 Months " + startDate.ToString() + " " + endDate.ToString())

GetReportDates(1, startDate, endDate)
Console.WriteLine("Year to Date (as of most recent completed month)" + startDate.ToString() + " " + endDate.ToString())

GetReportDates(2, startDate, endDate)
Console.WriteLine("Month to Date (as of yesterday) " + startDate.ToString() + " " + endDate.ToString())

GetReportDates(3,  startDate,  endDate)
Console.WriteLine("Quarter to Date (as of yesterday) " + startDate.ToString() + " " + endDate.ToString())

GetReportDates(4,  startDate,  endDate)
Console.WriteLine("Previous Year " + startDate.ToString() + " " + endDate.ToString())

GetReportDates(5,  startDate,  endDate)
Console.WriteLine("Previous Month " + startDate.ToString() + " " + endDate.ToString())

GetReportDates(6,  startDate,  endDate)
Console.WriteLine("Previous Quarter " + startDate.ToString() + " " + endDate.ToString())
 
GetReportDates(7,  startDate,  endDate)
Console.WriteLine("Rolling 6 Months (as of most recent completed month)" + startDate.ToString() + " " + endDate.ToString())

GetReportDates(8,  startDate,  endDate)
Console.WriteLine("Previous Week Sunday to Monday" + startDate.ToString() + " " + endDate.ToString())

End Sub

    Public Shared Sub GetReportDates(ByVal selectedTimeFrameId As Integer, ByRef startDate As DateTime, ByRef endDate As DateTime)
        startDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        endDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        Select Case (selectedTimeFrameId)
            Case 0
                'Rolling 12 Months                    
                If (DateTime.Now.Month > 1) Then
                    endDate = New DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), DateTime.DaysInMonth(DateTime.Now.Year, (DateTime.Now.Month - 1)))
                Else
                    endDate = New DateTime((DateTime.Now.Year - 1), 12, DateTime.DaysInMonth((DateTime.Now.Year - 1), 12))
                End If
                startDate = endDate.AddYears(-1).AddDays(1)
            Case 1
                'Year to Date (as of most recent completed month) previously "Current Year"
                startDate = New DateTime(DateTime.Now.Year, 1, 1)
                If (DateTime.Now.Month > 1) Then
                    endDate = New DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), DateTime.DaysInMonth(DateTime.Now.Year, (DateTime.Now.Month - 1)))
                Else
                    endDate = New DateTime(DateTime.Now.Year, 1, 1)
                End If
            Case 2
                'Month to Date (as of yesterday) previously "Current Month"
                startDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                endDate = New DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, DateTime.DaysInMonth(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month))
            Case 3
                'Quarter to Date (as of yesterday) previously "Current Quarter"
                Dim quarterNumber = Math.Floor((DateTime.Now.Month - 1) / 3 + 1)
                startDate = New DateTime(DateTime.Now.Year, (quarterNumber - 1) * 3 + 1, 1)
                endDate = startDate.AddMonths(3).AddDays(-1)
            Case 4
                'Previous Year
                startDate = New DateTime((DateTime.Now.Year - 1), 1, 1)
                endDate = New DateTime(startDate.Year + 1, 1, 1).AddDays(-1)
            Case 5
                'Previous Month
                If (DateTime.Now.Month > 1) Then
                    startDate = New DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 1)
                Else
                    startDate = New DateTime((DateTime.Now.Year - 1), 12, 1)
                End If
                endDate = startDate.AddMonths(1).AddDays(-1)
            Case 6
                'Previous Quarter
                Select Case (DateTime.Now.Month)
                    Case 1, 2, 3
                        startDate = New DateTime((DateTime.Now.Year - 1), 10, 1)
                    Case 4, 5, 6
                        startDate = New DateTime(DateTime.Now.Year, 1, 1)
                    Case 7, 8, 9
                        startDate = New DateTime(DateTime.Now.Year, 4, 1)
                    Case 10, 11, 12
                        startDate = New DateTime(DateTime.Now.Year, 7, 1)
                End Select
                endDate = startDate.AddMonths(3).AddDays(-1)
            Case 7
                'Rolling 6 Months
                If (DateTime.Now.Month > 1) Then
                    endDate = New DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), DateTime.DaysInMonth(DateTime.Now.Year, (DateTime.Now.Month - 1)))
                Else
                    endDate = New DateTime((DateTime.Now.Year - 1), 12, DateTime.DaysInMonth((DateTime.Now.Year - 1), 12))
                End If
                startDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-6)
            Case 8
                'Previous Week        
                startDate = startDate.AddDays(-7)
                While (startDate.DayOfWeek <> DayOfWeek.Monday)
                    startDate = startDate.AddDays(-1)
                End While
                While (endDate.DayOfWeek <> DayOfWeek.Sunday)
                    endDate = endDate.AddDays(-1)
                End While
            Case 9
                'Year to Date (as of yesterday)
                startDate = New DateTime(DateTime.Now.AddDays(-1).Year, 1, 1)
                endDate = endDate.AddDays(-1)
        End Select

    End Sub
' Define other methods and classes here
