using PPM.Model;
using PPM.Domain;
using PPM.Dal;

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
        int projectId;
        while (true)
        {
          while (true)
          {
            System.Console.WriteLine("Enter ProjectId: ");
            projectId = int.Parse(Console.ReadLine() ?? string.Empty);
            if (projectId <= 0)
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
          ProjectDal projectdal = new ProjectDal();
          if (projectdal.IsValidProjectId(projectId))
          {

            obj.ProjectId = projectId;
            break;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("---------Project already exists--------");
            Console.ResetColor();
          }
        }
        System.Console.WriteLine("Enter title of the project: ");
        obj.ProjectName = Console.ReadLine() ?? string.Empty;
        System.Console.WriteLine("Enter start date: ");
        obj.StartDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);
        while (true)
        {
          System.Console.WriteLine("Enter end date: ");
          obj.EndDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);
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
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("-------------Project details Added-------------");
        Console.ResetColor();
        projectobject.AddEntity(obj);
        System.Console.WriteLine("Do u want to add Employees to Project");
        string Add = Console.ReadLine() ?? string.Empty;
        if (Add == "yes" || Add == "YES" || Add == "Yes")
        {
          Employee employee = new Employee();
          List<EmployeeProperties> employeeList = employee.ListAll();

          if (employeeList.Count() == 0)
          {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("There are no Employees in Employee list.");
            Console.ResetColor();

          }
          else
          {
            ProjectEmployeeProperties obj2 = new ProjectEmployeeProperties();
            int employeeId;
            obj2.ProjectID = obj.ProjectId;

            System.Console.WriteLine("Enter the no. of employees you want to add");
            int size = int.Parse(Console.ReadLine() ?? string.Empty);
            for (int j = 0; j < size; j++)
            {
             
                while (true)
                {
                  System.Console.WriteLine("Enter the employee id that you want to add");
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
                   
                  }
                  else
                  { 

                    break;
                  }
                }

                ProjectEmployeeDal project = new ProjectEmployeeDal();
                if ( project.IsEmployeeProjectExists(projectId, employeeId) )
                {
                
                      Console.ForegroundColor = ConsoleColor.DarkCyan;
                  Console.WriteLine("Employee already exist in the project.");
                  Console.ResetColor();
                  break;
                }
                else
                {

                  var query2 = employee.ListById(employeeId);
                  foreach (var item in query2)
                  {
                    obj2.EmployeeId = employeeId;
                    obj2.RoleID = item.RoleId;
                  }
                    
                }
                ProjectEmployee.AddEmployeetoproject(obj.ProjectId, employeeId, obj2.RoleID);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("-------------Employee Added to Project-------------");
                Console.ResetColor();
              }
            }

        }
        }

        
      }
      public void ViewProjects()
      {
        Project project = new Project();
        // project.ListAll();
        if (project.ListAll().Count == 0)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("-------------------No Existing Projects-----------");
          Console.ResetColor();
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine("-----------------------------------------------------------------------------------------------");
          foreach (ProjectProperties item in project.ListAll())
          {
            Console.WriteLine("Project Id : {0}   Project Name : {1}   Start Date : {2}   End Date : {3}", item.ProjectId, item.ProjectName, item.StartDate, item.EndDate);
          }
          Console.WriteLine("-------------------------------------------------------------------------------------------------");
          Console.ResetColor();
        }

      }
      public void ViewProjectsById()
      {
        System.Console.WriteLine("Enter the Project Id");
        int Id = int.Parse(Console.ReadLine() ?? string.Empty);
        Project project = new Project();
        List<ProjectProperties> result = project.ListById(Id);
        if (result.Count > 0)
        {

          foreach (ProjectProperties item in result)
          {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("Project Id : {0}   Project Name : {1}   Start Date : {2}   End Date : {3}", item.ProjectId, item.ProjectName, item.StartDate, item.EndDate);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.ResetColor();
          }
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Red;
          System.Console.WriteLine(" --------ProjectId doesn't exists ----------");
          Console.ResetColor();
        }


      }
      public void ProjectDelete()
      {
        System.Console.WriteLine("Enter Project Id ");
        int projectId = int.Parse(Console.ReadLine() ?? string.Empty);
        Project project = new Project();
        ProjectDal pro = new ProjectDal();
        while (true)
        {
          if (pro.IsProjectExist(projectId))
          {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("-----------Project is on Going-----------");
            Console.ResetColor();
            break;
          }

          bool projectDelete = project.Delete(projectId);
          if (projectDelete)
          {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("----- Project Deleted -----");
            Console.ResetColor();
            break;

          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("-----------Project doesn't exist-----------");
            Console.ResetColor();
            break;

          }

        }
      }
    }
  }
