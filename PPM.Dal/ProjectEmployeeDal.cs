using System.Data.SqlClient;
using PPM.Model;

namespace PPM.Dal
{
     public class ProjectEmployeeDal
   {
      string Connect = "Server=RHJ-9F-D069\\SQLEXPRESS; Database= Prolifics_Project_Manager;Integrated Security=SSPI";
       public  void AddEmployeeToProject(ProjectEmployeeProperties proj)
        {
            using (SqlConnection connection = new SqlConnection(Connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand( "INSERT INTO EmployeeProject (ProjectId,EmployeeId , RoleId) VALUES (@projectId, @employeeId, @roleId)",connection ))
                {
    
                   
                    command.Parameters.AddWithValue("@projectId", proj.ProjectID);
                    command.Parameters.AddWithValue("@EmployeeId", proj.EmployeeId);
                    command.Parameters.AddWithValue("@RoleId", proj.RoleID);
                    command.ExecuteNonQuery();
                }
            }
        } 

          public  bool IsEmployeeProjectExists(int projectId , int employeeId)
    {
       
        using (SqlConnection con = new SqlConnection(Connect))
        {
            con.Open();
 
            string query = "SELECT COUNT(*) FROM EmployeeProject WHERE ProjectId = @ProjectId and  EmployeeId = @EmployeeId";
           
           
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ProjectId", projectId);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                int count = (int)cmd.ExecuteScalar();
 
             return count > 0 ;
                
            }
        }
    }

     public bool DeleteProjectEmployeeByIdDal(ProjectEmployeeProperties proj)
        {
 
 
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("DELETE FROM EmployeeProject WHERE ProjectId = @ProjectId and  EmployeeId = @EmployeeId", con))
                {
 
                    cmd.Parameters.AddWithValue("@ProjectId", proj.ProjectID);
                    cmd.Parameters.AddWithValue("@EmployeeId",proj.EmployeeId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                   return rowsAffected > 0;
 
                }
 
            }
        }


 public List<ProjectEmployeeProperties>  ViewEmployeeinProjectDal()
        {
           List<ProjectEmployeeProperties> ProjectEmployeeList = new List<ProjectEmployeeProperties>();
 
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM EmployeeProject", con))
                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            ProjectEmployeeProperties Employeeproject = new ProjectEmployeeProperties();
 
                            Employeeproject.ProjectID = Convert.ToInt32(read["ProjectId"]);
                            Employeeproject.EmployeeId =  Convert.ToInt32(read["EmployeeId"]);
                            Employeeproject.RoleID =  Convert.ToInt32(read["RoleId"]);

 
                            ProjectEmployeeList.Add(Employeeproject);
 
                        }
                    }
             
                }
                return ProjectEmployeeList;
            }
        }

   }
}
