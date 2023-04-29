using System.Data;
using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace HR_DBMS.Pages.Employee
{
    public class ProjectModel : PageModel
    {
        private readonly DBManager dBManager;
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty]
        public DataTable currentProjects { get; set; }
        [BindProperty]
        public DataTable previousProjects { get; set; }
        public ProjectModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
        }
        public void OnGet()
        {
            currentProjects = new DataTable();
            previousProjects = new DataTable();
        }
    }
}
