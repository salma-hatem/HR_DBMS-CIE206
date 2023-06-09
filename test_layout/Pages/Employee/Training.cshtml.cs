using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace HR_DBMS.Pages.Employee
{
    public class TrainingModel : PageModel
    {

        private readonly DBManager dBManager;
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty]
        public DataTable availableTrainings { get; set; }
        [BindProperty]
        public DataTable currentTrainings { get; set; }
        [BindProperty]
        public DataTable previousTrainings { get; set; }
        [BindProperty]
        public string search { get; set; }
        public TrainingModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
            ID = dBManager.GetCurrentUserID();
        }
        public void OnGet()
        {
           // string q = "select ID, Training_Name, Training_Location, Training_Description from Training where Training_Status = 0 except (select ID, Training_Name, Training_Location, Training_Description from Attend_Training inner join Training on ID = TrainingID\r\nwhere E_ID = " + ID + " )";
            availableTrainings = (DataTable)dBManager.getPrevTraining("Training_Date as TD", "Training as T", "T.ID,Training_Name,Training_Location,Training_Description",
                "TD.ID", "T.ID", "Training_EndDate", "<");
            currentTrainings = (DataTable)dBManager.getPrevTraining("Training_Date as TD", "Training as T", "T.ID,Training_Name,Training_Location,Training_Description",
                "TD.ID", "T.ID", "Training_EndDate", "<");
            previousTrainings = (DataTable)dBManager.getPrevTraining("Training_Date as TD", "Training as T", "T.ID,Training_Name,Training_Location,Training_Description",
                "TD.ID", "T.ID", "Training_EndDate", "<");
        }
        public void OnPost()
        {
            
        }
    }
}
