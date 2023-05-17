using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration.UserSecrets;
using test_layout.Models;

namespace HR_DBMS.Pages.Employee
{
    public class Training_detailModel : PageModel
    {

        public readonly DBManager DB;
        [BindProperty(SupportsGet =true)]
        public int Train_id { get; set; }

        public DataTable Training_Details { get; set; }

        public DataTable Training_times { get; set; }

        public DataTable Attendees { get; set; }
        public int status { get; set; }
        public int current { get; set; }

        public Training_detailModel(DBManager db)
        {
            DB = db;
        }
        public void OnGet(int id)
        {
            Train_id = id;
            status = DB.ExcuteScalarINT("Training", "Training_Status", "ID",id.ToString());
            Training_Details = (DataTable)DB.ReadTablesWithConditon("Training", "Training_Name,Training_Description", "ID", Train_id.ToString());
            Training_times = (DataTable)DB.ReadTablesWithConditon("Training_Date", " Training_StartDate, Training_EndDate ", "ID", Train_id.ToString());
            Attendees = (DataTable)DB.JoinTablesWithCondition("Personal as P", "Attend_Training as A", "FName,LName", "P.id", "A.E_ID", "A.TrainingID", Train_id.ToString());
            int useID = DB.GetCurrentUserID();
            current = DB.ExcuteScalarINT("Attend_Training", "count(*)", "E_ID = " + useID + "AND TrainingID ", id.ToString());
        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/Employee/Training");
        }
        public IActionResult OnPostJoin()
        {
            int useID = DB.GetCurrentUserID();
            int time = 0;
            DB.AddRecordAttend_Training(Train_id, useID, time);
            return RedirectToPage("/Employee/Training");
        }
    }
}
