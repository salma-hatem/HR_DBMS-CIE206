using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [BindProperty]
        public string Train_name { get; set; }

        [Required]
        [BindProperty]
        public string Train_location { get; set; }

        [Required]
        [BindProperty]
        public string Train_description { get; set; }

        [Required]
        [BindProperty]
        public DateTime Train_time { get; set; }

        [Required]
        [BindProperty]
        [Range(typeof(DateTime), "1/1/2020", "1/1/2050", ErrorMessage = "Date is out of Range 1/1/2020 to 1/1/2050")]

        public DateTime Train_start_date { get; set; }

        [Required]
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
            if(ModelState.IsValid) { 

            DB.AddTraining("Training", Train_id, Train_name.ToString(), Train_location.ToString(), Mang_id, Train_description.ToString());
            //addtraining date
            DB.AddTrainingDate("Training_Date",Train_id,Train_time,Train_start_date,Train_end_date);
            return RedirectToPage("/TrainingMang/Trainings");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPostCancel() {

            return RedirectToPage("/TrainingMang/Trainings");
        }
    }
}
