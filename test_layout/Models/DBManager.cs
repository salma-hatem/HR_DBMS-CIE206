using System.Data;
using Microsoft.Data.SqlClient;

namespace test_layout.Models
{
    public class DBManager
    {
        static string constring = "";
        SqlConnection con = new SqlConnection(constring);
        ///////////////// Read Tables /////////////////
        public DataTable ReadTables(string tablename)
        {
            DataTable table = new DataTable();
            string query = "select * from " + tablename;
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
        ///////////////// Get User ID /////////////////
        public int GetUserID(string Username)
        {
            string query = "select ID from Users where Username = '" + Username + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int user_type = 0;
            try
            {
                con.Open();
                user_type = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return user_type;
        }
    }
}
