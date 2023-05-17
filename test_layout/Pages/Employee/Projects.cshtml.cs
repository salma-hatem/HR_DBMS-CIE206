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
        public DataTable compeletedProjects { get; set; }
        [BindProperty]
        public int TotalProgress { get; set; }
        public ProjectModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
            ID = dBManager.GetCurrentUserID();
        }
        public void OnGet()
        {
            ID = dBManager.GetCurrentUserID();
            currentProjects = dBManager.ReadTablesWithConditon("Project inner join Works_On on ID = PID", "ID, PName, Status_", "Status_ != 'Complete' AND EID", ID.ToString());
            compeletedProjects = dBManager.ReadTablesWithConditon("Project inner join Works_On on ID = PID", "ID, PName, PDescription, PGoal, EndDate", "Status_ = 'Complete' AND EID", ID.ToString());
            int sum = dBManager.ExcuteScalarINT("Project inner join Works_On on ID = PID", "sum(Progress_Percentage)", "EID", ID.ToString());
            int c = dBManager.ExcuteScalarINT("Project inner join Works_On on ID = PID", "count(*)", "EID", ID.ToString());
            TotalProgress = sum/c;
        }
    }
}
