
using System.Data.SqlClient;

namespace HelloWorld
{

    public class Insertion
    {
        private int ssn { get; set; }
        private int[] id { get; set; }
        private string query { get; set; }

        private string[] requests = { "Leave", "Bonus", "Vacation", "Promotion", "Training", "Salary","Problem" };
        private string[] FemaleNames =  {"Emily", "Hannah", "Madison", "Ashley", "Sarah", "Alexis", "Samantha", "Jessica", "Elizabeth", "Taylor", "Lauren", "Alyssa", "Kayla", "Abigail", "Brianna", "Olivia", "Emma", "Megan", "Grace", "Victoria", "Rachel", "Anna", "Sydney", "Destiny", "Morgan", "Jennifer", "Jasmine", "Haley", "Julia", "Kaitlyn", "Nicole", "Amanda", "Katherine", "Natalie", "Hailey", "Alexandra", "Savannah", "Chloe"};
        private string[] MaleNames = {"Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White", "Lopez", "Lee", "Gonzalez", "Harris", "Clark", "Lewis", "Robinson", "Walker", "Perez", "Hall", "Young", "Allen", "Sanchez", "Wright", "King", "Scott", "Green", "Baker", "Adams", "Nelson", "Hill", "Ramirez", "Campbell", "Mitchell", "Roberts", "Carter", "Phillips", "Evans", "Turner", "Torres", "Parker", "Collins", "Edwards", "Stewart", "Flores", "Morris", "Nguyen", "Murphy", "Rivera", "Cook", "Rogers", "Morgan", "Peterson", "Cooper", "Reed", "Bailey", "Bell", "Gomez", "Kelly", "Howard", "Ward", "Cox", "Diaz", "Richardson", "Wood", "Watson", "Brooks", "Bennett", "Gray", "James", "Reyes", "Cruz", "Hughes", "Price", "Myers", "Long", "Foster", "Sanders", "Ross", "Morales", "Powell", "Sullivan", "Russell", "Ortiz", "Jenkins", "Gutierrez", "Perry", "Butler", "Barnes", "Fisher", "Henderson", "Coleman", "Simmons", "Patterson", "Jordan", "Reynolds", "Hamilton", "Graham", "Kim", "Gonzales", "Alexander", "Ramos", "Wallace", "Griffin", "West", "Cole", "Hayes", "Chavez", "Gibson", "Bryant", "Ellis", "Stevens", "Murray", "Ford", "Marshall", "Owens", "McDonald", "Harrison", "Ruiz", "Kennedy", "Wells", "Alvarez", "Woods", "Mendoza", "Castillo", "Olson", "Webb", "Washington", "Tucker", "Freeman", "Burns", "Henry", "Vasquez", "Snyder", "Simpson", "Crawford", "Jimenez", "Porter", "Mason", "Shaw", "Gordon", "Wagner", "Hunter", "Romero", "Hicks", "Dixon", "Hunt", "Palmer", "Robertson", "Black", "Holmes", "Stone", "Meyer", "Boyd", "Mills", "Warren", "Fox", "Rose", "Rice", "Moreno", "Schmidt", "Patel", "Ferguson", "Nichols", "Herrera", "Medina", "Ryan"};

        private string[] cities = { "Cairo", "Giza", "Alexandria", "Dakahlia", "Red Sea", "Beheira", "Fayoum", "Gharbiya", "Ismailia" };
        private string[] roles = { "Accountant", "Helper", "Delivery", "Staff" };
        public void populateDB(string cs)
        {
            string ConString = cs;
            SqlConnection con = new SqlConnection(ConString);

            int ml = MaleNames.Length;
            int fl = FemaleNames.Length;

            Random rnd = new Random();
            query = "INSERT INTO Personal" +
                " (id ,SSN ,Team ,Sex ,FName ,LName,Age ,Email ,Work_Email ,Person_Password ,Person_Address ,Person_Status ,Salary ,Person_Role ,Contact_Num ,Person_IMG ,Holidays) " +
                " VALUES ";
            // Creating 100 Persons //
            for (int i = 0; i < 100; i++)
            {
                int MaleORFemale = rnd.Next(1);
                int age = rnd.Next(20, 40);
                string fname;
                string gender;
                if(MaleORFemale==1)
                {
                    fname = MaleNames[i % ml];
                    gender = "Male";
                }
                else
                {
                    fname = FemaleNames[i % fl];
                    gender = "Female";
                }
                
                string lname = MaleNames[(i + 2) % ml];

                string email = fname+ "@gmail.com";

                string work_email = "w-" + email;

                string password = "123";

                int city = rnd.Next(cities.Length);

                string Adress = cities[city];

                double salary = rnd.Next(10000,90000);

                string role = roles[i % 4];

                int contact = rnd.Next(123456, 12999999);
                int holidays = rnd.Next(10);

                query += $"({id[i]},{ssn},'Team A','{gender}','{fname}' ,'{lname}' ,{age},'{email}','{work_email}', '{password}', '{Adress}', 'working',{salary}, '{role}',{contact},'/assets/image/{i}/profile.jpg', {holidays} )";
                ssn++;
                if (i < 99) { query += ","; }

            }
            query += ";";

            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
                

            }

