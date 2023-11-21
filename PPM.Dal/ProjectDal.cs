using System.Data.SqlClient;
using PPM.Model;

namespace PPM.Dal
{
   public class ProjectDal
   {  
   
     string Connect = "Server=RHJ-9F-D069\\SQLEXPRESS; Database= Prolifics_Project_Manager;Integrated Security=SSPI";

        public  void AddProject(ProjectProperties project)
        {
            using (SqlConnection connection = new SqlConnection(Connect))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand( "INSERT INTO Project (ProjectId, ProjectName, StartDate, EndDate) VALUES (@projectId, @ProjectName, @StartDate, @EndDate)",connection ))
                {
                     DateTime startDateTime = new DateTime(project.StartDate.Year, project.StartDate.Month, project.StartDate.Day, 0, 0, 0);
                    DateTime endDateTime = new DateTime(project.EndDate.Year, project.EndDate.Month, project.EndDate.Day, 0, 0, 0);
                   
                    command.Parameters.AddWithValue("@projectId", project.ProjectId);
                    command.Parameters.AddWithValue("@projectName", project.ProjectName);
                    command.Parameters.AddWithValue("@startDate", startDateTime);
                    command.Parameters.AddWithValue("@endDate", endDateTime);
 

                    command.ExecuteNonQuery();
                }
            }
        } 
          public  bool IsValidProjectId(int ProjectId)
    {
       
        using (SqlConnection con = new SqlConnection(Connect))
        {
            con.Open();
 
            string query = "SELECT COUNT(*) FROM Project WHERE ProjectId = @ProjectId";
           
           
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
 
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

public List<ProjectProperties>  ViewProjectDal()
        {
           List<ProjectProperties> ProjectList = new List<ProjectProperties>();
 
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Project", con))
                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            ProjectProperties project = new ProjectProperties();
 
                            project.ProjectId = Convert.ToInt32(read["ProjectId"]);
                            project.ProjectName = read["ProjectName"].ToString();
                            project.StartDate = Convert.ToDateTime(read["StartDate"]);
                            project.EndDate = Convert.ToDateTime(read["EndDate"]);

 
 
                            ProjectList.Add(project);
 
                        }
                    }
             
                }
                return ProjectList;
            }
        }
          public List<ProjectProperties>  ViewProjectByIdDal(int ProjectId)
        {
           List<ProjectProperties> ProjectList = new List<ProjectProperties>();
 
            ProjectProperties project = new ProjectProperties();
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
               
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Project  WHERE ProjectId = @ProjectId", con))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            
 
                            project.ProjectId = Convert.ToInt32(read["ProjectId"]);
                            project.ProjectName = read["ProjectName"].ToString();
                            project.StartDate = Convert.ToDateTime(read["StartDate"]);
                            project.EndDate = Convert.ToDateTime(read["EndDate"]);

 
 
                            ProjectList.Add(project);
 
                        }
                    }
             
                }
                return ProjectList;
            }
        }
        
        public bool DeleteProjectByIdDal(int ProjectId)
        {
 
 
            using (SqlConnection con = new SqlConnection(Connect))
            {
                con.Open();
 
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Project where ProjectId = @ProjectId", con))
                {
 
                    cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                   return rowsAffected > 0;
 
                }
 
            }
        }
        
         public bool IsProjectExist(int projectId)
        {
            using (SqlConnection connection = new SqlConnection(Connect))
            {
                connection.Open();
 
                string query = "SELECT COUNT(*) FROM EmployeeProject WHERE projectId = @projectId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@projectId", projectId);
 
                    int projectCount = (int)command.ExecuteScalar();
 
                    return projectCount > 0;
                }
            }
        }

    }
 }
