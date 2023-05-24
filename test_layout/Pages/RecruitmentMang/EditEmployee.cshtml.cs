using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HR_DBMS.Models;
using System.Data;
using test_layout.Models;
using Azure;
using System.Runtime.Intrinsics.X86;
using System.Reflection;

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
        public string Password { get; set; }
        [BindProperty]
        public string Status { get; set; }
        [BindProperty]
        public string Team { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string Salary { get; set; }
        [BindProperty]
        public int SSN { get; set; }
        [BindProperty]
        public string Role { get; set; }
        [BindProperty]
        public string Contact { get; set; }
        [BindProperty]
        public string Age { get; set; }
        [BindProperty]
        public string img { get; set; }
 
        [BindProperty]
        public int EmployeeID { get; set; }
        [BindProperty]
        public int RMangID { get; set; }
        //[BindProperty]
        //public string PMangID { get; set; }
        [BindProperty]
        public string Holidays { get; set; }
        [BindProperty]
        public DataTable EmployeeRecord { get; set; }

        public EditEmployeeModel(DBManager db)
        {
            Db = db;
            RMangID = Db.GetCurrentUserID();
            
        }
        public void OnGet(int id)
        {
            EmployeeID = id;

            EmployeeRecord = Db.ReadTablesWithConditon("Personal as P join Employee as E on E.EmployeeID = P.id", " P.FName, P.Lname, P.id, P.Work_Email, P.Team, P.Person_Status, P.Person_Address," +
                " P.Salary,P.SSN, P.Person_Role,P.Contact_Num, P.Age, P.Person_IMG ", "id", EmployeeID.ToString());
        }
        public IActionResult OnPostSubmit(int ID)
        {
            EmployeeID = ID;
            FName= Request.Form["FName"];
            LName = Request.Form["LName"];
            email = Request.Form["Email"];
            Role = Request.Form["Role"];
            Age = Request.Form["Age"];
            Status = Request.Form["Status"];
            Team= Request.Form["Team"];
            Address = Request.Form["Add"];
            Salary = Request.Form["Salary"];
            Contact = Request.Form["Contact"];
            img = Request.Form["img"];

           // PMangID = Request.Form["PMangID"];
            Holidays = Request.Form["Holidays"];

            Db.UpdateRecordPerson(EmployeeID,FName.ToString(), LName.ToString(), email.ToString(), Status.ToString(),
                Team.ToString(), Address.ToString(), Salary, 123, Role.ToString(), Contact.ToString(),
                Age,  img.ToString(), Holidays);
            

            return RedirectToPage("/RecruitmentMang/Employees");
        }
    }
}
