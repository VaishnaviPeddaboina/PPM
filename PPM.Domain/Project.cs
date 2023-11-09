using System.ComponentModel.Design;
using PPM.Model;
public class Project : IEntityOperation<ProjectProperties>
{
    public static List<ProjectProperties> ProjectList = new List<ProjectProperties>();
    public void AddEntity(ProjectProperties obj)
    {   
        ProjectList.Add(obj);
    }
   
       public List<ProjectProperties> ListAll()
       {
        return ProjectList;
       }
    public ProjectProperties ListById(int id)
    {
        return ProjectList.Find(r => r.ProjectId == id)!;
    }


    public void Delete(int ProjectId)
    {
         int remove = Project.ProjectList.FindIndex(r => r.ProjectId == ProjectId );

            if (remove >= 0)
            {
                ProjectList.RemoveAt(remove);
            }
    }
 }


