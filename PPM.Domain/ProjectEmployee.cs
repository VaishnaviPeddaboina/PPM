using PPM.Model;

namespace PPM.Domain 
{
public  class ProjectEmployee
{
 public static List<ProjectEmployeeProperties> projectEmployee = new List<ProjectEmployeeProperties>();
 ProjectEmployee proj = new ProjectEmployee();
    public static void AddEmployeetoproject(int projectid ,  int employeeid , int roleid)
   {   
       ProjectEmployeeProperties obj = new ProjectEmployeeProperties()
       {
        ProjectID = projectid,
        // ProjectName = projectName,
        EmployeeId = employeeid,
        RoleID = roleid
       };
    projectEmployee.Add(obj);
   }
    public static void RemoveEmployeeProjectMethod(int projectId, int employeeId)
        {
            int remove = projectEmployee.FindIndex(r => r.ProjectID == projectId && r.EmployeeId == employeeId);
            if (remove >= 0)
            {
                projectEmployee.RemoveAt(remove);
            }
            else
            {
                System.Console.WriteLine("Employee not found");
            }
        }
        public static void ViewProjectEmployees()
        {
             if(projectEmployee.Count == 0)
         {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("-------------------No Existing Projects-----------");
           Console.ResetColor();
         }
         else
         {
          Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
        foreach(ProjectEmployeeProperties item in projectEmployee)
        {
            Console.WriteLine("Project Id : {0}   Project Name : {1}   Employee ID : {2}   First Name : {3},   Last Name : {4},   Role Id : {5}",item.ProjectID,  item.EmployeeId ,item.RoleID);
        }
         Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
         }
        }
}
}