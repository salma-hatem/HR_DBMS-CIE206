using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;


namespace HR_DBMS.Pages.TrainingMang
{
    public class AnnouncmentsModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string text { get; set; }
        [BindProperty]
        public string Date { get; set; }
        [BindProperty]
        public int MID { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/RecruitmentMang/Employ");
        }
    }
}
