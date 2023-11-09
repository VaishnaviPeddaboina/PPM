
using PPM.Domain;
using PPM.Model;
using PPM.Ui.Consoles;
using NUnit.Framework;


using System.Collections.Generic;

namespace PPM.Test;

public class ConsoleTest
{
    ProjectRepo projectRepo = new ProjectRepo();
 EmployeeRepo employeeRepo = new EmployeeRepo();
   RoleRepo roleRepo = new RoleRepo();

    [Test]
public void ViewProjectTest()
{

    ProjectProperties projectView = new ProjectProperties()
    {
        ProjectId = 1,
        ProjectName = "Project",
        StartDate = new DateOnly(2023, 10, 11),
        EndDate = new DateOnly(2023, 11, 11)
    };

    Project.ProjectList.Add(projectView);
  
    List<ProjectProperties> projects = projectRepo.ViewProjects();
    Assert.IsTrue(Project.ProjectList.Contains(projectView));
 
}

[Test]

public void ViewEmployeeTest()
{
    EmployeeProperties employee = new EmployeeProperties()
    {
        EmployeeId = 1,
        FirstName = "Vaishnavi",
        LastName = "Peddaboina",
        Email = "Vaishnavi.Peddaboina@prolifics.com",
        MobileNum = 9908924958,
        Address = "hitech city",
        RoleId = 1,
    };

    Employee.empList.Add(employee);
   

    List<EmployeeProperties> employees = employeeRepo.ViewEmployees();

    Assert.IsTrue(Employee.empList.Contains(employee));
}

[Test]

public void ViewRoleTest()
{
    RoleProperties role = new RoleProperties()
    {
      RoleId = 1 ,
      RoleName = "Developer",
    };

    Role.roleList.Add(role);
  
    List<RoleProperties> roles = roleRepo.ViewRole();

    Assert.IsTrue (Role.roleList.Contains(role));
}

 [Test]
    public void AddProjectFormatIdValidation()
    {
        
        var invalidDateString = "ProjectA";
        
       
        Assert.Throws<System.FormatException>(() => {
            DateOnly parsedDate = DateOnly.Parse(invalidDateString);
            projectRepo.AddProjectAndEmployee();
        });
    }
 [Test]
 
        public void AddProjectValidInput()
        {
            var input = new StringReader("1\n10\nProjectA\n2023-10-25\n2023-10-31\n");
 
            Console.SetIn(input);
 
            projectRepo.AddProjectAndEmployee();
        }

   [Test]
 
        public void AddEmployeeValidInput()
        {
            var input = new StringReader("1\n10\nsgdg\nfgdf\ndgh@gmail.com\n3456543456\ndhg\n1\n");
 
            Console.SetIn(input);
            employeeRepo.AddEmployee();
        }
        
