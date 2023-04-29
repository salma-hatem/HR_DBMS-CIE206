using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace HR_DBMS.Pages.Employee
{
    public class RequestModel : PageModel
    {
        private readonly DBManager dBManager;
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty]
        public Request request { get; set; }
        public RequestModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
        }
        public void OnGet()
        {
            request = new Request();
        }
        public IActionResult OnPostSubmit()
        {
            if (ModelState.IsValid)
                return RedirectToPage("/Employee/Home", new { ID = this.ID });
            else
                return Page();
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Employee/Home", new { ID = this.ID });
        }
    }
}
