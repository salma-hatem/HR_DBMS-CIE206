using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HR_DBMS.Models;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.RecruitmentMang
{
    public class HomeModel : PageModel
    {
        public readonly DBManager Db;
        public int Employeenum { get; set; }
        public int ApplicantNum { get; set; }
        public HomeModel(DBManager db)
        {
            Db=db;
            Employeenum = Db.getEmployeeNum();
            ApplicantNum = Db.getApplicantNum();
        }
        public void OnGet()
        {

        }
    }
}
