using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HR_DBMS.Models;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.RecruitmentMang
{
    public class Add_EmployeeModel : PageModel
    {
        public readonly DBManager Db;

        public void OnGet()
        {
        }
    }
}
