using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.TrainingMang
{
    public class Training_UpdateModel : PageModel
    {
        public readonly DBManager DB;

        [BindProperty]
        public DataTable dt { get; set; }

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
        public DateTime Train_start_date { get; set; }

        [Required]
        [BindProperty]
        public DateTime Train_end_date { get; set; }

        public Training_UpdateModel(DBManager db)
        {
            DB = db;
            dt = (DataTable)DB.ReadTablesWithConditon("Training", "Training_Name,Training_Location, Training_Description", "ID", Train_id.ToString());

            Train_name = (string)dt.Rows[0][0];
            Train_location = (string)dt.Rows[0][1];
            Train_description = (string)dt.Rows[0][2];

        }
        public void OnGet(int id)
        {
            Train_id = id;
            //dt = (DataTable)DB.JoinTablesWithCondition("Training as T","Training_Date as TD", 
            //    "Training_Name ,Training_Location,Training_Description,Training_Time,Training_StartDate ,Training_EndDate",
            //    "TD.ID", "T.ID","T.ID",id.ToString());
            
           // Train_start_date = (DateTime)dt.Rows[0][3];
           // Train_end_date = (DateTime)dt.Rows[0][4];

        }
    }
}
