using System.ComponentModel.DataAnnotations;

namespace HR_DBMS.Models
{
	public class Project
	{
		public int ID { get; set; }

        [Required,MinLength(3)]
		public string Name { get; set; }
        public int ManagedBy { get; set; }
        [Required]
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Deadline { get; set; }
        public string Status { get; set; }
        public int ProgPercent { get; set; }
        
        public string Description { get; set; } 
        public string Goal { get; set; }
    }
}
