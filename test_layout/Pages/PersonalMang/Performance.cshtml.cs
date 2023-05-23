using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.PersonalMang
{
    public class PerformanceModel : PageModel
    {
        private readonly DBManager _dbManager;

        public PerformanceModel(DBManager dbManager)
        {
            _dbManager = dbManager;
            ints = new List<int>();
        }

        // VARIABLES //
        // Total Employees
        public int TotalEmployees { get; set; }

        // Employees Increase

        //Total Absents 
        public int TotalAbsents { get; set; }

        //Absents Raise

        //Total Salaries
        public int TotalSalaries { get; set; }

        //Total Requests
        public int TotalRequests { get; set; }

        // Work-Location Distribution
        public DataTable Work_Location { get; set; }

        // Location Number Array
        public List<int> ints { get; set; }

        // Count Projects
        public int TotalProjects { get; set; }

        // Project 
        public DataTable Projects { get; set; }
        public void OnGet()
        {
            int id = _dbManager.getCurrentUser();

            TotalEmployees = Int32.Parse(_dbManager.CustomScalarQuery($"SELECT COUNT(EmployeeID) FROM Employee WHERE PMID = {id};"));

            TotalAbsents = Int32.Parse(_dbManager.CustomScalarQuery($"SELECT COUNT(ID) FROM Attendance, Employee WHERE EmployeeID=Person_ID AND PMID = {id} AND Atendance_Date>(SELECT DATEADD(m, DATEDIFF(m, 0, GETDATE()), 0) );"));
            
            TotalSalaries = Int32.Parse(_dbManager.CustomScalarQuery($"SELECT SUM(P.Salary) FROM Personal AS P, Employee WHERE P.id=EmployeeID AND PMID=0;\r\nSELECT SUM(P.Salary) FROM Personal AS P, Employee WHERE P.id=EmployeeID AND PMID={id};"));
            
            TotalRequests = Int32.Parse(_dbManager.CustomScalarQuery($"SELECT COUNT(ID) FROM Requests WHERE Approved_by = {id};"));

            Work_Location = _dbManager.CustomQuery($"SELECT COUNT(id),Person_Address FROM Personal GROUP BY Person_Address ORDER BY COUNT(id) DESC ;");

           
            
            foreach(DataRow dr in Work_Location.Rows)
            {
                ints.Add((int)dr[0]);
            }

            TotalProjects = Int32.Parse(_dbManager.CustomScalarQuery($"SELECT COUNT(ID) FROM Project WHERE PMID = {id};"));

            Projects = _dbManager.CustomQuery($"SELECT ID,PName,StartDate, (SELECT COUNT(EID) FROM Works_On WHERE PID = ID), Progress_Percentage FROM Project WHERE PMID = {id};");
        }
    }
}
