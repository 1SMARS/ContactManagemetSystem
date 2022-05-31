using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ContactMs.econtactClasses
{
    class contactClass
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNom { get; set; }
        public string Address { get; set; }
        public string Gmail { get; set; }
        public string Gender { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tbl_contact";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool Insert (contactClass c)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {

                string sql = "INSERT INTO tbl_contact (FirstName, LastName, ContactNom, Address, Gmail, Gender) VALUES (@FirstName, @LastName, @ContactNom, @Address, @Gmail, @Gender)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNom", c.ContactNom);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gmail", c.Gmail);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

        
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public bool Update(contactClass c)
        {     
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {          
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName, LastName=@Lastname, ContactNom=@ContactNom, Address=@Address, Gmail=@Gmail, Gender=@Gender WHERE ContactID=@ContactID";
              
                SqlCommand cmd = new SqlCommand(sql, conn);    
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNom", c.ContactNom);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gmail", c.Gmail);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("ContactID", c.ContactID);
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
              
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
   
        public bool Delete(contactClass c)
        {          
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM tbl_contact WHERE ContactID=@ContactID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        
    }
}
