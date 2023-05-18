using System.ComponentModel.DataAnnotations;

namespace HR_DBMS.Models
{
    public class ModelProject
    {
       
            public int ID { get; set; }

            [Required, MinLength(3)]
            public string Name { get; set; }
            public int ManagedBy { get; set; }
            
        
            public string StartDate { get; set; }

            [Required]
            public string EndDate { get; set; }
            public string Deadline { get; set; }
            
            public string Status { get; set; }
           
            public int ProgPercent { get; set; }

        [Required]
            public string Description { get; set; }
        [Required]
            public string Goal { get; set; }
        }
}

