using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.PersonalMang
{
    public class HomeModel : PageModel
    {
        private readonly DBManager dBManager;
    
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        public HomeModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
            
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
