using System.Data;
using Microsoft.Data.SqlClient;

namespace test_layout.Models
{
    public class DBManager

    {
        static string constring = "Data Source=DESKTOP-QNMEQCE;Initial Catalog=HR_DBMS;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection con = new SqlConnection(constring);
        
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
    }
}
