using System.ComponentModel.DataAnnotations;

namespace test_layout.Models
{
    public class Request
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        [Required]
        public int? ApprovedBy { get; set; }
        public string Status { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
