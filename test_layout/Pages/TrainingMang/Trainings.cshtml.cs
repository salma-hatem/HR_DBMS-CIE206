using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HR_DBMS.Pages.TrainingMang
{
    public class TrainingsModel : PageModel
    {
        public int ID { get; set; }
        public TrainingsModel()
        {
            
        }
        public void OnGet(int id)
        {
            ID = id;
        }
    }
}
