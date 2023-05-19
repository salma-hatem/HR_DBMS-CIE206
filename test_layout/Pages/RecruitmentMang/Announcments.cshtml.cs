using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test_layout.Models;
using System.Data;

namespace HR_DBMS.Pages.RecruitmentMang
{
    public class AnnouncmentsModel : PageModel
    {
		public readonly DBManager Db;
		[BindProperty]
		public int Id { get; set; }
		[BindProperty]
		public string text { get; set; }
		[BindProperty]
		public string Date { get; set; }
		[BindProperty]
		public int MID { get; set; }
		[BindProperty]
		public DataTable Announcments { get; set; }

        public AnnouncmentsModel(DBManager db)
        {
			Db = db;

        }
        public void OnGet()
		{
			//Announcments = (DataTable)Db.ReadTables("Announcements");
			Announcments = (DataTable)Db.JoinTablesWithCondition("Announcements as A", "Personal as P", "P.Person_IMG,FName+' '+LName, A.Mgs_text, Mgs_Date", "A.M_ID", "P.id","''","''");
		}
		public IActionResult OnPostSend()
		{
			return RedirectToPage("/RecruitmentMang/Employees");
		}
	}
}
