using System.Data;
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
        public HomeModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
            Requests = new DataTable();
            PenaltiesBonuses = new DataTable();
        }
        public void OnGet(int id)
        {
            ID = id;
            //Requests = dBManager.ReadTableCondition("Requests", "EmployeeID", Convert.ToString(ID));
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Employee/Request", new { ID = this.ID });
        }
    }
}
