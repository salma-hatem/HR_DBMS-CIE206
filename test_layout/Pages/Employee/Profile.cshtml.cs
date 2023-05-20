using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.Employee
{
    public class ProfileModel : PageModel
    {
        public readonly DBManager DB;

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int age { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty]
        public string Job { get; set; }

        [BindProperty]
        public string Team { get; set; }

        [BindProperty]
        public string address { get; set; }



        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string Doc_Name { get; set; }

        [BindProperty]
        public string Doc_Type { get; set; }

        [BindProperty]
        public int Doc_Size { get; set; }
        public DataTable info { get; set; }

        public DataTable documents { get; set; }

        public ProfileModel(DBManager dB)
        {
            DB = dB;
            ID = DB.GetCurrentUserID();
        }
        public void OnGet()
        {
            info = (DataTable)DB.ReadTablesWithConditon("Personal", "concat(Fname,' ', LName) , Age,Person_Role,Team,Person_Address,Work_Email", "id", ID.ToString());
            Name = (string)info.Rows[0][0];
            age = (int)info.Rows[0][1];
            Job = (string)info.Rows[0][2];
            Team = (string)info.Rows[0][3];
            address = (string)info.Rows[0][4];
            email = (string)info.Rows[0][5];

            documents = (DataTable)DB.ReadTablesWithConditon("Documents", "Doc_Name,Doc_Type,Doc_ize", "PersonID", ID);
        }
    }
}
