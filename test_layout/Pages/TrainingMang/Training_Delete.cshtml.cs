using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace HR_DBMS.Pages.TrainingMang
{
    public class Training_DeleteModel : PageModel
    {

        public int Train_ID { get; set; }

        public readonly DBManager DB;
        public Training_DeleteModel(DBManager db)
        {
            DB = db;
        }
        public void OnGet(int id)
        {

        }
    }
}
