using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace HR_DBMS.Pages.TrainingMang
{
    public class TrainingsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public readonly DBManager DB;

        public TrainingsModel(DBManager dB)
        {
            DB = dB;
            ID = DB.GetCurrentUserID();
          

        }
        public void OnGet()
        {
            
        }
    }
}
