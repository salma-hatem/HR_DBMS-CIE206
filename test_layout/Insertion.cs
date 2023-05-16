using Microsoft.Data.SqlClient;


namespace HR_DBMS
{
    public class Insertion
    {
        private int ssn { get; set; }
        private int[] id { get; set; }
        private string query { get; set; }

        private string[] Names = {"William",
            "James",
            "Noah",
            "Benjamin",
            "Emma",
            "Olivia",
            "Alexander",
            "David",
            "Henry",
            "Michael",
            "Oliver",
            "Mia",
            "Elizabeth",
            "Anthony",
            "Jack",
            "Evelyn",
            "Theodore",
            "Liam",
            "Amelia",
            "Isabella",
            "Andrew",
            "Lucas"};

        private string[] roles = { "Accountant", "Helper", "Delivery", "Staff" };
        public void populateDB()
        {
            string ConString = @"Data Source=OPTIPLEX;Initial Catalog=HR_DBMS;Integrated Security=True";


            SqlConnection con = new SqlConnection(ConString);



            Random rnd = new Random();
            query = "INSERT INTO Personal" +
                " (id ,SSN ,Team ,Sex ,FName ,LName,Age ,Email ,Work_Email ,Person_Password ,Person_Address ,Person_Status ,Salary ,Person_Role ,Contact_Num ,Person_IMG ,Holidays) " +
                " VALUES ";
            // Creating 100 Persons //
            for (int i = 0; i < 100; i++)
            {
                int age = rnd.Next(20, 40);
                string fname = Names[i % 22];
                string lname = Names[(i + 2) % 22];
                string email = Names[i % 22] + "@gmail.com";
                string work_email = "w-" + email;
                string password = "123";
                string Adress = "street-" + lname;
                double salary = rnd.Next(10000, 90000);
                string role = roles[i % 4];
                int contact = rnd.Next(123456, 12999999);
                int holidays = rnd.Next(10);

                query += $"({id[i]},{ssn},'Team A','Male','{fname}' ,'{lname}' ,{age},'{email}','{work_email}', '{password}', '{Adress}', 'working',{salary}, '{role}',{contact},'/assets/image/{i}/profile.jpg', {holidays} )";
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

            int attendance_id = 0;
            //Attendance 3 per person
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    query = $"INSERT INTO Attendance (id ,Atendance_Date, Person_id) VALUES ({attendance_id} ,'2008 -09 -0{j + 1}', {i} )";
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
                query = $"INSERT INTO Training(ID ,Training_Name ,Training_Location ,Created_by ,Training_Description) VALUES ({tid},'{tnames}','Madii', {traineer},'Blablablab')";
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
            for (int i = 20; i < 70; i++)
            {
                int time = rnd.Next(100);
                query = $"INSERT INTO Attend_Training(TrainingID,E_ID,Time_Spent) VALUES({i % 5},{i},{time})";

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

            string[] choose = { "Working", "Just Started", "Almost Done", "Finished" };
            for (int i = 0; i < 50; i++)
            {
                int per = rnd.Next(100);
                int pid = rnd.Next(9);
                query = $"INSERT INTO Project(ID ,PName,PDescription ,PGoal ,StartDate ,DeadLine ,Status_ ,Progress_Percentage ,PMID) VALUES({i},'Name{i}','This is discription','This is goal','20240618 10:34:09 AM','20240618 10:34:09 AM','{choose[i % 3]}',{per},{pid}) ";
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
            for (int i = 0; i < 50; i++)
            {
                int eid = rnd.Next(19, 99);
                int time = rnd.Next(50);
                int pid = rnd.Next(9);
                query = $"INSERT INTO Works_on(PMID,EID,Time_spent) VALUES ({pid},{eid},{time})";
            }

        }

        public Insertion()
        {
            ssn = 123456789;
            query = "";
            id = Enumerable.Range(0, 100).ToArray();
        }
    }
}