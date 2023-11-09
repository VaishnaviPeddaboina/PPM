using PPM.Model;
using PPM.Domain;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
namespace PPM.Ui.Consoles
{
    
  public class ProjectRepo : IProject
  {
      Project projectobject = new Project();
    public void AddProjectAndEmployee()
    {
        System.Console.WriteLine("Enter number of Projects to be added: ");
        int count = int.Parse(Console.ReadLine() ?? string.Empty);
        for (int i = 0; i < count; i++)
        {
            ProjectProperties obj = new ProjectProperties();
            int projectId ;
            while(true)
            {
                while(true)
                {
                  System.Console.WriteLine("Enter ProjectId: ");
                  projectId = int.Parse(Console.ReadLine() ?? string.Empty);
                  if(projectId <= 0 )
                  {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("-------Invalid Project Id------");
                    Console.ResetColor();
                 } 
                 else
                 {
                    break;
                 }
                }    
                var ExistingProject = Project.ProjectList.Find(p => p.ProjectId == projectId);
                if (ExistingProject != null)
                  {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("---------Project already exists--------"); 
                    Console.ResetColor();        
                  }
                  else
                  {
                    obj.ProjectId = projectId;
                    break;
                  } 
            }  
            System.Console.WriteLine("Enter title of the project: ");
            obj.ProjectName = Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter start date: ");
            obj.StartDate = DateOnly.Parse(Console.ReadLine() ?? string.Empty);
            while(true)
            {
                System.Console.WriteLine("Enter end date: ");
                obj.EndDate = DateOnly.Parse(Console.ReadLine() ?? string.Empty);
                if (obj.StartDate >= obj.EndDate)
                {
                   Console.ForegroundColor = ConsoleColor.Red;
                   System.Console.WriteLine("----Please enter a valid end date-----");    
                   Console.ResetColor();    
                }
                else
                {
                   break;
                }
            }    
            System.Console.WriteLine("Do u want to add Employees to Project");   
            string Add = Console.ReadLine() ?? string.Empty; 
            if(Add == "yes" || Add =="YES" || Add =="Yes")
            {
               ProjectEmployeeProperties obj2 = new ProjectEmployeeProperties();
               int employeeId ;
               obj2.ProjectID = obj.ProjectId;

               System.Console.WriteLine("Enter the no. of employees you want to add");
               int size = int.Parse(Console.ReadLine() ?? string.Empty);
               for(int j = 0 ; j < size ; j++)
               {
                 while(true)
                 {
                     System.Console.WriteLine("Enter the employee id that you want to add");
                     employeeId = int.Parse(Console.ReadLine() ?? string.Empty);
                     if(employeeId == 0 )
                     {
                        return;
                     }
                     var employeeExist = Employee.empList.Find(e => e.EmployeeId == employeeId );
                     if(employeeExist != null)
                     {
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("-----Employee Added to Project-----");
                        Console.ResetColor();
                  
                     }
                     else
                     { 
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("-----Employee Doesn't exists-----");
                        Console.ResetColor();  
                        break;
                     }
            
                     var employeeProjectExist = ProjectEmployee.projectEmployee.Find(p => p.ProjectID == projectId &&  p.EmployeeId == employeeId);
                     if(employeeProjectExist != null)
                     {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("----- Employee already added to project -----");
                        Console.ResetColor();
                        break;
                     }
                     else
                     {
                        var query2 = from item in Employee.empList
                        where item.EmployeeId == employeeId
                        select new {item.EmployeeId ,item.RoleId};
                        foreach(var item in query2)
                        {
                           obj2.EmployeeId = item.EmployeeId;
                           obj2.RoleID  =  item.RoleId;
                        }
          
                     }
           
                     ProjectEmployee.projectEmployee.Add(obj2);
                     Console.ForegroundColor = ConsoleColor.Yellow;
                     foreach (ProjectEmployeeProperties item in ProjectEmployee.projectEmployee)
                     {
                        System.Console.WriteLine("project details");
                        System.Console.WriteLine("employeeid : {0} , roleid :{1}  project Id :{2}", item.EmployeeId, item.RoleID ,item.ProjectID);
                     }
  
                     ProjectEmployee.AddEmployeetoproject(  obj2.ProjectID , employeeId , obj2.RoleID);     
     
                     Console.ResetColor();

           
                 }
                 Console.ForegroundColor = ConsoleColor.DarkGreen;
                 Console.WriteLine("-------------Project Added-------------");
                 Console.ResetColor();        
                 projectobject.AddEntity(obj); 
               }
            }           
            else
            {
                 Console.ForegroundColor = ConsoleColor.DarkGreen;
                 Console.WriteLine("-------------Project Added-------------");
                 Console.ResetColor();        
                 projectobject.AddEntity(obj); 
            }
        }
              
    }
  public  List<ProjectProperties> ViewProjects()
  {
    Project project = new Project();
    if (project.ListAll().Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("-------------------No Existing Projects-----------");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor =ConsoleColor.Yellow;
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        foreach (ProjectProperties item in project.ListAll())
        {
            Console.WriteLine("Project Id : {0}   Project Name : {1}   Start Date : {2}   End Date : {3}", item.ProjectId, item.ProjectName, item.StartDate, item.EndDate);
        }
        Console.WriteLine("-------------------------------------------------------------------------------------------------");
        Console.ResetColor();
    } 
    return Project.ProjectList;
  }
  public List<ProjectProperties> ViewProjectsById()
  {
    System.Console.WriteLine("Enter the Project Id");
    int Id = int.Parse(Console.ReadLine() ?? string.Empty);
    int ProjectById = Project.ProjectList.FindIndex(p => p.ProjectId == Id);
    if (ProjectById >= 0)
    {
        ProjectProperties item = Project.ProjectList[ProjectById];
        Console.ForegroundColor =ConsoleColor.Yellow;    
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("Project Id : {0}   Project Name : {1}   Start Date : {2}   End Date : {3}", item.ProjectId, item.ProjectName, item.StartDate,item.EndDate);
        Console.WriteLine("-------------------------------------------------------------------------------------------------");
        Console.ResetColor();   
    } 
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(" --------ProjectId doesn't exists ----------");
        Console.ResetColor();
    }
    return Project.ProjectList;
  }
  public  void ProjectDelete()
  {
    System.Console.WriteLine("Enter ProjectId ");
    int ProjectId = int.Parse(Console.ReadLine() ?? string.Empty);
    bool projectDelete = Project.ProjectList.Any(p => p.ProjectId == ProjectId);
    if (projectDelete)
    {
        projectobject.Delete(ProjectId);
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("-----------Project Deleted-----------");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(" --------ProjectId doesn't exists ----------");
        Console.ResetColor();
    }
  }
 }
}
