using System.ComponentModel.DataAnnotations;
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
        //[BindProperty]
        //public Request request { get; set; }
        public int RID { get; set; }
        public int EmployeeID { get; set; }
        public int ApprovedBy { get; set; }
        public string Status { get; set; }
        [BindProperty]
        public string Type { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        public RequestModel(DBManager dBManager)
        {
            this.dBManager = dBManager;
        }
        public void OnGet()
        {
            //request = new Request();
        }
        public IActionResult OnPostSubmit()
        {
            EmployeeID = ID;
            ApprovedBy = dBManager.ExcuteScalarINT("Employee", "PMID", "EmployeeID", Convert.ToString(ID));
            Status = "Pending";
            RID = dBManager.GetMaxID("Requests") + 1;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) 
            {
                dBManager.AddRecordRequest(RID, Type,Status, Description, EmployeeID, ApprovedBy);
                return RedirectToPage("/Employee/Home", new { ID = this.ID });
            }
            else
                return Page();
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Employee/Home", new { ID = this.ID });
        }
    }
}
