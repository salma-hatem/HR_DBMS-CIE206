using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HR_DBMS.Models;
using System.Data;
using test_layout.Models;


namespace HR_DBMS.Pages.RecruitmentMang
{
    public class EmployeesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public readonly DBManager DB;

        [BindProperty]
        public DataTable Employees_table { get; set; }
        public EmployeesModel(DBManager dB)
        {
            DB = dB;
            ID = DB.GetCurrentUserID();
        }

        public void OnGet()
        {
            Employees_table = (DataTable)DB.JoinTables("Personal as P","Employee as E", "concat(P.FName ,' ', P.Lname), P.id, P.Work_Email, P.Team, Person_Status",
                "E.EmployeeID", "P.id");
        }
        public void OnPost()
        {

        }
    }
}
