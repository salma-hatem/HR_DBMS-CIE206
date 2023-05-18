using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.PersonalMang
{
    public class RequestsModel : PageModel
    {
        private readonly DBManager dBManager;
        public RequestsModel(DBManager dBManager)
        {
            this.dBManager = dBManager;

        }
        [BindProperty(SupportsGet = true)]
        public DataTable Requests { get; set; }
        public void OnGet()
        {
            int id = dBManager.getCurrentUser();
            Requests = dBManager.CustomQuery($"SELECT R.ID,R.R_Type,R.R_Status, R.R_Description,P.FName FROM Requests AS R,Personal AS P WHERE Approved_by = {id} AND P.id=R.EmployeeID;");
        }

        public async Task<IActionResult> OnPostApproveAsync(int id) {
            dBManager.CustomNonQuery($"UPDATE Requests SET R_Status = 'Approved' WHERE ID = {id};");
            return RedirectToPage(Requests);
        }

        public async Task<IActionResult> OnPostDecline(int id)
        {
            Console.WriteLine("I am here");
            
            dBManager.CustomNonQuery($"UPDATE Requests SET R_Status = 'Declined' WHERE ID = {id};");
            return RedirectToPage(Requests);
        }

    }
}
