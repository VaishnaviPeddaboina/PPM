using PPM.Model;
using PPM.Domain;
using PPM.Dal;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
namespace PPM.Ui.Consoles
{
  public class EmployeeRepo
  {
    // Employee employee = new Employee();
    Employee employeeobject = new Employee();
    public void AddEmployee()
    {
      Console.WriteLine("Enter the no. of employees you want to add");
      int l = int.Parse(Console.ReadLine() ?? string.Empty);
      for (int i = 0; i < l; i++)
      {
        EmployeeProperties empobj = new EmployeeProperties();
        int employeeId;
        while (true)
        {
          while (true)
          {
            Console.WriteLine("Enter the Employee Id ");
            employeeId = int.Parse(Console.ReadLine() ?? string.Empty);

            if (employeeId <= 0)
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
          EmployeeDal employeeDal = new EmployeeDal();
          if (employeeDal.IsValidEmployeeId(employeeId))
          {

            empobj.EmployeeId = employeeId;
            break;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("---------Employee already exists--------");
            Console.ResetColor();
          }
        }
        Console.WriteLine("Enter First Name");
        empobj.FirstName = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter Last Name ");
        empobj.LastName = Console.ReadLine() ?? string.Empty;
        while (true)
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
        while (true)
        {
          Console.WriteLine("Enter Mobile Number ");
          BigInteger MobileNum = BigInteger.Parse(Console.ReadLine() ?? string.Empty);
          if (MobileNum.ToString().Length < 10 || MobileNum.ToString().Length > 10 || MobileNum < 0)
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
        while (true)
        {
          Console.WriteLine("Enter Role ID ");
          int roleId = int.Parse(Console.ReadLine() ?? string.Empty);
          RoleDal roleDal = new RoleDal();
             if(roleDal.ViewRoleDal().Count() == 0 )
           {
              empobj.RoleId = 0;
              return;
           }
          if (roleDal.IsValidRoleId(roleId))
          {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("---------Enter proper Role Id--------");
            Console.ResetColor();
          }
          else
          {
            empobj.RoleId = roleId;
            break;
          }
        }

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("-------------Employee Added-------------");
        Console.ResetColor();
        employeeobject.AddEntity(empobj);
      }
    }

    public void ViewEmployees()
    {
      Employee employee = new Employee();

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

        }
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
        Console.ResetColor();
      }

    }


    public void ViewEmployeesById()
    {
      System.Console.WriteLine("Enter the Employee Id");
      int Id = int.Parse(Console.ReadLine() ?? string.Empty);
      Employee employee = new Employee();
      List<EmployeeProperties> result = employee.ListById(Id);
      if (result.Count > 0)
      {
        foreach (EmployeeProperties item in result)
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
          Console.WriteLine("Employee Id : {0}   First Name : {1}   Last Name : {2}   Email : {3}   Mobile Number : {4}   Address : {5}   Role Id : {6}", item.EmployeeId, item.FirstName, item.LastName, item.Email, item.MobileNum, item.Address, item.RoleId);
          Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
          Console.ResetColor();
        }
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(" --------Employee Id doesn't exists ----------");
        Console.ResetColor();
      }

    }
    public void EmployeeDelete()
    {
      System.Console.WriteLine("Enter Employee Id ");
      int EmployeeId = int.Parse(Console.ReadLine() ?? string.Empty);
      Employee employee = new Employee();
      EmployeeDal emp = new EmployeeDal();
      while(true)
      {
        if(emp.IsEmployeeExistsinProject(EmployeeId))
        {
           Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("-----------Employee is in Project-----------");
            Console.ResetColor();
            break;
        }
      
      bool EmployeeDelete = employee.Delete(EmployeeId);
      if (EmployeeDelete)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("-----------Employee Deleted-----------");
        Console.ResetColor();
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("----- Employee doesn't exists -----");
        Console.ResetColor();
      }
      }
    }
  }
}