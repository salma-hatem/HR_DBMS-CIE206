namespace HR_DBMS.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Locartion { get; set; }

        public TimeOnly Time { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public Training() { }   
    }
}
