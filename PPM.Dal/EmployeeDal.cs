using System.Data.SqlClient;
using PPM.Model;

namespace PPM.Dal
{
   public class EmployeeDal
   {  
 
     string Connect = "Server=RHJ-9F-D069\\SQLEXPRESS; Database= Prolifics_Project_Manager;Integrated Security=SSPI";
     
      public  void AddEmployee(EmployeeProperties employee)
        {
           using (SqlConnection connection = new SqlConnection(Connect))
        {
            connection.Open();

            string query = "INSERT INTO Employee (EmployeeId , FirstName, LastName, Email, Mobile, Address, RoleId) " +
                           "VALUES (@EmployeeId , @FirstName, @LastName, @Email, @Mobile, @Address , @RoleId)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Mobile", (long)employee.MobileNum);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@RoleId", employee.RoleId);

                command.ExecuteNonQuery();
            }
        }
        }
 public  bool IsValidEmployeeId(int employeeId)
    {
        using (SqlConnection con = new SqlConnection(Connect))
        {
            con.Open();
 
            string query = "SELECT COUNT(*) FROM Employee WHERE EmployeeId = @employeeId";
           
           
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
 
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
    public List<EmployeeProperties>  ViewEmployeeDal()
        {
            List<EmployeeProperties> empList = new List<EmployeeProperties>();
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", con))
                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            EmployeeProperties employee = new EmployeeProperties();
 
                            employee.EmployeeId = Convert.ToInt32(read["EmployeeId"]);
                            employee.FirstName = read["FirstName"].ToString();
                            employee.LastName = read["LastName"].ToString();
                            employee.Email = read["Email"].ToString();
                            employee.MobileNum = Convert.ToInt64(read["Mobile"]);
                            employee.Address = read["Address"].ToString();
                            employee.RoleId = Convert.ToInt32(read["RoleId"]);
 
                            empList.Add(employee);
 
                        }
                    }
             
                }
                return empList;
            }
        }
            public List<EmployeeProperties>  ViewEmployeeByIdDal(int employeeId)
        {
            List<EmployeeProperties> empList = new List<EmployeeProperties>();
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE EmployeeId = @employeeId", con))
                {
                    cmd.Parameters.AddWithValue("@employeeId ", employeeId);
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            EmployeeProperties employee = new EmployeeProperties();
 
                            employee.EmployeeId = Convert.ToInt32(read["EmployeeId"]);
                            employee.FirstName = read["FirstName"].ToString();
                            employee.LastName = read["LastName"].ToString();
                            employee.Email = read["Email"].ToString();
                            employee.MobileNum = Convert.ToInt64(read["Mobile"]);
                            employee.Address = read["Address"].ToString();
                            employee.RoleId = Convert.ToInt32(read["RoleId"]);
 
                            empList.Add(employee);
 
                        }
                    }
             
                }
                return empList;
            }
        }
         public bool DeleteEmployeeByIdDal(int EmployeeId)
        {
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Employee where EmployeeId = @EmployeeId", con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                   return rowsAffected > 0;
                }
 
            }
        }
         public bool IsRoleExist(int roleId)
        {
            using (SqlConnection connection = new SqlConnection(Connect))
            {
                connection.Open();
 
                string query = "SELECT COUNT(*) FROM Employee WHERE RoleId = @roleId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roleId", roleId);
 
                    int roleCount = (int)command.ExecuteScalar();
 
                    return roleCount > 0;
                }
            }
        }
        public bool IsEmployeeExistsinProject(int EmployeeId)
        {
            using (SqlConnection connection = new SqlConnection(Connect))
            {
                connection.Open();
 
                string query = "SELECT COUNT(*) FROM EmployeeProject WHERE EmployeeId = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
 
                    int projectCount = (int)command.ExecuteScalar();
 
                    return projectCount > 0;
                }
            }
        }
   }
}
