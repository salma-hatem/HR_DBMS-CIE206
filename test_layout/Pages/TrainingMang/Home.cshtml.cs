using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.TrainingMang
{
    public class HomeModel : PageModel
    {
        public int ID { get; set; }
        //   public int Attendance { get; set; }

        //  public readonly  Training TR;

        public readonly DBManager DB;
        public DataTable Trainings { get; set; }

        public DataTable Training_times { get; set; }


        public HomeModel(DBManager dB)
        {

            DB = dB;  
            

        }
        public void OnGet(int id)
        {
            ID = id;
            Trainings = (DataTable)DB.ReadTablesWithConditon("Training","ID,Training_Name,Training_Location", "Training_Status", "0");
            //Train_id = (DataTable)DB.ReadTablesfrom("Training", "ID");
            Training_times = (DataTable)DB.ReadTablesfrom("Training_Date", "Training_Time, (CONVERT(date, Training_StartDate)), (CONVERT(date, Training_EndDate)) ");
           
        }
    }
}
