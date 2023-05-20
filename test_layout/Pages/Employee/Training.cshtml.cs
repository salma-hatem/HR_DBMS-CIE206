using System.Data;
using HR_DBMS.Models;
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
            string q = $"SELECT T.ID, T.Training_Name,T.Training_Location FROM Attend_Training AS AT INNER JOIN Training AS T ON ID = TrainingID INNER JOIN Training_Date AS TD ON TD.ID = T.ID WHERE TD.Training_EndDate > GETDATE() except(SELECT T.ID, T.Training_Name, T.Training_Location FROM Attend_Training AS AT INNER JOIN Training AS T ON ID = TrainingID INNER JOIN Training_Date AS TD ON TD.ID = T.ID where E_ID = {ID} )";

            availableTrainings = dBManager.ReadTablesQuery(q);


            currentTrainings = dBManager.ReadTablesQuery($"SELECT T.ID, T.Training_Name,T.Training_Location FROM Attend_Training AS AT INNER JOIN Training AS T ON ID=TrainingID INNER JOIN Training_Date AS TD ON TD.ID = T.ID WHERE E_ID = {ID} AND TD.Training_EndDate > GETDATE();");
            //currentTrainings = (DataTable)dBManager.getPrevTraining("Training_Date as TD", "Training as T", "T.ID,Training_Name,Training_Location,Training_Description",
                //"TD.ID", "T.ID", "Training_EndDate", ">");
            previousTrainings = dBManager.ReadTablesQuery($"SELECT T.ID, T.Training_Name,T.Training_Location FROM Attend_Training AS AT INNER JOIN Training AS T ON ID=TrainingID INNER JOIN Training_Date AS TD ON TD.ID = T.ID WHERE E_ID = {ID} AND TD.Training_EndDate < GETDATE();)");
 
        }
        public void OnPost()
        {
            
        }
    }
}
