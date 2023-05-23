using System.Data;
using test_layout.Models;

namespace HR_DBMS.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }

     //   public TimeOnly Time { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Created_BY { get; set; }

        public int Status { get; set; }

        public readonly DBManager DB;
        public DataTable TrainingTable { get; set; }
        public Training(DBManager db) { 
        
            DB = db;
            TrainingTable = DB.ReadTables("Training");
        }   
    }
}
