using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.TrainingMang
{
    public class TrainingsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public readonly DBManager DB;


        [BindProperty]
        public DataTable CurrTraining_times { get; set; }
        [BindProperty]
        public DataTable PrevTraining_times { get; set; }

        [BindProperty]
        public DataTable CurrentTimes { get; set; }

        [BindProperty]
        public DataTable PrevTimes { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public TrainingsModel(DBManager dB)
        {
            DB = dB;
            ID = DB.GetCurrentUserID();
            CurrentTimes = new DataTable();
            CurrentTimes.Clear();
            CurrentTimes.Columns.Add("Start");
            CurrentTimes.Columns.Add("End");

            PrevTimes = new DataTable();
            PrevTimes.Clear();
            PrevTimes.Columns.Add("Start");
            PrevTimes.Columns.Add("End");


        }
        public void OnGet()
        {
            
            CurrTraining_times = (DataTable)DB.getPrevTraining("Training_Date as TD", "Training as T", "T.ID,Training_Name,Training_Location,Training_Description,Training_Time,Training_StartDate ,Training_EndDate",
                "TD.ID", "T.ID","Training_EndDate",">"); 
            PrevTraining_times = (DataTable)DB.getPrevTraining("Training_Date as TD", "Training as T", "T.ID,Training_Name,Training_Location,Training_Description,Training_Time,Training_StartDate ,Training_EndDate",
                "TD.ID", "T.ID", "Training_EndDate", "<");
            for (int i = 0; i <CurrTraining_times.Rows.Count; i++)
            {

                StartDate = (DateTime)CurrTraining_times.Rows[i][5];
                EndDate = (DateTime)CurrTraining_times.Rows[i][6];


                DataRow _ravi = CurrentTimes.NewRow();
                _ravi["Start"] = StartDate.ToString("dd/MM/yyyy"); ;
                _ravi["End"] = EndDate.ToString("dd/MM/yyyy"); ;
                CurrentTimes.Rows.Add(_ravi);
                //Times.Rows[i][1] = EndDate;    


            }

            for (int i = 0; i < PrevTraining_times.Rows.Count; i++)
            {

                StartDate = (DateTime)PrevTraining_times.Rows[i][5];
                EndDate = (DateTime)PrevTraining_times.Rows[i][6];


                DataRow _ravi = PrevTimes.NewRow();
                _ravi["Start"] = StartDate.ToString("dd/MM/yyyy"); ;
                _ravi["End"] = EndDate.ToString("dd/MM/yyyy"); ;
                PrevTimes.Rows.Add(_ravi);
                //Times.Rows[i][1] = EndDate;    


            }


        }
    }
}
