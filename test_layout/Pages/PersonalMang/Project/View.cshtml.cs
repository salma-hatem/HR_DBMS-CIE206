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

        public DataTable Project { get; set; }

        [BindProperty(SupportsGet = true)]

        public DataTable Employees { get; set; }

        [BindProperty(SupportsGet = true)]

        public DataTable AddEmployeesOptions { get; set; }


        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        public void OnGet(int id)
        {
            int pmid = dBManager.getCurrentUser();
            Console.WriteLine(pmid);
            this.ID = id;
            Project = dBManager.CustomQuery($"SELECT * FROM Project WHERE ID = {id};");
            Employees = dBManager.CustomQuery($"SELECT W.EID,FName,Person_role,Time_Spent FROM Works_On AS W, Personal AS P WHERE W.PID= {id} AND EID =id ;");
            AddEmployeesOptions = dBManager.CustomQuery($"SELECT FName+' '+LName FROM Personal, Employee WHERE EmployeeID = id AND PMID = {pmid} AND id NOT IN (SELECT EID FROM Works_On WHERE PID = {id});");
        }

        public ViewModel(ILogger<IndexModel> logger, DBManager db)
        {
            _logger = logger;
            dBManager = db;
        }
    }
}
