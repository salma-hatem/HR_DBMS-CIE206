using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Specialized;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.PersonalMang
{
    public class HomeModel : PageModel
    {
        private readonly DBManager dBManager;

        [BindProperty]
        public string message1 { get; set; }
    
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        // Variables //

        // Widget #1 Attendance time //
        [BindProperty(SupportsGet = true)]
        public DataTable AttendanceToday { get; set; }

        // Requests Widget #2 //
        [BindProperty(SupportsGet = true)]
        public DataTable Requests { get; set; }


        // Week Attendance Widget #3 //
        [BindProperty(SupportsGet = true)]
        public DataTable ThisWeekAttendance { get; set; }

        // Employee Report Chart # 1 right //
        [BindProperty(SupportsGet = true)]
        public int ProjectCount { get; set; }
        [BindProperty(SupportsGet = true)]
        public int RequestsCount { get; set; }
        [BindProperty(SupportsGet = true)]
        public int BonusCount { get; set; }
        [BindProperty(SupportsGet = true)]
        public int TrainingsCount { get; set; }
        [BindProperty(SupportsGet = true)]

        public int AttendanceCount { get; set; }
        [BindProperty(SupportsGet = true)]

        public int Salaries { get; set; }

        // Genral Data For Graph Widget #2 to the right //
        [BindProperty(SupportsGet = true)]

        public int TotalProjects { get; set; }
        [BindProperty(SupportsGet = true)]
        public int TotalTrainings { get; set; }
        [BindProperty(SupportsGet = true)]
        public int TotalAttendance { get; set; }

        [BindProperty(SupportsGet = true)]
        public int TotalRequests { get; set; }

        // Employees Absents Today Chart #2 //
        [BindProperty(SupportsGet = true)]
        public int EAttendanceToday { set;get; }
        [BindProperty(SupportsGet = true)]
        public int ELeaveBreak { set; get; }

        [BindProperty(SupportsGet = true)]
        public string ClockIn { set; get; }

        [BindProperty(SupportsGet = true)]
        public DataTable WorkingToday { set; get; }


        // Week Days //
        [BindProperty(SupportsGet =true)]
        public int Sunday { set; get; }
        [BindProperty(SupportsGet = true)]
        public int Monday { set; get; }
        [BindProperty(SupportsGet = true)]
        public int Tuesday { set; get; }
        [BindProperty(SupportsGet = true)]
        public int Wednesday { set; get; }
        [BindProperty(SupportsGet = true)]
        public int Thursday { set; get; }
        [BindProperty(SupportsGet = true)]
        public int Friday { set; get; }
        [BindProperty(SupportsGet = true)]
        public int Saturday { set; get; }
        public HomeModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
            
        }
        public void OnGet()
        {
            ID = dBManager.getCurrentUser();
            int id = ID;
            AttendanceToday = dBManager.CustomQuery($"SELECT Clock_in FROM Attendance, Personal AS P WHERE Atendance_Date = CAST( GETDATE() AS Date ) AND P.id ={id}");

            ClockIn = dBManager.CustomScalarQuery($"SELECT Atendance_Date FROM Attendance WHERE Atendance_Date= Convert(date, getdate()) AND Person_ID={id};");
            
            Requests = dBManager.CustomQuery($"SELECT R.ID,P.FName,R_type,R_Status,R.R_Description FROM Requests AS R,Employee AS E, Personal AS P WHERE E.PMID={id} AND R.EmployeeID=E.EmployeeID AND P.id=E.EmployeeID ;");

            ThisWeekAttendance = dBManager.CustomQuery($"SELECT A.* FROM Attendance AS A, Personal AS P WHERE A.Person_ID =P.id AND P.id = {id} AND A.Atendance_Date>(SELECT  DATEADD(DAY, 2 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE)) [Week_Start_Date])");

            ProjectCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT([ID]) FROM Project WHERE PMID = {id};"));

            RequestsCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(R.[ID]) FROM [dbo].[Requests] AS R,[dbo].[Employee] AS E WHERE E.EmployeeID = R.EmployeeID AND E.PMID = {id};"));

            BonusCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(B.ID) FROM [dbo].[PenaltiesBonuses] AS B WHERE B.Given_by = {id};"));

            TrainingsCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(TrainingID) FROM Attend_Training, Employee WHERE EmployeeID= E_ID AND PMID ={id};"));

            AttendanceCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(A.ID) FROM [dbo].[Attendance] AS A, [dbo].[Employee] AS E WHERE A.Person_ID=E.EmployeeID AND PMID = {id};"));

            // Need to Calculate Bonuses And Penalties here//
            Salaries = 30*Int32.Parse(dBManager.CustomScalarQuery($"SELECT SUM([Salary]) FROM [dbo].[Personal] AS P,[dbo].[Employee] AS E WHERE P.id= E.EmployeeID AND E.PMID ={id};"));


            // Genral Data //
            TotalProjects = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(ID) FROM Project;"));
            TotalTrainings = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(ID) FROM Training;"));
            TotalAttendance = 30*Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(EmployeeID) FROM Employee"));
            TotalRequests = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(ID) FROM Requests"));

            // Working today
            WorkingToday = dBManager.CustomQuery($"SELECT Person_Status,COUNT(Person_Status) FROM Personal, Employee WHERE id=EmployeeID AND PMID ={id} GROUP BY Person_Status ;");
            // Week Days attendance //

            Sunday = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(A.ID) FROM Attendance AS A, Employee E WHERE E.EmployeeID = A.Person_ID AND PMID={id} AND A.Atendance_Date=CAST((SELECT DATEADD(dd,1-DATEPART(dw,GETDATE()),GETDATE())) AS DATE)"));
            Monday = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(A.ID) FROM Attendance AS A, Employee E WHERE E.EmployeeID = A.Person_ID AND PMID={id} AND A.Atendance_Date=CAST((SELECT DATEADD(dd,1-DATEPART(dw,GETDATE()),GETDATE())+1) AS DATE)"));
            Tuesday = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(A.ID) FROM Attendance AS A, Employee E WHERE E.EmployeeID = A.Person_ID AND PMID={id} AND A.Atendance_Date=CAST((SELECT DATEADD(dd,1-DATEPART(dw,GETDATE()),GETDATE())+2) AS DATE)"));
            Wednesday = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(A.ID) FROM Attendance AS A, Employee E WHERE E.EmployeeID = A.Person_ID AND PMID={id} AND A.Atendance_Date=CAST((SELECT DATEADD(dd,1-DATEPART(dw,GETDATE()),GETDATE())+3) AS DATE)"));
            Thursday = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(A.ID) FROM Attendance AS A, Employee E WHERE E.EmployeeID = A.Person_ID AND PMID={id} AND A.Atendance_Date=CAST((SELECT DATEADD(dd,1-DATEPART(dw,GETDATE()),GETDATE())+4) AS DATE)"));
            Friday = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(A.ID) FROM Attendance AS A, Employee E WHERE E.EmployeeID = A.Person_ID AND PMID={id} AND A.Atendance_Date=CAST((SELECT DATEADD(dd,1-DATEPART(dw,GETDATE()),GETDATE())+5) AS DATE)"));
            Saturday = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(A.ID) FROM Attendance AS A, Employee E WHERE E.EmployeeID = A.Person_ID AND PMID={id} AND A.Atendance_Date=CAST((SELECT DATEADD(dd,1-DATEPART(dw,GETDATE()),GETDATE())+5) AS DATE)"));
            

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Employee/Request", new { ID = this.ID });
        }

        public async Task<IActionResult> OnPostTakeAsync()
        {
            Console.WriteLine("Hi");
            int id = dBManager.getCurrentUser();
            int maxID = Int32.Parse(dBManager.CustomScalarQuery($"SELECT MAX(ID) From Attendance;")) + 1;
            string takenAttendance =dBManager.CustomScalarQuery($"SELECT * FROM Attendance WHERE Atendance_Date= Convert(date, getdate()) AND Person_ID={id};");
            if (string.IsNullOrEmpty(takenAttendance))
            {
                
                dBManager.CustomNonQuery($"INSERT INTO Attendance VALUES ({maxID},GETDATE(),null,null,{id} ) ;");
            }
            else
            {
                message1 = "Attendance is Taken Already";
                
            }
            
            return Page();

        }
    }
}
