using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;
namespace HR_DBMS.Pages.TrainingMang
{
    public class Create_TrainingModel : PageModel
    {
        public readonly DBManager DB;

        [BindProperty]
        public int Mang_id { get; set; }

        [BindProperty]
        public int Train_id { get; set; }

        [BindProperty]
        public string Train_name { get; set; }

        [BindProperty]
        public string Train_location { get; set; }

        [BindProperty]
        public string Train_description { get; set; }

        [BindProperty]
        public DateTime Train_time { get; set; }

        [BindProperty]
        public DateTime Train_start_date { get; set; }

        [BindProperty]
        public DateTime Train_end_date { get; set; }



        public Create_TrainingModel(DBManager db)
        {
            DB = db;
            Mang_id = DB.GetCurrentUserID();

            Train_id = DB.getTrainingID();
           

        }
        public void OnGet()
        {
        }
        public IActionResult OnPostCreate()
        {

            DB.AddTraining("Training", Train_id, Train_name.ToString(), Train_location.ToString(), Mang_id, Train_description.ToString());
            //addtraining date
            DB.AddTrainingDate("Training_Date",Train_id,Train_time,Train_start_date,Train_end_date);
            return RedirectToPage("/TrainingMang/Trainings");
        }

        public IActionResult OnPostCancel() {

            return RedirectToPage("/TrainingMang/Trainings");
        }
    }
}
