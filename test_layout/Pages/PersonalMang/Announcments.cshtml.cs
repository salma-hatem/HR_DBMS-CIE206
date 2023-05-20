using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.PersonalMang
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
			MID = Db.GetCurrentUserID();
			Id = Db.getAnnouncmentId();
		}
		public void OnGet()
		{
			//Announcments = (DataTable)Db.ReadTables("Announcements");
			Announcments = (DataTable)Db.JoinTablesWithCondition("Announcements as A", "Personal as P", "P.Person_IMG,FName+' '+LName, A.Mgs_text, Mgs_Date", "A.M_ID", "P.id", "''", "''");
		}
		public IActionResult OnPostSend()
		{

			Db.AddAnnouncment(Id, text, "2-10-2023", MID);
			return RedirectToPage("/RecruitmentMang/Announcments");

		}
	}
}
