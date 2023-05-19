using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;
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
            string sd = DateTime.ParseExact(P.StartDate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture).ToString();
            string ed = DateTime.ParseExact(P.Deadline, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture).ToString();

            Console.WriteLine(sd + "  ANDDD  " + ed);
            int pmid = dBManager.getCurrentUser();
            int id = Int32.Parse(dBManager.CustomScalarQuery("SELECT MAX(ID) FROM Project;")) + 1;
            dBManager.CustomNonQuery($"INSERT INTO Project VALUES ({id},'{P.Name}','{P.Description}','{P.Goal}', CONVERT(datetime, '{sd}', 101) ,NULL, CONVERT(datetime, '{ed}', 101),'Just Started',0,{pmid})");

            return RedirectToPage("../Project");

                
        }
    }
}
