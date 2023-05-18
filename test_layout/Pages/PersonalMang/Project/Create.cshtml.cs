using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace HR_DBMS.Pages.PersonalMang.Project
{
    public class CreateModel : PageModel
    {
        [BindProperty] 
        public ModelProject P { get; set; }
        private readonly DBManager dBManager;
        public CreateModel(DBManager db) { dBManager = db; }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        { 
            if(ModelState.IsValid)
            {
                int pmid = dBManager.getCurrentUser();
                int id = Int32.Parse(dBManager.CustomScalarQuery("SELECT MAX(ID) FROM Project;")) + 1;
                dBManager.CustomNonQuery($"INSERT INTO Project VALUES ({id},'{P.Name}','{P.Description}','{P.Goal}','{P.StartDate}','NULL','{P.Deadline}','Just Started',0,{pmid})");

                return RedirectToPage("../Project");
            }

            return Page();
                
        }
    }
}
