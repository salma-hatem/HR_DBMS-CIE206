using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using test_layout.Models;
using HR_DBMS.Models;
namespace HR_DBMS.Pages.TrainingMang
{
    public class Update_TrainingModel : PageModel
    {
        public readonly DBManager DB;

        [BindProperty]
        public DataTable dt { get; set; }

        [BindProperty(SupportsGet =true)]
        public int Train_id { get; set; }

        [BindProperty]
        public int Mang_ID { get; set; }

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
        [Range(typeof(DateTime), "1/1/2020", "1/1/2050", ErrorMessage = "Date is out of Range 1/1/2020 to 1/1/2050")]
        public DateTime Train_start_date { get; set; }

        [Required]
        [BindProperty]
        public DateTime Train_time { get; set; }

        public DateTime Training_time { get; set; }

        [Required]
        [BindProperty]
        public DateTime Train_end_date { get; set; }

        public Update_TrainingModel(DBManager db)
        {
            DB = db;
            dt = new DataTable();
            Mang_ID = DB.getCurrentUser();


        }

       
        public void OnGet(int id)
        {
            Train_id = id;
            dt = (DataTable)DB.JoinTablesWithCondition("Training as T","Training_Date as TD", "T.ID,Training_Name,Training_Location,Training_Description,Training_Time,Training_StartDate ,Training_EndDate ", "TD.ID", "T.ID","T.ID",Train_id.ToString());

            Train_id = (int)dt.Rows[0][0];

            Train_name = (string)dt.Rows[0][1];
            Train_location = (string)dt.Rows[0][2];
            Train_description = (string)dt.Rows[0][3];
         Train_time =(DateTime.Parse( dt.Rows[0][4].ToString()));
          
            Train_start_date = (DateTime)dt.Rows[0][5];
            Train_end_date = (DateTime)dt.Rows[0][6];
            //dt = (DataTable)DB.JoinTablesWithCondition("Training as T","Training_Date as TD", 
            //    "Training_Name ,Training_Location,Training_Description,Training_Time,Training_StartDate ,Training_EndDate",
            //    "TD.ID", "T.ID","T.ID",id.ToString());

            // Train_start_date = (DateTime)dt.Rows[0][3];
            // Train_end_date = (DateTime)dt.Rows[0][4];

        }

        public IActionResult OnPostUpdate()
        {
            if(ModelState.IsValid)
            {
                DB.AlterTraining("Training",Train_id,Train_name.ToString(),Train_location.ToString(),Mang_ID,Train_description.ToString());
                DB.AlterTrainingDate("Training_Date",Train_id,Train_time,Train_start_date,Train_end_date);
                return RedirectToPage("Home");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Home");
        }
    }
}
