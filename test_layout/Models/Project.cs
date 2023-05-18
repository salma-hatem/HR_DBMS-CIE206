using System.ComponentModel.DataAnnotations;

namespace test_layout.Models
{
	public class Project
	{
		public int ID { get; set; }

        [Required,MinLength(3)]
		public string Name { get; set; }
        public int ManagedBy { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        public string Deadline { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int ProgPercent { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Goal { get; set; }
    }
}
