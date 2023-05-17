using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.TrainingMang
{
    public class Training_detailModel : PageModel
    {
        public readonly DBManager DB;
        public int Train_id { get; set; }

        public DataTable Training_Details { get; set; }

        public DataTable Training_times { get; set; }

        public DataTable Attendees { get; set; }

        public Training_detailModel(DBManager db)
        {
            DB = db;
        }
        public void OnGet(int id)
        {
            Train_id = id;
            Training_Details=(DataTable)DB.ReadTablesWithConditon("Training","Training_Name,Training_Description", "ID", Train_id.ToString());
            Training_times = (DataTable)DB.ReadTablesWithConditon("Training_Date", " Training_StartDate, Training_EndDate ", "ID", Train_id.ToString());
            Attendees = (DataTable)DB.JoinTablesWithCondition("Personal as P", "Attend_Training as A", "FName,LName", "P.id", "A.E_ID", "A.TrainingID", Train_id.ToString());
        }
    }
}
