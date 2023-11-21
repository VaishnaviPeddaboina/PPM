
using PPM.Model;
using PPM.Domain;
using PPM.Dal;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
namespace PPM.Ui.Consoles
{
  public class ProjectEmployeeConsoles
  {

    public static void AddEmployeeToproject()
    {
      ProjectEmployeeProperties obj = new ProjectEmployeeProperties();
      int projectid, employeeId;



      System.Console.WriteLine("Enter the Project Id for which the Employees are to be added");

      projectid = int.Parse(Console.ReadLine() ?? string.Empty);
      if(projectid <= 0)
      {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine("--------Invalid Project Id----------");
        Console.ResetColor();
        return;
      }
      ProjectDal projectdal = new ProjectDal();
      if (projectdal.IsValidProjectId(projectid))
      {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("---------Project doesn't exists--------");
        Console.ResetColor();
        return;
      }
      else
      {
        obj.ProjectID = projectid;

      }


      System.Console.WriteLine("Enter the employee id that you want to add");
      employeeId = int.Parse(Console.ReadLine() ?? string.Empty);
      if (employeeId <= 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("-----------Invalid Employee Id-----------");
        Console.ResetColor();
        return;
      }
      EmployeeDal employeeDal = new EmployeeDal();
      if (employeeDal.IsValidEmployeeId(employeeId))
      {

        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("---------Employee doesn't exists--------");
        Console.ResetColor();
        return;
      }
      else
      {
        obj.EmployeeId = employeeId;

      }


      ProjectEmployeeDal project = new ProjectEmployeeDal(); 

      if (!project.IsEmployeeProjectExists(projectid, employeeId))
      {
        Employee employee = new Employee();
        // List<EmployeeProperties> employeeList = employee.ListAll();
        var query3 = employee.ListById(employeeId);

        foreach (var item in query3)
        {

          obj.RoleID = item.RoleId;
        }


      }
      else
      {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Employee already exist in the project.");
        Console.ResetColor();
        return;
      }

      Console.ForegroundColor = ConsoleColor.DarkGreen;
      System.Console.WriteLine("Employees Added to Project");
      Console.ResetColor();
      ProjectEmployee.AddEmployeetoproject(obj.ProjectID, employeeId, obj.RoleID);
    }
    public static void DeleteemployeefromProject()
    {
      ProjectEmployeeProperties obj = new ProjectEmployeeProperties();
      int projectId, employeeId;

      System.Console.WriteLine("Enter ProjectId to remove from project");
      projectId = int.Parse(Console.ReadLine() ?? string.Empty);
      ProjectDal projectdal = new ProjectDal();
      if (projectdal.IsValidProjectId(projectId))
      {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("---------Project doesn't exists--------");
        Console.ResetColor();
        return;
      }
      else
      {
        obj.ProjectID = projectId;

      }

      Console.WriteLine("Enter employeeid to remove from project");

      employeeId = int.Parse(Console.ReadLine() ?? string.Empty);
      if (employeeId == 0)
      {
        return;
      }
      EmployeeDal employeeDal = new EmployeeDal();
      if (employeeDal.IsValidEmployeeId(employeeId))
      {

        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("---------Employee doesn't exists--------");
        Console.ResetColor();
        return;
      }
      else
      {
        obj.EmployeeId = employeeId;

      }
      ProjectEmployeeDal project = new ProjectEmployeeDal();
      if (!project.IsEmployeeProjectExists(projectId, employeeId))
      {

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Employee doesn't exists in the project.");
        Console.ResetColor();
        return;

      }
      else
      {
        ProjectEmployee.RemoveEmployeeProjectMethod(projectId, employeeId);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Employee deleted from the project.");
        Console.ResetColor();
      }

    }
  
  public static void ViewEmployeesinProject()
  {
   
   if(ProjectEmployee.ViewEmployeesProject().Count == 0)
   {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("-------------------No Existing Projects-----------");
    Console.ResetColor();
   }
   else
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine("-----------------------------------------------------------------------------------------------");
          foreach (ProjectEmployeeProperties item in ProjectEmployee.ViewEmployeesProject())
          {
            Console.WriteLine("Project Id : {0}   Employee Id : {1}   Role Id : {2}", item.ProjectID, item.EmployeeId, item.RoleID);
          }
          Console.WriteLine("-------------------------------------------------------------------------------------------------");
          Console.ResetColor();
        }
    
  }
  }
}
