using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HR_DBMS.Pages.TrainingMang
{
    public class HomeModel : PageModel
    {
        public int ID { get; set; }
        public void OnGet(int id)
        {
            ID = id;
        }
    }
}
