using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using PPM.Ui.Consoles;
using PPM.Domain;

namespace PPM.Ui.Consoles
{

public class ProgramConsoles
{
    public static int ProgramMethod()
    {
        
         Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine ("-----------------------------PROLIFICS PROJECT MANAGER-----------------------------");

            Console.ResetColor();

            Console.WriteLine("  \n ");
            Console.WriteLine("************************************************************************************");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("           1.Project Module           ");
            Console.WriteLine("           2.Employee Module           ");
            Console.WriteLine("           3.Role Module           ");
            Console.WriteLine("           4.Save           ");
            Console.WriteLine("           5.Ouit            ");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine("************************************************************************************");

            
            Console.WriteLine("Enter your Option");

            int selectOption = int.Parse(Console.ReadLine() ?? string.Empty);
            return selectOption;
    }
    public static void ExitMethod()
    {
        System.Console.WriteLine("Exit the Application");
    }

    public static void DefaultMethod()
    {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine("------Invalid Option-------");
         Console.ResetColor();
         Console.WriteLine("Enter Appropiate Option");
    }
    public static void ConsoleMethod()
    {
          Console.WriteLine(" ");
           Console.ForegroundColor = ConsoleColor.DarkMagenta;
           Console.WriteLine("enter yes to continue");
           Console.ResetColor();
           Console.ReadLine();
    }
}
}