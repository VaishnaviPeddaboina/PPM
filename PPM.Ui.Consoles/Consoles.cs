
// using PPM.Model;
// using PPM.Domain;
// using System;
// using System.Numerics;
// using System.Text.RegularExpressions;
// namespace PPM.Ui.Consoles
// {
// public class Consoles
// {
 
//      public static void Add_Employee_To_project()
//      {
//  ProjectEmployeeProperties obj = new ProjectEmployeeProperties();
//        int projectid ,employeeId ;
      
//      //ViewProjects();
//       while(true)
//       {
//         System.Console.WriteLine("Enter the Project Id for which the Employees are to be added");
//          projectid = int.Parse(Console.ReadLine() ?? string.Empty);
//          var projectExist = Project.ProjectList.Find(p => p.ProjectId == projectid);
//          if(projectExist != null)
//          {           
//             break;
//          }
//          else{
//             System.Console.WriteLine();
//             System.Console.WriteLine("Enter Appropriate Project Id");
//          }
//       }
//        var query1 = from item in Project.ProjectList
//                     where  item.ProjectId == projectid
//                     select new {item.ProjectId , item.ProjectName};
//         foreach(var item in query1)
//         {
//             projectid = item.ProjectId ;
//             obj.ProjectName = item.ProjectName ;
//         }
//          //ViewEmployees();
//          while(true)
//          {
//             while(true)
//             {
//                 System.Console.WriteLine("Enter the employee id that you want to add");
//                 employeeId = int.Parse(Console.ReadLine() ?? string.Empty);
//                 if(employeeId == 0 )
//                 {
//                     return;
//                 }
//                 var employeeExist = Employee.empList.Find(e => e.EmployeeId == employeeId );
//                 if(employeeExist != null)
//                 {
//                     break;
//                 }
//                 else
//                 {
//                     System.Console.WriteLine();
//                     System.Console.WriteLine("Enter Appropriate employee Id");
//                 }
//             }
//             var employeeProjectExist = ProjectEmployee.projectEmployee.Find(p => p.ProjectID == projectid && p.EmployeeId == employeeId);
//             if(employeeProjectExist != null)
//             {
//                System.Console.WriteLine(" employee already added to project");
//             }
//             else
//             {
//                   var query2 = from item in Employee.empList
//                   where item.EmployeeId == employeeId
//                  select new {item.EmployeeId , item.FirstName ,item.LastName,item.RoleId};
//             foreach(var item in query2)
//             {
//                 employeeId = item.EmployeeId;
//                 obj.FirstName = item.FirstName;
//                 obj.LastName = item.LastName;
//                 obj.RoleID  =  item.RoleId;
//             }
//             break;
//             }
//          }     
//           ProjectEmployee.AddEmployeetoproject( projectid ,  employeeId , obj.RoleID);        
//      }
//     //  public static void Delete_employee_from_Project()
//     //  {
           
//     //         int projectId, employeeId;
//     //        ViewProjects();
//     //         while (true)
//     //         {
//     //             System.Console.WriteLine("Enter ProjectId to remove from project");
//     //             projectId = int.Parse(Console.ReadLine() ?? string.Empty);
//     //             bool projectExist = Project.ProjectList.Any(p => p.ProjectId == projectId);
//     //             if (projectExist)
//     //             {
//     //                 break;
//     //             }
//     //             else
//     //             {
//     //                 System.Console.WriteLine("Enter valid ProjectId");
//     //             }

//     //         }
//     //         bool flag = true;
//     //      ViewEmployees();
//     //         while (flag)
//     //         {
//     //           while(true)
//     //           {
//     //              Console.WriteLine("Enter employeeid to remove from project");

//     //             employeeId = int.Parse(Console.ReadLine() ?? string.Empty);
//     //             bool employeeExists = Employee.empList.Any(e => e.EmployeeId == employeeId);
//     //             if (employeeExists)
//     //             {
//     //                 bool existingEmployee = ProjectEmployee.projectEmployee.Any(p => p.ProjectID == projectId && p.EmployeeId == employeeId);
//     //                 if (existingEmployee)
//     //                 {
//     //                     ProjectEmployee.RemoveEmployeeProjectMethod(projectId, employeeId);
//     //                 }
//     //                 else
//     //                 {
//     //                     System.Console.WriteLine("Employee doesn't exists in the project");
//     //                 }
//     //             }
//     //             else
//     //             {
//     //                 System.Console.WriteLine("Enter valid employeeId");
//     //                 break;
//     //             }
//     //         }
//     //             System.Console.WriteLine("do you want to remove another employee from the project type yes/no");
//     //             string choose = Console.ReadLine() ?? string.Empty; 
//     //             if (choose == "yes")
//     //             {
//     //              flag = true;
//     //             }
//     //             else
//     //             {
//     //                 flag = false;
//     //             }
//     //         }
//     //  }
//     public static List<ProjectEmployeeProperties>  ViewProjectEmployees()
//         {
//             List<ProjectEmployeeProperties> projects = new List<ProjectEmployeeProperties>();
//              if(ProjectEmployee.projectEmployee.Count == 0)
//          {
//           Console.ForegroundColor = ConsoleColor.Red;
//           Console.WriteLine("-------------------No Existing Projects-----------");
//            Console.ResetColor();
          
//          }
//          else
//          {
//           Console.WriteLine("-----------------------------------------------------------------------------------------------");
//         foreach(ProjectEmployeeProperties item in ProjectEmployee.projectEmployee)
//         {
//             Console.WriteLine("Project Id : {0}   Project Name : {1}   Employee ID : {2}   First Name : {3},   Last Name : {4},   Role Id : {5}",item.ProjectID, item.ProjectName,  item.EmployeeId ,item.FirstName,item.LastName,item.RoleID);
//         }
//          Console.WriteLine("-------------------------------------------------------------------------------------------------");
//          }
//          return projects;
//         }
//      }
// }