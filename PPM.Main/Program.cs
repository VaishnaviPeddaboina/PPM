using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using PPM.Ui.Consoles;
using PPM.Domain;

namespace PPM.Main
{

public class Program
{
 public static void Main(string[] args)
    {       
    
        
        int selectOption = 0;
 
        do{

         selectOption = ProgramConsoles.ProgramMethod();

            switch(selectOption)
            {
                case 1 :
                        ProjectConsoles.ProjectModule();
                        break;
                case 2 :
                         EmployeeConsoles.EmployeeModule();
                        break;
                case 3 :
                        RoleConsoles.RoleModule();               
                        break;
                case 4 :
                        SaveRepo.SavingMethod();
                        break;
                case 5 :
                        ProgramConsoles.ExitMethod();
                        break;
              default :
                        ProgramConsoles.DefaultMethod();
                        break; 
            }
          ProgramConsoles.ConsoleMethod();
        }
        while (selectOption != 5);
    }
}
}