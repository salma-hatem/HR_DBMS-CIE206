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
        public int pID { get; set; }
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
        public void OnGet(int id)
        {
            pID = id; 
            project = dBManager.ReadTablesWithConditon("Project","*","ID", pID.ToString());
            team = dBManager.ReadTablesWithConditon("Works_On inner join Personal on id = EID", "concat(FName, ' ', LName) as fullname, Work_Email", "PID", pID);
            progress = dBManager.ExcuteScalarINT("Project", "Progress_Percentage","ID", pID.ToString());
        }
    }
}
