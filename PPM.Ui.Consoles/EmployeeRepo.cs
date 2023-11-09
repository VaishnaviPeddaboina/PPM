using PPM.Model;
using PPM.Domain;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
namespace PPM.Ui.Consoles
{
public class EmployeeRepo 
{
  Employee employee = new Employee();
  Employee employeeobject = new Employee();
  public  void AddEmployee()
  {
    Console.WriteLine("Enter the no. of employees you want to add");
    int l = int.Parse(Console.ReadLine() ?? string.Empty);
    for(int i = 0 ; i< l ; i++)
    { 
      EmployeeProperties empobj = new EmployeeProperties();
      int employeeId ;
      while(true)
      {
        while(true)
        {
          Console.WriteLine("Enter the Employee Id ");
          employeeId = int.Parse(Console.ReadLine() ?? string.Empty);
          if(employeeId <= 0)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("--------Invalid employee Id-------");
            Console.ResetColor();
          }
          else
          {
            break;
          }
        }
        var existingEmployee = Employee.empList.Find(emp => emp.EmployeeId == employeeId);
        if (existingEmployee != null)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          System.Console.WriteLine("---------Employee already exists--------");  
          Console.ResetColor();     
        }
        else
        {
          empobj.EmployeeId = employeeId;
          break;
        }         
      }
      Console.WriteLine("Enter First Name");
      empobj.FirstName = Console.ReadLine() ?? string.Empty;
      Console.WriteLine("Enter Last Name ");
      empobj.LastName = Console.ReadLine() ?? string.Empty;
      while(true)
      {
        Console.WriteLine("Enter EmailId ");
        string Email = Console.ReadLine() ?? string.Empty;
        if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|in|co.in)$"))
        {
          Console.ForegroundColor = ConsoleColor.Red;
          System.Console.WriteLine("----Incorrect email format. Please try again!----");
          Console.ResetColor();  
        }
        else
        {
          empobj.Email = Email;
          break;
        }
      }
      while(true)
      {
        Console.WriteLine("Enter Mobile Number ");
        BigInteger MobileNum = BigInteger.Parse(Console.ReadLine() ?? string.Empty);
        if (MobileNum.ToString().Length < 10  || MobileNum.ToString().Length > 10 || MobileNum < 0 )
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("------Invalid Mobile Number------");    
          Console.ResetColor();       
        }
        else
        {
          empobj.MobileNum = MobileNum;
          break;
        }
      }
      Console.WriteLine("Enter Address");
      empobj.Address = Console.ReadLine() ?? string.Empty;
      if(Role.roleList.Count == 0)
      {
        empobj.RoleId= 0;
      }
      else
      {
        while(true)
          {
            Console.WriteLine("Enter Role ID ");
            int RoleId = int.Parse(Console.ReadLine() ?? string.Empty);
            var RoleExist = Role.roleList.Find(p => p.RoleId == RoleId);
            if(RoleExist != null)
            {
              empobj.RoleId= RoleId;
              break;
            }
            else
            {
              System.Console.WriteLine();
              System.Console.WriteLine("Enter Proper Role ID");
            }
          }
      }
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine("-------------Employee Added-------------");
      Console.ResetColor();         
      employeeobject.AddEntity(empobj);
     }
  }

  public   List<EmployeeProperties> ViewEmployees()
  {
    List<EmployeeProperties> employees = new List<EmployeeProperties>();

    if (employee.ListAll().Count == 0)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("--------------NO Existing Employees----------------");
      Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
        foreach (EmployeeProperties item in employee.ListAll())
        {          
            Console.WriteLine("Employee Id : {0}   Employee First Name : {1}   Employee Last Name : {2}   Email : {3}   Mobile Number : {4}   Address : {5}   RoleId : {6}", item.EmployeeId, item.FirstName, item.LastName, item.Email, item.MobileNum, item.Address, item.RoleId);
            employees.Add(item); 
        }
         Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
     Console.ResetColor();
    }
    return Employee.empList;
  }


  public  List<EmployeeProperties> ViewEmployeesById()
  {
    System.Console.WriteLine("Enter the Employee Id");
    int Id = int.Parse(Console.ReadLine() ?? string.Empty);
    int EmployeeById = Employee.empList.FindIndex(p => p.EmployeeId == Id);
    if (EmployeeById >= 0)
    {
      EmployeeProperties item = Employee.empList[EmployeeById];
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
      Console.WriteLine("Employee Id : {0}   First Name : {1}   Last Name : {2}   Email : {3}   Mobile Number : {4}   Address : {5}   Role Id : {6}", item.EmployeeId, item.FirstName, item.LastName,item.Email,item.MobileNum,item.Address,item.RoleId);
      Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
      Console.ResetColor();   
    } 
    else
    {
      Console.ForegroundColor = ConsoleColor.Red;
      System.Console.WriteLine(" --------Employee Id doesn't exists ----------");
      Console.ResetColor();
    }
    return Employee.empList;
  } 
  public void EmployeeDelete()
  {
    System.Console.WriteLine("Enter Employee Id ");
    int EmployeeId = int.Parse(Console.ReadLine() ?? string.Empty);
    var EmployeeDelete = Employee.empList.Find(p => p.EmployeeId == EmployeeId );
    var employeeProjectExist = ProjectEmployee.projectEmployee.Find(p => p.EmployeeId == EmployeeId);
    if(employeeProjectExist != null &&  EmployeeDelete != null)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      System.Console.WriteLine("-----Employee exists in project-----");
      Console.ResetColor();
    }
    else if(EmployeeDelete == null )
    {
      Console.ForegroundColor = ConsoleColor.Red;
      System.Console.WriteLine("----- Employee doesn't exists -----");
      Console.ResetColor();
    }
    else
    {
    employeeobject.Delete(EmployeeId);
    Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine("-----------Employee Deleted-----------");
    Console.ResetColor();
   }
  }
 }
}