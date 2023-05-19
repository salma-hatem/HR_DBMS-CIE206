using Azure.Core;
using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;
using test_layout.Pages;

namespace HR_DBMS.Pages.PersonalMang.Project
{
    public class ViewModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DBManager dBManager;
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        [BindProperty(SupportsGet = true)]


        // Render Project Data //
        public DataTable Project { get; set; }
        [BindProperty(SupportsGet = true)]

        public int EID { get; set; }

        [BindProperty(SupportsGet = true)]

        // Render Employee Data //
        public DataTable Employees { get; set; }

        [BindProperty(SupportsGet = true)]

        public DataTable AddEmployeesOptions { get; set; }


        [BindProperty(SupportsGet = true)]
        public ModelProject p { get; set; }

        public void OnGet(int id)
        {
            int pmid = dBManager.getCurrentUser();
            
            ID = id;

            Console.WriteLine(ID);
            Project = dBManager.CustomQuery($"SELECT * FROM Project WHERE ID = {id};");
            Employees = dBManager.CustomQuery($"SELECT W.EID,FName,Person_role,Time_Spent FROM Works_On AS W, Personal AS P WHERE W.PID= {id} AND EID =id ;");
            AddEmployeesOptions = dBManager.CustomQuery($"SELECT FName+' '+LName, EmployeeID FROM Personal, Employee WHERE EmployeeID = id AND PMID = {pmid} AND id NOT IN (SELECT EID FROM Works_On WHERE PID = {id});");
        }

        public ViewModel(ILogger<IndexModel> logger, DBManager db)
        {
            _logger = logger;
            dBManager = db;
        }

        public async Task<IActionResult> OnPostAdd()
        {
            int id = EID;
            
            dBManager.CustomNonQuery($"INSERT INTO Works_On VALUES ({ID}, {id},0)");
            
            return RedirectToPage("View");
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            Console.WriteLine("I was here");
            Console.WriteLine("Name: "+p.Name+ "id is "+ID);

            dBManager.CustomNonQuery($"UPDATE Project SET PName='{p.Name}', PDescription='{p.Description}',PGoal='{p.Goal}', DeadLine = '{p.Deadline}', Status_='{p.Status}',Progress_Percentage={p.ProgPercent} WHERE ID = {ID} ;");

            return RedirectToPage("../Project");

        }

    }
}
