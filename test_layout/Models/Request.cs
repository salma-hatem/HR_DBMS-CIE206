using System.ComponentModel.DataAnnotations;

namespace test_layout.Models
{
    public class Request
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int ApprovedBy { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
    }
}
