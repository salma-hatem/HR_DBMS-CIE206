using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace HR_DBMS.Pages.Emplyee
{
    public class HomeModel : PageModel
    {
        private readonly DBManager dBManager;
        public DataTable Requests { get; set; }
        public DataTable PenaltiesBonuses { get; set; }
        [BindProperty (SupportsGet =true)]
        public int ID  { get; set; }
        [BindProperty]
        public DataTable Holidays { get; set; }
        public int attendance { get; set; }
        [BindProperty]
        public int attendancePercent { get; set; }
        [BindProperty]
        public int absent { get; set; }
        public HomeModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
            Requests = new DataTable();
            PenaltiesBonuses = new DataTable();
            ID = dBManager.GetCurrentUserID();
        }
        public void OnGet()
        {
            Holidays = dBManager.ReadTablesWithConditon("Personal", "Holidays", "id", Convert.ToString(ID));
            PenaltiesBonuses = dBManager.ReadTablesWithConditon("PenaltiesBonuses", "Type_, Percentage_Change", "EmployeeID", Convert.ToString(ID));
            Requests = dBManager.ReadTablesWithConditon("Requests", "R_Type, R_Description, R_Status", "EmployeeID", Convert.ToString(ID));
            attendance = dBManager.ExcuteScalarINT("Attendance","count(*)", "Person_ID",ID.ToString());
            attendancePercent = attendance  * 100/ 30;
            absent = 30 - attendance;
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Employee/Request", new { ID = this.ID });
        }
    }
}
