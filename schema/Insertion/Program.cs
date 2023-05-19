
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace HelloWorld
{

    public class Insertion
    {
        private int ssn { get; set; }
        private int[] id { get; set; }
        private string query { get; set; }

        private string[] requests = { "Leave", "Bonus", "Vacation", "Promotion", "Training", "Salary", "Problem" };
        private string[] FemaleNames = { "Emily", "Hannah", "Madison", "Ashley", "Sarah", "Alexis", "Samantha", "Jessica", "Elizabeth", "Taylor", "Lauren", "Alyssa", "Kayla", "Abigail", "Brianna", "Olivia", "Emma", "Megan", "Grace", "Victoria", "Rachel", "Anna", "Sydney", "Destiny", "Morgan", "Jennifer", "Jasmine", "Haley", "Julia", "Kaitlyn", "Nicole", "Amanda", "Katherine", "Natalie", "Hailey", "Alexandra", "Savannah", "Chloe" };
        private string[] MaleNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White", "Lopez", "Lee", "Gonzalez", "Harris", "Clark", "Lewis", "Robinson", "Walker", "Perez", "Hall", "Young", "Allen", "Sanchez", "Wright", "King", "Scott", "Green", "Baker", "Adams", "Nelson", "Hill", "Ramirez", "Campbell", "Mitchell", "Roberts", "Carter", "Phillips", "Evans", "Turner", "Torres", "Parker", "Collins", "Edwards", "Stewart", "Flores", "Morris", "Nguyen", "Murphy", "Rivera", "Cook", "Rogers", "Morgan", "Peterson", "Cooper", "Reed", "Bailey", "Bell", "Gomez", "Kelly", "Howard", "Ward", "Cox", "Diaz", "Richardson", "Wood", "Watson", "Brooks", "Bennett", "Gray", "James", "Reyes", "Cruz", "Hughes", "Price", "Myers", "Long", "Foster", "Sanders", "Ross", "Morales", "Powell", "Sullivan", "Russell", "Ortiz", "Jenkins", "Gutierrez", "Perry", "Butler", "Barnes", "Fisher", "Henderson", "Coleman", "Simmons", "Patterson", "Jordan", "Reynolds", "Hamilton", "Graham", "Kim", "Gonzales", "Alexander", "Ramos", "Wallace", "Griffin", "West", "Cole", "Hayes", "Chavez", "Gibson", "Bryant", "Ellis", "Stevens", "Murray", "Ford", "Marshall", "Owens", "McDonald", "Harrison", "Ruiz", "Kennedy", "Wells", "Alvarez", "Woods", "Mendoza", "Castillo", "Olson", "Webb", "Washington", "Tucker", "Freeman", "Burns", "Henry", "Vasquez", "Snyder", "Simpson", "Crawford", "Jimenez", "Porter", "Mason", "Shaw", "Gordon", "Wagner", "Hunter", "Romero", "Hicks", "Dixon", "Hunt", "Palmer", "Robertson", "Black", "Holmes", "Stone", "Meyer", "Boyd", "Mills", "Warren", "Fox", "Rose", "Rice", "Moreno", "Schmidt", "Patel", "Ferguson", "Nichols", "Herrera", "Medina", "Ryan" };

        private string[] cities = { "Cairo", "Giza", "Alexandria", "Dakahlia", "Red Sea", "Beheira", "Fayoum", "Gharbiya", "Ismailia" };
        private string[] roles = {
  "Academic Librarian",
  "Accountant",
  "Accounting Technician",
  "Actuary",

  "Charities Fundraiser",
  "Chemical (Process) Engineer",
  "Child PsychoTherapist",
  "Children's Nurse",
  "Chiropractor",
  "Civil Engineer",
  "Civil Service Administrator",
  "Clinical Biochemist",
  "Clinical Cytogeneticist",
  "Clinical Microbiologist",
  "Clinical Molecular Geneticist",
  "Clinical Research Associate",
  "Clinical Scientist",
  "Clothing Technologist",

  "Consumer Rights Adviser",
  "Control and Instrumentation Engineer",
  "Corporate Banker",

  "Environmental Education Officer",
  "Environmental Health Officer",
  "Environmental Manager",
  "Environmental Scientist",
  "Equal Opportunities Officer",
  "Equality and Diversity Officer",
  "Ergonomist",
  "Estate Agent",
  "Estimator",
  "European Commission Administrators",

  "Food Scientist",
  "Food Technologist",
  "Forensic Scientist",
  "Freight Forwarder",
  "Geneticist",
  "Geographical Information Systems Manager",
  "Geomatics/Land Surveyor",
  "Government Lawyer",
  "Government Research Officer",
  "Graphic Designer",
  "Health and Safety Adviser",
  "Health and Safety Inspector",
  "Health Promotion Specialist",

  "Illustrator",
  "Immigration Officer",
  "Immunologist",
  "Industrial/Product Designer",
  "Information Scientist",
  "Information Systems Manager",
  "Information Technology/Software Trainers",
  "Insurance Broker",
  "Insurance Claims Inspector",
  "Insurance Risk Surveyor",
  "Insurance Underwriter",
  "Interpreter",
  "Investment Analyst",
  "Investment Banker - Corporate Finance",
  "Investment Banker - Operations",
  "Investment FUnd Manager",
  "IT Consultant",
  "IT Support Analyst",
  "Journalist",
  "Laboratory Technician",
  "Land-based Engineer",
  "Landscape Architect",
  "Learning Disability Nurse",
  "Learning Mentor",
  "Lecturer (Adult Education)",
  "Lecturer (Further Education)",
  "Lecturer (Higher Education)",
  "Legal Executive",
  "Leisure Centre Manager",
  "Licensed Conveyancer",
  "Local Government administrator",
  "Local Government lawyer",
  "Logistics/Distribution Manager",
  "Magazine Features Editor",
  "Magazine Journalist",
  "Maintenance Engineer",
  "Management accountant",
  "Manufacturing Engineer",
  "Manufacturing Machine Operator",
  "Manufacturing Toolmaker",
  "Marine Scientist",
  "Market Research Analyst",
  "Market Research Executive",
  "Marketing Assistant",
  "Marketing Executive",
  "Marketing Manager (Direct)",
  "Marketing Manager (Social Media)",
  "Materials Engineer",
  "Materials Specialist",
  "Mechanical Engineer",
  "Media Analyst",
  "Media Buyer",
  "Media Planner",



  "Psychologist (Educational)",
  "PsychoTherapist",
  "Public Affairs Consultant (Lobbyist)",
  "Public Affairs Consultant (Research)",
  "Public House Manager",
  "Public Librarian",
  "Public Relations (PR) Officer",
  "QA Analyst",
  "Quality Assurance Manager",
  "Quantity Surveyor",
  "Records Manager",
  "Recruitment Consultant",
  "Recycling Officer",
  "Regulatory Affairs Officer",
  "Research Chemist",
  "Research Scientist",
  "Restaurant Manager",
  "Retail Banker",
  "Retail Buyer",
  "Retail Manager",
  "Retail Merchandiser",
  "Retail Pharmacist",
  "Sales Executive",
  "Scene of Crime Officer",
  "Secretary",
  "Seismic Interpreter",
  "Site Engineer",
  "Site Manager",
  "Social Researcher",
  "Social Worker",
  "Software Developer",
  "Software Engineer",
  "Soil Scientist",
  "Solicitor",
  "Speech and Language Therapist",
  "Sports Coach",
  "Sports Development Officer",
  "Sports Therapist",
  "Statistician",
  "Stockbroker",
  "Structural Engineer",
  "Systems Analyst",
  "Systems Developer",
  "Toxicologist",
  "Trade Union Official",
  "Trade Union Research Officer",
  "Trader",
  "Trading Standards Officer",
  "Training and Development Officer",
  "Translator",
  "Transportation Planner",
  "Travel Agent",
  "TV/Film/Theatre Set Designer",
  "UX Designer",
  "Validation Engineer",
  "Veterinary Nurse",
  "Veterinary Surgeon",
  "Video Game Designer",
  "Video Game Developer",
  "Volunteer Work Organiser",
  "Waste Management Officer",
  "Water Conservation Officer",
  "Water Engineer",
  "Web Designer",
  "Web Developer",
  "Welfare Rights Adviser",
  "Writer",
  "Youth Worker" };
        public void populateDB(string cs)
        {
            string ConString = cs;
            SqlConnection con = new SqlConnection(ConString);

            int ml = MaleNames.Length ;
            int fl = FemaleNames.Length ;

            Random rnd = new Random();
            query = "INSERT INTO Personal" +
                " (id ,SSN ,Team ,Sex ,FName ,LName,Age ,Email ,Work_Email ,Person_Password ,Person_Address ,Person_Status ,Salary ,Person_Role ,Contact_Num ,Person_IMG ,Holidays) " +
                " VALUES ";
            // Creating 100 Persons //
            for (int i = 0; i < 100; i++)
            {
                int MaleORFemale = rnd.Next(2);
                int age = rnd.Next(20, 40);
                string fname;
                string gender;
                if (MaleORFemale == 1)
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

                string email = id[i] + fname + "@gmail.com";

                string work_email = "w-" + email;

                string password = "123";

                int city = rnd.Next(cities.Length);

                string Adress = cities[city];

                double salary = rnd.Next(10000, 90000);

                int role = rnd.Next(roles.Length);

                int contact = rnd.Next(123456, 12999999);
                int holidays = rnd.Next(10);

                query += $"({id[i]},{ssn},'Team A','{gender}','{fname}' ,'{lname}' ,{age},'{email}','{work_email}', '{password}', '{Adress}', 'working',{salary}, '{roles[role]}',{contact},'/assets/image/{i}/profile.jpg', {holidays} )";
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
                Console.WriteLine("Error in Person");
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
                    Console.WriteLine("error in MANGERS");
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
                    Console.WriteLine("Error in Personal Manager");
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
            //Attendance 30 per person Around 30 X 100 = 3000 records
            for (int i = 0; i < 100; i++)
            {
                for (int j = 30; j > 0; j--)
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

            // Projects
            string[] pnames = { "Dora the Explora", "We are Fraud", "We need Bonus", "Need Help", "Consult your mommy", "Project Mathew", "Project Officer K", "The Promised Never Land", "Attack on Uni" };
            for (int i = 0; i < 50; i++)
            {
                int per = rnd.Next(100);
                int pname = rnd.Next(pnames.Length);
                string s;
                if (per == 100) s = "Finished";
                if (per > 70) s = "Almost Done";
                else if (per > 40) s = "Working";
                else s = "Just Started";
                int pid = rnd.Next(9);
                query = $"INSERT INTO Project(ID ,PName,PDescription ,PGoal ,StartDate ,DeadLine ,Status_ ,Progress_Percentage ,PMID) VALUES({i},'{pnames[pname] + i}','This is discription','This is goal',GETDATE()+{i},GETDATE()+60,'{s}',{per},{pid}) ";
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

            for (int i = 0; i < 200; i++)
            {
                int eid = rnd.Next(20, 99);
                int time = rnd.Next(50);
                int pid = rnd.Next(50);
                query = $"INSERT INTO Works_on(PID,EID,Time_spent) VALUES ({pid},{eid},{time})";

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Will not Add works on of id = " + eid + "+" + pid);
                }
                finally
                {
                    con.Close();
                }

            }
            string[] doctype = { "PDF", "JPG", ".DOX", ".M" };
            string[] docname = { "Birth Certificate", "Educational Transcript" };
            int Did = 0;

/*            // Documents 
            for (int i = 0; i < 200; i++)
            {
                query = $"INSERT INTO Documents VALUES ";
                for (int j = 0; j < 3; j++)
                {

                    query += $"({Did},'{doctype[i % 4]}','100MB','{docname[i % 2]}',{i})";
                    Did++;
                    if (j < 2) { query += ','; }
                }
                query += ';';
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error in Documents Part");
                }
                finally
                {
                    con.Close();
                }

            }*/

            // Bonuses and Penalties //
            for (int i = 0; i < 100; i++)
            {
                int eid = rnd.Next(20, 99);
                int bonus = rnd.Next(-20, 20);
                string type;
                if (bonus > 0) type = "Bonus";
                else type = "Penalty";


                query = $"INSERT INTO PenaltiesBonuses(ID,Type_,Percentage_Change,EmployeeID,Given_by) VALUES ({i},'{type}',{bonus},{eid},(SELECT PMID FROM Employee WHERE EmployeeID={eid}));";

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error in Bonus");
                }
                finally
                {
                    con.Close();
                }

            }

            // Requests //
            for (int i = 0; i < 100; i++)
            {
                int eid = rnd.Next(20, 99);

                int type = rnd.Next(requests.Length) ;


                query = $"INSERT INTO Requests VALUES({i},'{requests[type]}','Pending','Pleaseeeee',{eid}, (SELECT PMID FROM Employee WHERE EmployeeID={eid}))";

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error in Request Insertion");
                }
                finally
                {
                    con.Close();
                }

            }
            // Insert Curren User
            query = $"INSERT INTO CurrentUser VALUES(-1);";
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error in Current user");

            }
            finally
            {
                con.Close();
            }
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

