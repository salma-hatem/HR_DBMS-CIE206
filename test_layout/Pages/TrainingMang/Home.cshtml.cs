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

        public HomeModel(DBManager dB)
        {

            DB = dB;    

        }
        public void OnGet(int id)
        {
            ID = id;
            Trainings = (DataTable)DB.ReadTables("Training");
            
        }
    }
}
