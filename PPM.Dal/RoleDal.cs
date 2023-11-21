using PPM.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PPM.Dal
{
    public class RoleDal
   {  
    
     string Connect = "Server=RHJ-9F-D069\\SQLEXPRESS; Database= Prolifics_Project_Manager;Integrated Security=SSPI";

        public void AddRole(RoleProperties role)
        {
           using (SqlConnection connection = new SqlConnection(Connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Role (RoleId ,RoleName) VALUES (@RoleId , @RoleName)", connection))
                {
                    command.Parameters.AddWithValue("@RoleId", role.RoleId);
                    command.Parameters.AddWithValue("@RoleName", role.RoleName);

                    command.ExecuteNonQuery();
                }
            }
        } 

       public  bool IsValidRoleId(int RoleId)
    {
       
        using (SqlConnection con = new SqlConnection(Connect))
        {
            con.Open();
 
            string query = "SELECT COUNT(*) FROM Role WHERE RoleId = @roleId";
           
           
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@roleId", RoleId);
 
                int count = (int)cmd.ExecuteScalar();
 
                if (count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
    public List<RoleProperties>  ViewRoleDal()
        {
               List<RoleProperties> roleList = new List<RoleProperties>();
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Role", con))
                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            RoleProperties role = new RoleProperties();
 
                            role.RoleId = Convert.ToInt32(read["RoleId"]);
                            role.RoleName = read["RoleName"].ToString();
                            
 
                            roleList.Add(role);
 
                        }
                    }
             
                }
                return roleList;
            }
        }

        public List<RoleProperties>  ViewRoleByIdDal(int RoleId)
        {
               List<RoleProperties> roleList = new List<RoleProperties>();
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Role where RoleId = @roleId ", con))
                {
                    cmd.Parameters.AddWithValue("@roleId", RoleId);
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            RoleProperties role = new RoleProperties();
 
                            role.RoleId = Convert.ToInt32(read["RoleId"]);
                            role.RoleName = read["RoleName"].ToString();
                            
 
                            roleList.Add(role);
 
                        }
                    }
             
                }
                return roleList;
            }
        }
        public bool DeleteRoleByIdDal(int RoleId)
        {
 
 
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Role where RoleId = @RoleId", con))
                {
 
                    cmd.Parameters.AddWithValue("@RoleId", RoleId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                   return rowsAffected > 0;
 
                }
 
            }
        }
       

   }
}