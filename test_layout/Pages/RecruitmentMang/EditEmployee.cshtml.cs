using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HR_DBMS.Models;
using System.Data;
using test_layout.Models;
using Azure;
using System.Runtime.Intrinsics.X86;

namespace HR_DBMS.Pages.RecruitmentMang
{
    public class EditEmployeeModel : PageModel
    {
        public readonly DBManager Db;

        [BindProperty]
        public string FName { get; set; }
        [BindProperty]
        public string LName { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public int Password { get; set; }
        [BindProperty]
        public string Status { get; set; }
        [BindProperty]
        public string Team { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public int Salary { get; set; }
        [BindProperty]
        public int SSN { get; set; }
        [BindProperty]
        public string Role { get; set; }
        [BindProperty]
        public string Contact { get; set; }
        [BindProperty]
        public int Age { get; set; }
        [BindProperty]
        public string img { get; set; }
        [BindProperty]
        public string Sex { get; set; }
        [BindProperty]
        public int EmployeeID { get; set; }
        [BindProperty]
        public int RMangID { get; set; }
        [BindProperty]
        public int Holidays { get; set; }
        [BindProperty]
        public DataTable EmployeeRecord { get; set; }

        public EditEmployeeModel(DBManager db)
        {
            Db = db;
            RMangID = Db.GetCurrentUserID();
            EmployeeID = Db.getEmployeeID();
        }
        public void OnGet(int id)
        {
            EmployeeID = id;
            EmployeeRecord = Db.ReadTablesWithConditon("Personal as P join Employee as E on E.EmployeeID = P.id", " P.FName, P.Lname, P.id, P.Work_Email, P.Team, P.Person_Status", "id", EmployeeID.ToString());
        }
        //public IActionResult OnPostSubmit()
        //{
        //    Db.AddRecordPerson(FName.ToString(), LName.ToString(), EmployeeID, email.ToString(), Password, Status.ToString(),
        //        Team.ToString(), Address.ToString(), Salary, SSN, Role.ToString(), Contact.ToString(), Age, Sex.ToString(), img.ToString(), Holidays);
        //    Db.AddRecordEmployee(EmployeeID, RMangID, 1);
        //    return RedirectToPage("/RecruitmentMang/Employees");
        //}
    }
}
