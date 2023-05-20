using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.PersonalMang
{
    public class EmployeesModel : PageModel
    {
        private readonly DBManager dBManager;
        public EmployeesModel(DBManager dB)
        {
            dBManager = dB;
        }

        [BindProperty]
        public DataTable Employees { get; set; }

        [BindProperty]
        public DataTable CurrentEmployee { get; set; }
        [BindProperty]
        public int Perc { get; set; }
        public void OnGet(int id)
        {
            
            int employeeID = id;
            int C_ID = dBManager.getCurrentUser();

            Employees = dBManager.CustomQuery($"SELECT id,FName +' '+LName, Work_Email, Person_Role FROM Personal, Employee WHERE PMID ={C_ID} AND id=EmployeeID;");

            CurrentEmployee = dBManager.CustomQuery($"SELECT id,SSN,Sex,Fname+ ''+Lname,Person_Role,Work_Email, Contact_Num, Salary, Person_Address FROM Personal WHERE id={employeeID};");
        
        }
        public async Task<IActionResult> OnPostGive(int eid)
        {
            int perc = Perc;
            int pmid = dBManager.getCurrentUser();
            string type;
            int recoredid = Int32.Parse(dBManager.CustomScalarQuery("SELECT MAX(ID)+1 FROM PenaltiesBonuses"));
            if(perc>0)
            {
                type = "Bonus";
            }
            else
            {
                type = "Penalty";
            }
            Console.WriteLine (eid +" "+perc+" "+type+ CurrentEmployee);
            dBManager.CustomNonQuery($"INSERT INTO PenaltiesBonuses VALUES ({recoredid}, '{type}',{perc},{eid},{pmid} )");
            return RedirectToPage("Employees", new { id = eid.ToString() } );
        }
    }
}
