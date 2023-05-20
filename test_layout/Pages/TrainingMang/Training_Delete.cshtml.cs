using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.TrainingMang
{
    public class Training_DeleteModel : PageModel
    {
        [BindProperty] 
        public int Train_ID { get; set; }

        [BindProperty]
        public string Train_Name { get; set; }

        [BindProperty]

        public DataTable Train_Data { get; set; }

        public readonly DBManager DB;
        public Training_DeleteModel(DBManager db)
        {
            DB = db;
        }
        public void OnGet(int id)
        {
            Train_ID = id;
            Train_Data =(DataTable) DB.ReadTablesWithConditon("Training", "Training_Name", "ID", Train_ID);
            Train_Name = (string)Train_Data.Rows[0][0];
        }

        public IActionResult OnPost()
        {
            DB.DeleteRecord("Training",Train_ID);

            return RedirectToPage("/TrainingMang/Trainings");
        }
    }
}
