using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.PersonalMang
{
    public class ProjectModel : PageModel
    {
        private readonly DBManager dBManager;

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }


        public ProjectModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
        }

        [BindProperty]
        public ModelProject Project { get; set; }

        // QUERIES VARIABLES//
        //  #1  Projects //
        [BindProperty(SupportsGet = true)]
        public DataTable Projects { get; set; }
        public void OnGet()
        {
            this.ID = dBManager.getCurrentUser();

            

            Projects = dBManager.CustomQuery($"SELECT ID,PName,Status_,PGoal FROM Project WHERE PMID ={ID};");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/Personal/Mang/Home");
            }

            return Page();
        }
    }
}
