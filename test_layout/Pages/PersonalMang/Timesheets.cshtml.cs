using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.PersonalMang
{
    public class TimesheetsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public DataTable employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BestEmployee { get; set; }
        private readonly DBManager dbManager;
        public TimesheetsModel(DBManager Db) {
            dbManager = Db;
        }


        
        public void OnGet()
        {
            int id = dbManager.getCurrentUser();
            employees = dbManager.CustomQuery($"SELECT P.id, P.FName + P.LName, P.Person_role,(SELECT SUM(Time_Spent) FROM Works_On,Employee WHERE EmployeeID = EID AND P.id=EmployeeID GROUP BY EmployeeID)  FROM Personal AS P, Employee WHERE EmployeeID=P.id AND PMID ={id};");
            BestEmployee = (string)dbManager.CustomScalarQuery($"SELECT FName+''+Lname FROM Personal,Employee, Works_On WHERE EID=id AND EmployeeID = id AND PMID={id} AND Time_Spent = (SELECT MAX(Time_Spent) FROM Works_On,Employee WHERE EmployeeID=EID AND PMID={id})");
        }
    }
}
