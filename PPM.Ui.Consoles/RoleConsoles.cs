using PPM.Model;
using PPM.Domain;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
namespace PPM.Ui.Consoles
{
    
public class RoleConsoles 
{
     public static void RoleModule()
    {       
    
        
        int selectOption = 0;
 
        do{
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("  \n ");
            Console.WriteLine ("-----------------------------ROLE MODULE-----------------------------");

            Console.ResetColor();

            Console.WriteLine("  \n ");
            Console.WriteLine("************************************************************************************");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("           1.Add Role           ");
            Console.WriteLine("           2.View Role           ");
            Console.WriteLine("           3.View Role By Id            ");
            Console.WriteLine("           4.Delete Role By Id            ");
            Console.WriteLine("           5.Return To Main Menu            ");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine("************************************************************************************");

            Console.WriteLine("Enter your Option");

            selectOption = int.Parse(Console.ReadLine() ?? string.Empty);

            RoleRepo roleRepo = new RoleRepo();

            switch(selectOption)
            {
                         case 1 :
                                    roleRepo.AddRole();
                                    break;
                         case 2 :
                                    roleRepo.ViewRole();
                                    break;
                         case 3 :
                                    roleRepo. ViewRoleById();
                                    break;
                         case 4 :
                                    roleRepo.DeleteRole();
                                    break;
                        case 5 :
                                   return;
                        default :
                                   Console.ForegroundColor = ConsoleColor.Red;
                                   Console.WriteLine("-----Invalid Option-----");
                                   Console.ResetColor();
                                   Console.WriteLine("Enter Appropiate Option");
                                   break; 
            }
        
    }while(selectOption != 5);
  
}
}
}
