using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace test_layout.Models
{
    public class DBManager

    {
        static string constring = "Data Source=DESKTOP-GKT48AV;Initial Catalog=HR_DBMS;Integrated Security=True;TrustServerCertificate=True";
     
        SqlConnection con = new SqlConnection(constring);
        
        /////////////////////////////// GET CURRENT USER ////////////////////
        public int getCurrentUser()
        {
            string result = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CurrentUser", con);
                result = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Int32.Parse(result);
        }




        ///////////////// Read Tables /////////////////
        public DataTable ReadTables(string tablename)
        {
            DataTable table = new DataTable();
            string query = "select * from " +tablename ;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }
        ///////////////// Find Record /////////////////
        public DataTable FindRecord(string tablename, int id)
        {
            DataTable table = new DataTable();
            string query = "select * from " + tablename + " where ID = " + id;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }
        ///////////////// Add Record /////////////////
        public void AddRecord(string tablename, int id, string name, string email, string username, string password, int type)
        {
            string query = "INSERT INTO " + tablename + " VALUES (@ID,@Name,@Email,@UserName,@Password,@Type)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Type", type);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void AddTraining(string tablename, int id, string name, string location, int created_by, string description)
        {
            string query = "INSERT INTO " + tablename + " VALUES (@ID,@Training_Name,@Training_Location ,@Created_by ,@Training_Description,@Training_Status )";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Training_Name", name);
            cmd.Parameters.AddWithValue("@Training_Location", location);
            cmd.Parameters.AddWithValue("@Created_by", created_by);
            cmd.Parameters.AddWithValue("@Training_Description", description);
            cmd.Parameters.AddWithValue("@Training_Status", 0);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void AddTrainingDate(string tablename, int id, DateTime time, DateTime startdate, DateTime enddate)
        {
            string query = "INSERT INTO " + tablename + " VALUES (@ID,@Training_Time,@Training_StartDate ,@Training_EndDate )";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Training_Time", time);
            cmd.Parameters.AddWithValue("@Training_StartDate", startdate);
            cmd.Parameters.AddWithValue("@Training_EndDate", enddate);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public int getTrainingID()
        {
            string query = "select MAX(ID) from Training";
            SqlCommand cmd = new SqlCommand(query, con);
            int ID = 0;
            try
            {
                con.Open();
                ID = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ID+1;
        }
        public void DeleteRecord(string tablename, int id)
        {
            int maxID = 0;
            string query = "delete from " + tablename + " where ID = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        ///////////////// Update Record /////////////////
        public void UpdateRecord(string tablename, User user)
        {
            string query = "update " + tablename + " set Name_ = @Name, Email = @Email, Username = @Username, Password_ = @Password, User_Type = @User_Type where ID = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", user.ID);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //////////////////////////////////////////
        
        ///////////////// Login /////////////////
        public void Login(int id)
        {
            string query = "update CurrentUser set ID = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        ///////////////// Get User ID /////////////////
        public int GetUserID(string Email)
        {
            string query = "select id from Personal where Work_Email = '" + Email + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int ID = 0;
            try
            {
                con.Open();
                ID = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ID;
        }
        ///////////////// Get Current User /////////////////
        public int GetCurrentUserID()
        {
            string query = "select * from CurrentUser";
            SqlCommand cmd = new SqlCommand(query, con);
            int ID = 0;
            try
            {
                con.Open();
                ID = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ID;
        }

        ///////////////// Get Password /////////////////
        public string GetPassword(int id)
        {
            string query = "select Person_Password from Personal where id = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            string password = "";
            try
            {
                con.Open();
                password = (string)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return password;
        }
        ///////////////// Get User Type /////////////////
        public int GetUserType(int id) 
        {
            if (IsInTable(id, "Employee"))
                return 1;
            if (IsInTable(id, "Personal_Manager"))
                return 2;
            if (IsInTable(id, "Recruitment_Manager"))
                return 3;
            if (IsInTable(id, "Training_Manager"))
                return 4;
            else
                return 0;
        }
        // calls IsInTable and searches the tables for the given id and returns the corresponding number to the user type
        // Employee          1
        // Personal Mang     2
        // Recruitment Mang  3
        // Training Mang     4

        public bool IsInTable(int id, string Table) 
        {
            //return true;
            DataTable table = new DataTable();
            string query = "";
            if (Table == "Employee")
                query = "select EmployeeID from Employee where EmployeeID = " + id;
            else if (Table == "Recruitment_Manager")
                query = "select Recruitment_Mang_ID from Recruitment_Manager where Recruitment_Mang_ID = " + id;
            else if (Table == "Training_Manager")
                query = "select Training_Mang_ID from Training_Manager where Training_Mang_ID = " + id;
            else if (Table == "Personal_Manager")
                query = "select Personal_Mang_ID from Personal_Manager where Personal_Mang_ID = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            if(table.Rows.Count == 0)
                return false;       
            return true;
        }
        //checks if there is a tuple in the table with given id 


        ///////////////// Read Table colunm with condition /////////////////
        public DataTable ReadTablesWithConditon(string tablename, string column, string conditionLHS, string conditionRHS)
        {
            DataTable table = new DataTable();
            string query = "select " + column + " from " + tablename+ " where " + conditionLHS + " = " + conditionRHS;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }






        ///////////////// Reads value with condition /////////////////
        public int ExcuteScalarINT(string tablename, string column, string conditionLHS, string conditionRHS)
        {
            string query = "select " + column + " from " + tablename + " where " + conditionLHS + " = " + conditionRHS;
            SqlCommand cmd = new SqlCommand(query, con);
            int value =-1;
            try
            {
                con.Open();
                value = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return value;
        }
        ///////////////// Read Table with given query /////////////////
        public DataTable ReadTablesQuery(string query)
        {
            DataTable table = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }
        ///////////////// Get Max ID /////////////////
        public int GetMaxID(string tablename)
        {
            int maxID = 0;
            string query = "select Max(ID) from " + tablename;
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                maxID = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return maxID;
        }
        ///////////////// insert into Requests /////////////////
        public void AddRecordRequest(int id, string type, string status, string description, int EID, int PID)
        {
            string query = "INSERT INTO Requests VALUES (@ID,@R_Type,@R_Status,@R_Description,@EmployeeID,@Approved_by)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@R_Type", type);
            cmd.Parameters.AddWithValue("@R_Status", status);
            cmd.Parameters.AddWithValue("@R_Description", description);
            cmd.Parameters.AddWithValue("@EmployeeID", EID);
            cmd.Parameters.AddWithValue("@Approved_by", PID);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        ///////////////// insert into Attend Training /////////////////
        public void AddRecordAttend_Training(int id, int EID, int time)
        {
            string query = "INSERT INTO Attend_Training VALUES (@TrainingID,@E_ID,@Time_Spent)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TrainingID", id);
            cmd.Parameters.AddWithValue("@E_ID", EID);
            cmd.Parameters.AddWithValue("@Time_Spent", time);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        ///////////////// ///////////////// /////////////////
        public DataTable ReadTablesfrom(string tablename, string columns)
        {
            DataTable table = new DataTable();
            string query = "select " + columns + " from " + tablename ;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }

        public DataTable ReadTablesWithConditon(string tablename, string column, string conditionLHS, int conditionRHS)
        {
            DataTable table = new DataTable();
            string query = "select " + column + " from " + tablename + " where " + conditionLHS + " = " + conditionRHS;

          ////////////////////// Custom Execute Reader Queries /////////////////
        public DataTable CustomQuery(string query) {
            DataTable table = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }

        ///////////////// Join 2 Tables /////////////////
        public DataTable JoinTablesWithCondition(string tablename1, string tablename2, string column, string OnConditionLHS,string OnConditionRHS,string WhereConditionLHS,String WhereConditionRHS)
        {
            DataTable table = new DataTable();
            string query = "select " + column + " from " + tablename1 + " join " + tablename2 + " on " + OnConditionLHS + " = " + OnConditionRHS
                + " Where " + WhereConditionLHS+ " = " + WhereConditionRHS;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                result =  cmd.ExecuteScalar().ToString();

                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;

        }
  
  
          /////////////////////////// Custom Scalar Query//////////////////
        public string CustomScalarQuery(string query)
        {
            string result = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                result =  cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public DataTable getCurrTraining(string tablename1, string tablename2, string column, string OnConditionLHS, string OnConditionRHS, 
            string WhereConditionLHS, String WhereConditionRHS, string WhereCondition2LHS,string WhereCondition2RHS)
        {
            DataTable table = new DataTable();
            string query = "select " + column + " from " + tablename1 + " join " + tablename2 + " on " + OnConditionLHS + " = " + OnConditionRHS
                + " Where " + WhereConditionLHS + " = " + WhereConditionRHS + " and " + WhereCondition2LHS + " " +WhereCondition2RHS + "GetDate()";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }

        public DataTable getPrevTraining(string tablename1, string tablename2, string column, string OnConditionLHS, string OnConditionRHS,
            string WhereCondition2LHS, string WhereCondition2RHS)
        {
            DataTable table = new DataTable();
            string query = "select " + column + " from " + tablename1 + " join " + tablename2 + " on " + OnConditionLHS + " = " + OnConditionRHS
                + " Where " +  WhereCondition2LHS + " " + WhereCondition2RHS + "GetDate()";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                table.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }
    }
}
