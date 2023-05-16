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
    
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        // Variables //

        // Widget #1 Attendance time //
        public DataTable AttendanceToday { get; set; }

        // Requests Widget #2 //
        public DataTable Requests { get; set; }

        // Week Attendance Widget #3 //
        public DataTable ThisWeekAttendance { get; set; }

        // Employee Report Chart # 1 right //
        public int ProjectCount { get; set; }
        public int RequestsCount { get; set; }
        public int BonusCount { get; set; }
        public int TrainingsCount { get; set; }

        public int AttendanceCount { get; set; }

        public int Salaries { get; set; }


        // Employees Absents Today Chart #2 //
        public int EAttendanceToday { set;get; }
        public int ELeaveBreak { set; get; }


        public HomeModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
            
        }
        public void OnGet()
        {
            ID = dBManager.getCurrentUser();
            int id = ID;
            AttendanceToday = dBManager.CustomQuery($"SELECT Clock_in FROM Attendance, Personal AS P WHERE Atendance_Date = CAST( GETDATE() AS Date ) AND P.id ={id}");

            
            Requests = dBManager.CustomQuery($"SELECT R.* FROM Requests AS R, Employee, Personal_Manager WHERE [Personal_Mang_ID]=[PMID] AND PMID = {id};");

            ThisWeekAttendance = dBManager.CustomQuery($"SELECT A.* FROM Attendance AS A, Personal AS P WHERE A.Person_ID =P.id AND P.id = {id} AND A.Atendance_Date>(SELECT  DATEADD(DAY, 2 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE)) [Week_Start_Date])");

            ProjectCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT([ID]) FROM Project WHERE PMID = {id};"));

            RequestsCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(R.[ID]) FROM [dbo].[Requests] AS R,[dbo].[Employee] AS E WHERE E.EmployeeID = R.EmployeeID AND E.PMID = {id};"));

            BonusCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(B.ID) FROM [dbo].[PenaltiesBonuses] AS B WHERE B.Given_by = {id};"));

            TrainingsCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(TrainingID) FROM Attend_Training, Employee WHERE EmployeeID= E_ID AND PMID ={id};"));

            AttendanceCount = Int32.Parse(dBManager.CustomScalarQuery($"SELECT COUNT(A.ID) FROM [dbo].[Attendance] AS A, [dbo].[Employee] AS E WHERE A.Person_ID=E.EmployeeID AND PMID = {id};"));

            // Need to Calculate Bonuses And Penalties here//
            Salaries = Int32.Parse(dBManager.CustomScalarQuery($"SELECT SUM([Salary]) FROM [dbo].[Personal] AS P,[dbo].[Employee] AS E WHERE P.id= E.EmployeeID AND E.PMID ={id};"));

            //EAttendanceToday = 

            Console.WriteLine("ID is = "+ ID);
            Console.WriteLine("Attendance = "+ AttendanceCount);

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Employee/Request", new { ID = this.ID });
        }
    }
}
