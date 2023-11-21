using PPM.Model;
using PPM.Dal;

namespace PPM.Domain
{
    public class ProjectEmployee
    {
        public static List<ProjectEmployeeProperties> projectEmployee = new List<ProjectEmployeeProperties>();
        ProjectEmployee proj = new ProjectEmployee();
        public static void AddEmployeetoproject(int projectid, int employeeid, int roleid)
        {
            ProjectEmployeeProperties obj = new ProjectEmployeeProperties()
            {
                ProjectID = projectid,
                EmployeeId = employeeid,
                RoleID = roleid
            };

            ProjectEmployeeDal project = new ProjectEmployeeDal();
            project.AddEmployeeToProject(obj);
        }
        public static void RemoveEmployeeProjectMethod(int projectId, int employeeId)
        {
            ProjectEmployeeProperties obj = new ProjectEmployeeProperties()
            {
                ProjectID = projectId,
                EmployeeId = employeeId,

            };
            ProjectEmployeeDal project = new ProjectEmployeeDal();
            project.DeleteProjectEmployeeByIdDal(obj);
        }
        public static  List<ProjectEmployeeProperties> ViewEmployeesProject()
  {
    ProjectEmployeeDal projectemp = new ProjectEmployeeDal();
    var ProjectemployeeList = projectemp.ViewEmployeeinProjectDal();
    return ProjectemployeeList;
    
  }
    }
}