using System.ComponentModel.Design;
using PPM.Model;
using PPM.Dal;

public class Project : IEntityOperation<ProjectProperties>
{
     public static List<ProjectProperties> ProjectList = new List<ProjectProperties>();
 
    public void AddEntity(ProjectProperties obj)
    {   
       
          ProjectDal projectDal = new ProjectDal();
       projectDal.AddProject(obj);
    }
   
       public List<ProjectProperties> ListAll()
       {
          ProjectDal projectDal = new ProjectDal();
         var ProjectList = projectDal.ViewProjectDal();
         return ProjectList;
       }
    public List<ProjectProperties> ListById(int id)
    {
         ProjectDal projectDal = new ProjectDal();
         var ProjectList = projectDal.ViewProjectByIdDal(id);
         return ProjectList;
    }


    public bool Delete(int ProjectId)
    {
         ProjectDal projectDal = new ProjectDal();
         bool ProjectList = projectDal.DeleteProjectByIdDal(ProjectId);
         return ProjectList;
    }
 }


