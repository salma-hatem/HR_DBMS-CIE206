using System.Data;
using System.Reflection;
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
        public int Holidays { get; set; }
        public int attendance { get; set; }
        [BindProperty]
        public int attendancePercent { get; set; }
        [BindProperty]
        public int absent { get; set; }
        [BindProperty(SupportsGet = true)]
        public string message { get; set; }
        public DataTable attendenceToday { get; set; }
        public HomeModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
            Requests = new DataTable();
            PenaltiesBonuses = new DataTable();
        }
        public void OnGet()
        {
            ID = dBManager.GetCurrentUserID();
            Holidays = dBManager.ExcuteScalarINT("Personal", "Holidays", "id", Convert.ToString(ID));
            PenaltiesBonuses = dBManager.ReadTablesWithConditon("PenaltiesBonuses", "Type_, Percentage_Change", "EmployeeID", Convert.ToString(ID));
            Requests = dBManager.ReadTablesWithConditon("Requests", "R_Type, R_Description, R_Status", "EmployeeID", Convert.ToString(ID));
            attendance = dBManager.ExcuteScalarINT("Attendance","count(*)", "Person_ID",ID.ToString());
            attendancePercent = (attendance - Holidays) * 100/ 30;
            absent = 30 - attendance;
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Employee/Request", new { ID = this.ID });
        }
        public IActionResult OnPostAttendance()
        {
            int id = dBManager.getCurrentUser();
            string q = "select * from Attendance where Person_ID = " + id + " and Atendance_Date = cast(GETDATE() as  Date);";
            attendenceToday = dBManager.CustomQuery(q);
            if (attendenceToday.Rows.Count == 0)
            {
                int MaxID = dBManager.GetMaxID("Attendance")+1;
                string qInsert = "insert into Attendance (ID, Atendance_Date, Person_ID) values ( " + MaxID +", cast(GETDATE() as  Date), " + id +")";
                dBManager.CustomNonQuery(qInsert);
                string m = "Attendance Taken!";
                return RedirectToPage("/Employee/Home", new { message = m});
                //return Page();
            }
            else
            {

                string m = "Attendance Already Taken";
                return RedirectToPage("/Employee/Home", new { message = m });
                //return Page();
            }

        }
    }
}
