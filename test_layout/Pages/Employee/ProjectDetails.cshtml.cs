using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace HR_DBMS.Pages.Employee
{
    public class ProjectDetailsModel : PageModel
    {
        private readonly DBManager dBManager;
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty]
        public DataTable project { get; set; }
        [BindProperty]
        public DataTable team { get; set; }
         [BindProperty]
        public int progress { get; set; } //for testing
       
        public ProjectDetailsModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
        }
        public void OnGet()
        {
            project = new DataTable();
            team = new DataTable();
            progress = 75;
        }
    }
}