        [Test]
        public void AddRoleValidInput()
        {
            var input = new StringReader("1\n10\nDeveloper\n");
 
            Console.SetIn(input);
 
            roleRepo.AddRole();
        }
    [Test]
    public void AddProjectMethodsValidInputAddsProject()
    {
        // Arrange
        var input = new StringReader("1\n-1\n1\nProjectA\n2023-10-25\n2023-10-31\n");
        var output = new StringWriter();
          Console.SetIn(input);
        projectRepo.AddProjectAndEmployee();
 
    }
    [Test]
    public void AddProjectduplicateMethods()
    {
      var input = new StringReader("2\n123\nProjectA\n2023-10-25\n2023-10-31\n123\n124\nProjectA\n2023-10-25\n2023-10-31\n");
        var output = new StringWriter();
          Console.SetIn(input);
        projectRepo.AddProjectAndEmployee(); 
    }
        [Test]
    public void AddProjectnegativeMethods()
    {
      var input = new StringReader("1\n-1\n187\nProjectA\n2023-10-25\n2023-10-31\n");
        var output = new StringWriter();
          Console.SetIn(input);
        projectRepo.AddProjectAndEmployee(); 
    }
    [Test]
   public void AddRoleMethodValidInputAddsRole()
   {
     var input = new StringReader("1\n-1\n2\nDeveloper\n");
        var output = new StringWriter();
          Console.SetIn(input);
        roleRepo.AddRole();
   }
   [Test]
 public void AddRoleDuplication()
 {
       var input = new StringReader("2\n34\nDeveloper\n34\n35\nDeveloper\n");
        var output = new StringWriter();
          Console.SetIn(input);
        roleRepo.AddRole();
 } 
    [Test]
 public void AddRolenegative()
 {
       var input = new StringReader("1\n-1\n5\nDeveloper\n");
        var output = new StringWriter();
          Console.SetIn(input);
        roleRepo.AddRole();
 } 
   [Test]
   public void AddEmployeeMethodValidInputAddsEmployee()
   {
     var input = new StringReader("1\n2\nVaishnavi\nPeddaboina\nVaishnavi.Peddaboina@prolifics.com\n9908924958\nhitech city\n1\n");
        var output = new StringWriter();
          Console.SetIn(input);
        employeeRepo.AddEmployee();
   }
 [Test]
 public void Addemployeeduplicate()
 {
         var input = new StringReader("2\n45\nVaishnavi\nPeddaboina\nVaishnavi.Peddaboina@prolifics.com\n9908924958\nhitech city\n1\n45\n48\nVaishnavi\nPeddaboina\nVaishnavi.Peddaboina@prolifics.com\n9908924958\nhitech city\n1\n");
        var output = new StringWriter();
          Console.SetIn(input);
        employeeRepo.AddEmployee();
 }
  [Test]
 public void Addemployeenegativeduplicate()
 {
         var input = new StringReader("1\n-1\n100\nVaishnavi\nPeddaboina\nVaishnavi.Peddaboina@prolifics.com\n9908924958\nhitech city\n1\n");
        var output = new StringWriter();
          Console.SetIn(input);
        employeeRepo.AddEmployee();
 }
 
 [Test]
    public void AddEmployeeInvalidEmailId()
    {
        var input = new StringReader("1\n3\nAdhira\nVUFgh\nAdhira.com\nAdhira@gmail.com\n3456543456\ndhg\n1\n");
        Console.SetIn(input);
        employeeRepo.AddEmployee();
    }
 [Test]
 public void AddEmployeeInvalidMobileNum()
 {
       var input = new StringReader("1\n4\nAdhira\nVUFgh\nAdhira@gmail.com\n9909\n3456543456\ndhg\n1\n");
        Console.SetIn(input);
 
        employeeRepo.AddEmployee();
 }
 [Test]
 public void AddProjectInvalidgreaterStartdate()
 {
       var input = new StringReader("1\n-1\n6\nProjectA\n2023-10-31\n2023-11-30\n");
        var output = new StringWriter();
          Console.SetIn(input);
        projectRepo.AddProjectAndEmployee();
 }
     [Test]
    public void ViewProjectById()
    {
        // Arrange
        var input = new StringReader("-1\n1\n");
        var output = new StringWriter();
          Console.SetIn(input);
        projectRepo.ViewProjectsById();
 
    }
        [Test]
    public void ViewEmployeeById()
    {
        // Arrange
        var input = new StringReader("-1\n1\n");
        var output = new StringWriter();
          Console.SetIn(input);
        employeeRepo.ViewEmployeesById();
 
    }
            [Test]
    public void ViewRoleById()
    {
        // Arrange
        var input = new StringReader("-1\n1\n");
        var output = new StringWriter();
          Console.SetIn(input);
        roleRepo.ViewRoleById();
 
    }
         [Test]
    public void DeleteProjectById()
    {
        // Arrange
        var input = new StringReader("-1\n1\n");
        var output = new StringWriter();
          Console.SetIn(input);
        projectRepo.ProjectDelete();
 
    }
           [Test]
    public void DeleteEmployeeById()
    {
        // Arrange
        var input = new StringReader("-1\n1\n");
        var output = new StringWriter();
          Console.SetIn(input);
        employeeRepo.EmployeeDelete();
 
    }
    [Test]
    public void DeleteRoleById()
    {
        // Arrange
        var input = new StringReader("-1\n1\n");
        var output = new StringWriter();
          Console.SetIn(input);
        roleRepo.DeleteRole();
 
    }
}