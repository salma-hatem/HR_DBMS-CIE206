using HR_DBMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using test_layout.Models;

namespace HR_DBMS.Pages.TrainingMang
{
    public class HomeModel : PageModel
    {
        //   public int Attendance { get; set; }

        //  public readonly  Training TR;

        public readonly DBManager DB;

      //  public readonly Training TR;
        public DataTable Trainings { get; set; }

        [BindProperty]
        public DataTable Training_times { get; set; }
        [BindProperty]
        public int PrevTrainings { get; set; }
        [BindProperty]
        public int CurrTrainings { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty]
        public int Attendance { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [BindProperty]
        public DataTable StartTimes { get; set; }


        public HomeModel(DBManager dB  )
        {

            DB = dB;
            ID = DB.GetCurrentUserID();
            StartTimes = new DataTable();
            StartTimes.Clear();
            StartTimes.Columns.Add("Start");
            StartTimes.Columns.Add("End");
          
            //  TR = tr;


        }
        public void OnGet()
        {
          //  ID = id;
            CurrTrainings = DB.ExcuteTrainingINT(">");
            PrevTrainings = DB.ExcuteTrainingINT("<");
            Attendance = DB.ExcuteScalarINT("Attendance", "COUNT(*)", "ID", ID.ToString());
            Trainings = (DataTable)DB.getPrevTraining("Training_Date as TD", "Training as T", "T.ID,Training_Name,Training_Location, Training_Time,Training_StartDate ,Training_EndDate",
                "TD.ID", "T.ID", "Training_EndDate", ">");
            
          // Training_times = (DataTable)DB.ReadTablesfrom("Training_Date", " Training_StartDate,  Training_EndDate ");
            for (int i = 0; i < Trainings.Rows.Count; i++)
            {

                StartDate = (DateTime) Trainings.Rows[i][4];
                EndDate =(DateTime)Trainings.Rows[i][5];
                
                
                DataRow _ravi = StartTimes.NewRow();
                _ravi["Start"] = StartDate.ToString("dd/MM/yyyy"); ;
                _ravi["End"] = EndDate.ToString("dd/MM/yyyy"); ;
                StartTimes.Rows.Add(_ravi);
                //Times.Rows[i][1] = EndDate;    


            } 
           
        }
        public void OnPostDelete (int id)
        {
            DB.DeleteRecord("Training", id);

        }
    }
}
