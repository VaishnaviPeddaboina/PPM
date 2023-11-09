using PPM.Model;
using PPM.Domain;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
namespace PPM.Ui.Consoles
{
    
public class EmployeeConsoles 
{
     public static void EmployeeModule()
    {       
    
        
        int selectOption = 0;
 
        do{
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("  \n ");
            Console.WriteLine ("-----------------------------EMPLOYEE MODULE-----------------------------");
            Console.ResetColor();
            Console.WriteLine("  \n ");
            Console.WriteLine("************************************************************************************");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("           1.Add Employee           ");
            Console.WriteLine("           2.View Employee           ");
            Console.WriteLine("           3.View Employee By Id            ");
            Console.WriteLine("           4.Delete Employee By Id            ");
            Console.WriteLine("           5.Return To Main Menu            ");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine("************************************************************************************");

            Console.WriteLine("Enter your Option");

            selectOption = int.Parse(Console.ReadLine() ?? string.Empty);
            
            EmployeeRepo employeeRepo = new EmployeeRepo();
            switch(selectOption)
            {
                case 1 :
                        employeeRepo.AddEmployee();
                          break;
                case 2 :
                       employeeRepo.ViewEmployees();
                       break;

                case 3 :
                        employeeRepo.ViewEmployeesById();
                         break;
               case 4 :
                        employeeRepo.EmployeeDelete();
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


            