using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HR_DBMS.Models;
using System.Data;
using test_layout.Models;
using Azure;
using System.Runtime.Intrinsics.X86;

namespace HR_DBMS.Pages.RecruitmentMang
{
    public class Add_EmployeeModel : PageModel
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
        public string  Address { get; set; }
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
        public int PMID { get; set; }

        public Add_EmployeeModel(DBManager db)
        {
            Db = db;
            RMangID = Db.GetCurrentUserID();
            EmployeeID = Db.getEmployeeID();
        }
        public void OnGet()
        {

        }
        public IActionResult OnPostSubmit()
        {
            Db.AddRecordPerson(FName.ToString(), LName.ToString(), EmployeeID, email.ToString(),Password, Status.ToString(),
                Team.ToString(), Address.ToString(), Salary, SSN, Role.ToString(), Contact.ToString(), Age, Sex.ToString(),img.ToString(),Holidays );
            Db.AddRecordEmployee(EmployeeID, RMangID, PMID);
            return RedirectToPage("/RecruitmentMang/Employees");
        }
    }
}
