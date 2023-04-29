using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;

namespace HR_DBMS.Pages.Employee
{
    public class TrainingModel : PageModel
    {

        private readonly DBManager dBManager;
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty]
        public DataTable availableTrainings { get; set; }
        [BindProperty]
        public DataTable previousTrainings { get; set; }
        public TrainingModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
        }
        public void OnGet()
        {
            availableTrainings = new DataTable();
            previousTrainings = new DataTable();
        }
    }
}