            // There are 20 managers and 80 employees
            for (int i = 0; i < 20; i++)
            {
                query = $"INSERT INTO Manager (Manager_ID) VALUES ({i})";
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            //IDs From 1 to 9 are Personal Managers
            for (int i = 0; i < 10; i++)
            {
                query = $"INSERT INTO Personal_Manager (Personal_Mang_ID) VALUES ({i})";
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            //From 9-14 are RMs
            for (int i = 10; i < 15; i++)
            {
                query = $"INSERT INTO Recruitment_Manager (Recruitment_Mang_ID) VALUES ({i})";
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            //From 14-19 are TMs
            for (int i = 15; i < 20; i++)
            {
                query = $"INSERT INTO Training_Manager(Training_Mang_ID) VALUES ({i})";
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            // 80 employees
            for (int i = 20; i < 100; i++)
            {
                int pid = rnd.Next(0, 9);
                int rid = rnd.Next(10, 14);
                query = $"INSERT INTO Employee (EmployeeID,PMID,RMID) VALUES ({i},{pid},{rid} )";
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            int attendance_id=0;
            //Attendance 30 per person Around 30 X 100 = 3000 records
            for(int i =0; i<100;i++)
            {
                for(int j=30;j>0;j--)
                {
                    query = $"INSERT INTO Attendance (id ,Atendance_Date, Person_id) VALUES ({attendance_id} ,'2023-05-{j}', {i} )";
                    attendance_id++;
                    try
                    {

                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            // 5 Trainings //
            int tid = 0;
            string[] tnames = { "Leadership", "Project Managment", "Crypto security", "Signals Control", "Advanced Loving Family" };
            for (int j = 0; j < 5; j++)
            {
                int traineer = rnd.Next(15, 20);
                int city = rnd.Next(cities.Length);
                query = $"INSERT INTO Training(ID ,Training_Name ,Training_Location ,Created_by ,Training_Description) VALUES ({tid},'{tnames[j]}','{cities[city]}', {traineer},'Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')";
                tid++;
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            // 50 goes to training //
            for(int i =20; i<70;i++)
            {
                int time = rnd.Next(100);
                query = $"INSERT INTO Attend_Training(TrainingID,E_ID,Time_Spent) VALUES({i%5},{i},{time})";

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            for(int i =0; i<50;i++)
            {
                int per = rnd.Next(100);
                string s;
                if (per > 70) s = "Almost Done";
                else if (per > 40) s = "Working";
                else s = "Just Started";
                int pid = rnd.Next(9);
                query = $"INSERT INTO Project(ID ,PName,PDescription ,PGoal ,StartDate ,DeadLine ,Status_ ,Progress_Percentage ,PMID) VALUES({i},'Name{i}','This is discription','This is goal',GETDATE()+{i},GETDATE()+60,'{s}',{per},{pid}) ";
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }

            
            // Works on //
            for (int i = 0; i < 100;i++)
            {
                int eid = rnd.Next(19,99);
                int time = rnd.Next(50);
                int pid = rnd.Next(9);
                query = $"INSERT INTO Works_on(PMID,EID,Time_spent) VALUES ({pid},{eid},{time})";

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Will not Add works on of id = "+eid+"+"+pid);
                }
                finally
                {
                    con.Close();
                }

            }

/*            // Bonuses and Penalties //
            for (int i = 0; i < 100; i++)
            {
                int eid = rnd.Next(19, 99);
                int bonus = rnd.Next(-100,100);
                string type;
                if (bonus > 0) type = "Bonus";
                else type = "Penalty";

                int pid = rnd.Next(9);
                query = $"INSERT INTO PenaltiesBonuses(ID,Type_,Percentage_Change,EmployeeID,Given_by) VALUES ({i},'{type}',{bonus},{eid},{pid});";

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }

            }*/

            // Requests //
/*            for (int i = 0; i < 100; i++)
            {
                int eid = rnd.Next(19, 99);

                int type = rnd.Next(requests.Length);


                query = $"INSERT INTO Requests (ID,R_Type,R_Status,R_Description,EmployeeID) VALUES ({i},'{requests[type]}','Pending','Breif Description',{eid} );";

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    con.Close();
                }

            }*/
        }

        public Insertion()
        {
            ssn = 123456789;
            query = "";
            id = Enumerable.Range(0, 100).ToArray(); ;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Insertion it = new Insertion();
            
            // Add your own connection string //

            it.populateDB(@"Data Source=OPTIPLEX;Initial Catalog=HR_DBMS;Integrated Security=True");

            
        }
    }
}

