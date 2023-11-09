using PPM.Model;
using PPM.Domain;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
namespace PPM.Ui.Consoles
{
public class RoleRepo : IRole
{ 
  Role roleobject = new Role();
       public  void AddRole()
     {
                        Console.WriteLine("Enter the no. of roles you want to add");
                          int length = int.Parse(Console.ReadLine() ?? string.Empty);
                          for(int i = 0 ; i< length ; i++)
                         {
                          RoleProperties roleobj = new RoleProperties();
                          int roleId;
                         while(true)
                         {
                            while(true)
                            {
                         Console.WriteLine("Enter the Role Id ");
                          roleId = int.Parse(Console.ReadLine() ?? string.Empty);
                          if(roleId <= 0)
                          {
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("-----Invalid Role Id-----");
                            Console.ResetColor();
                          }
                          else{
                            break;
                          }
                            }
                         var existingRole = Role.roleList.Find(p => p.RoleId == roleId);

                           if (existingRole != null)
                            {
                            Console.ForegroundColor = ConsoleColor.Red;  
                         System.Console.WriteLine("-----Role already exists-----");
                         Console.ResetColor();

                         }
                        else{
                          roleobj.RoleId = roleId;
                          break;
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
public List<RoleProperties> ViewRole()
{
                         List<RoleProperties> roles = new List<RoleProperties>();
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
                    roles.Add(item);
          }
             Console.WriteLine("----------------------------------------------------------");
             Console.ResetColor();
          }
          return Role.roleList;
}
public  List<RoleProperties> ViewRoleById()
{
          System.Console.WriteLine("Enter the Role Id");
          int Id = int.Parse(Console.ReadLine() ?? string.Empty);
          int RoleById = Role.roleList.FindIndex(p => p.RoleId == Id);
                if (RoleById >= 0)
                {
                   RoleProperties item = Role.roleList[RoleById];
                   Console.ForegroundColor = ConsoleColor.Yellow;  
                   Console.WriteLine("-----------------------------------------------------------------------------------------------");
                   Console.WriteLine("Role Id : {0}   Role Name : {1}", item.RoleId, item.RoleName);
                   Console.WriteLine("-------------------------------------------------------------------------------------------------");
                 Console.ResetColor();   
            } 
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(" --------Role Id doesn't exists ----------");
                Console.ResetColor();
            }
            return Role.roleList;
}
public  void DeleteRole()
{
   System.Console.WriteLine("Enter Role Id ");
                int RoleId = int.Parse(Console.ReadLine() ?? string.Empty);
                  var employeeProjectExist = Employee.empList.Find(p => p.RoleId == RoleId);
                    var roleDelete = Role.roleList.Find(p => p.RoleId == RoleId);
            if(employeeProjectExist != null && roleDelete != null)
            {             
                Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine(" --------Role  has Employees----------");
                    Console.ResetColor();
                }
                else if (roleDelete == null)
                {
                     Console.ForegroundColor = ConsoleColor.Red;
                     System.Console.WriteLine("----- Role doesn't exists -----");
                    Console.ResetColor();
                }
                else
                {
                    roleobject.Delete(RoleId);
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("-----------Role Deleted-----------");
                    Console.ResetColor();             
                }
}
}
}