using System.ComponentModel.DataAnnotations;

namespace test_layout.Models
{
    public class User
    {
        [Required]
        public int ID { get; set; }
        public int SSN { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Work_Email { get; set; }
        public string Team { get; set; }
        public int Contacts { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public int Salary { get; set; }
        // i think we will need to add this
        public int Type { get; set; }
    }
}
