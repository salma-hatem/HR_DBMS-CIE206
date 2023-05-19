using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.TrainingMang
{
    public class TrainingsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public readonly DBManager DB;


        [BindProperty]
        public DataTable CurrTraining_times { get; set; }
        [BindProperty]
        public DataTable PrevTraining_times { get; set; }

        public TrainingsModel(DBManager dB)
        {
            DB = dB;
            ID = DB.GetCurrentUserID();
          

        }
        public void OnGet()
        {
            
            CurrTraining_times = (DataTable)DB.getPrevTraining("Training_Date as TD", "Training as T", "T.ID,Training_Name,Training_Location,Training_Description, Training_Time,Training_StartDate ,Training_EndDate",
                "TD.ID", "T.ID","Training_EndDate",">"); 
            PrevTraining_times = (DataTable)DB.getPrevTraining("Training_Date as TD", "Training as T", "T.ID,Training_Name,Training_Location,Training_Description, Training_Time,Training_StartDate ,Training_EndDate",
                "TD.ID", "T.ID", "Training_EndDate", "<");

        }
    }
}
