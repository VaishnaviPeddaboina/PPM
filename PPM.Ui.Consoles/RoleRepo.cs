using PPM.Model;
using PPM.Dal;
using PPM.Domain;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
namespace PPM.Ui.Consoles
{
  public class RoleRepo : IRole
  {
    Role roleobject = new Role();
    public void AddRole()
    {
      Console.WriteLine("Enter the no. of roles you want to add");
      int length = int.Parse(Console.ReadLine() ?? string.Empty);
      for (int i = 0; i < length; i++)
      {
        RoleProperties roleobj = new RoleProperties();
        int RoleId;
        while (true)
        {
          while (true)
          {
            Console.WriteLine("Enter the Role Id ");
            RoleId = int.Parse(Console.ReadLine() ?? string.Empty);
            if (RoleId <= 0)
            {
              Console.ForegroundColor = ConsoleColor.Red;
              System.Console.WriteLine("-----Invalid Role Id-----");
              Console.ResetColor();
            }
            else
            {
              break;
            }
          }
          RoleDal roleDal = new RoleDal();
          if (roleDal.IsValidRoleId(RoleId))
          {
            roleobj.RoleId = RoleId;
            break;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("---------Role already exists--------");
            Console.ResetColor();
          }


        }
        Console.WriteLine("Enter the Role Name");
        roleobj.RoleName = Console.ReadLine() ?? string.Empty;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(" -------------Role Added-------------");
        Console.ResetColor();
        roleobject.AddEntity(roleobj);

      }
    }
    public void ViewRole()
    {
      //  List<RoleProperties> roles = new List<RoleProperties>();
      Role role = new Role();
      if (role.ListAll().Count == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("-----------------NO Existing roles--------------");
        Console.ResetColor();
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("----------------------------------------------------------");
        foreach (RoleProperties item in role.ListAll())
        {
          Console.WriteLine("Role Id : {0}   Role Name : {1}", item.RoleId, item.RoleName);
          // roles.Add(item);
        }
        Console.WriteLine("----------------------------------------------------------");
        Console.ResetColor();
      }

    }
    public void ViewRoleById()
    {
      System.Console.WriteLine("Enter the Role Id");
      int Id = int.Parse(Console.ReadLine() ?? string.Empty);
      Role role = new Role();
      List<RoleProperties> result = role.ListById(Id);
      if (result.Count > 0)
      {
        foreach (RoleProperties item in result)
        {
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine("-----------------------------------------------------------------------------------------------");
          Console.WriteLine("Role Id : {0}   Role Name : {1}", item.RoleId, item.RoleName);
          Console.WriteLine("-------------------------------------------------------------------------------------------------");
          Console.ResetColor();
        }
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(" --------Role Id doesn't exists ----------");
        Console.ResetColor();
      }

    }
    public void DeleteRole()
    {
      System.Console.WriteLine("Enter Role Id ");
      int RoleId = int.Parse(Console.ReadLine() ?? string.Empty);
      Role role = new Role();
      EmployeeDal employee = new EmployeeDal();
    while(true)
    {
      if (employee.IsRoleExist(RoleId))
      {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("-----------Role has Employees-----------");
        Console.ResetColor();
        break;
      }
      
      bool roleDelete = role.Delete(RoleId);
      if (roleDelete)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("----- Role Deleted -----");
        Console.ResetColor();
        break;
       
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("-----------Role doesn't exist-----------");
        Console.ResetColor();
        break;
        
      }
      
    }
    }
  }
}