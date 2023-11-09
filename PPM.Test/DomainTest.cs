
using PPM.Model;
using PPM.Domain;
using PPM.Ui.Consoles;


namespace PPM.Test;

public class DomainTest
{

      Project project = new Project();
      Employee employee = new Employee();
      Role role = new Role();

    [Test]
    public void AddEmployeeValidUser()
    {
       
       EmployeeProperties employeeProperties = new EmployeeProperties()

        {
            EmployeeId = 1,
            FirstName = "meera",
            LastName = "joseph",
            Email = "meera@gmail.com",
            MobileNum = 9303586432,
            Address = "vkb",
            RoleId = 2,
        };
        employee.AddEntity(employeeProperties);

        CollectionAssert.Contains(Employee.empList ,employeeProperties);
        System.Console.WriteLine("Test passed");
    
    }
    [Test]
        public void AddProjectValidUser()
    {

   DateOnly startDate = new DateOnly(2023, 9, 23);
    DateOnly endDate = new DateOnly(2024, 9, 24);
       
       ProjectProperties projectProperties = new ProjectProperties()

        {
            ProjectId = 1,
            ProjectName = "Project",
            StartDate = startDate,
            EndDate = endDate ,    
        };
        project.AddEntity(projectProperties);

        CollectionAssert.Contains(Project.ProjectList ,projectProperties);
        System.Console.WriteLine("Test passed");
    
    }
    [Test]

    public void AddRoleValidUser()
    {
        RoleProperties roleProperties = new RoleProperties()
        {
            RoleId = 1,
            RoleName = "Developer",
        };

        role.AddEntity(roleProperties);

        CollectionAssert.Contains(Role.roleList , roleProperties);
        System.Console.WriteLine("Test passed");
    }
    // [Test]
    // public void AddEmployeeToProjectValidUser()
    // {
    //     ProjectEmployeeProperties peobj = new ProjectEmployeeProperties()
    //     {
    //         ProjectID = 1,
    //         EmployeeId = 1,
    //         RoleID = 1,
    //     };

    //     ProjectEmployee.Add_Employee_To_project(peobj.ProjectID,peobj.ProjectName, peobj.EmployeeId,peobj.FirstName  ,peobj.LastName , peobj.RoleID);

    //       bool containsItem = ProjectEmployee.projectEmployee.Any(item =>
    //     item.ProjectID == peobj.ProjectID &&
    //     item.EmployeeId == peobj.EmployeeId &&
    //     item.FirstName == peobj.FirstName &&
    //     item.LastName == peobj.LastName &&
    //     item.RoleID == peobj.RoleID);
    //     Assert.IsTrue(containsItem);
    //     System.Console.WriteLine("Test Passed");

    // }
    
//     [Test]
//     public void RemoveEmployeeToProjectValidUser()
//     {
//         ProjectEmployeeProperties peobj = new ProjectEmployeeProperties()
//         {
//             ProjectID = 1,
//             EmployeeId = 1,
//         };

//         ProjectEmployee.RemoveEmployeeProjectMethod(peobj.ProjectID, peobj.EmployeeId);

//           bool containsItem = ProjectEmployee.projectEmployee.Any(item =>
//         item.ProjectID == peobj.ProjectID &&
//         item.EmployeeId == peobj.EmployeeId );
//         Assert.IsFalse(containsItem);
//         System.Console.WriteLine("Test Passed");

//     }
    
//     [Test]
// public void ViewemployeeProject()
// {
//     ProjectEmployeeProperties peprop = new ProjectEmployeeProperties()
//     {
//       ProjectID = 1,
//       EmployeeId = 1,
//       RoleID = 1,    
//     };
  
//     ProjectEmployee.projectEmployee.Add(peprop);

//     List<ProjectEmployeeProperties> projectEmployees = Consoles.ViewProjectEmployees();

//     Assert.IsTrue (ProjectEmployee.projectEmployee.Contains(peprop));
 
// }

}