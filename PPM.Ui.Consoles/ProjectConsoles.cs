using PPM.Model;
using PPM.Domain;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
namespace PPM.Ui.Consoles
{
    
public class ProjectConsoles 
{
     public static void ProjectModule()
    {       
    
        
        int selectOption = 0;
 
        do{
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("  \n ");
            Console.WriteLine ("-----------------------------PROJECT MODULE-----------------------------");

            Console.ResetColor();

            Console.WriteLine("  \n ");
            Console.WriteLine("************************************************************************************");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("           1.Add Project           ");
            Console.WriteLine("           2.View Project           ");
            Console.WriteLine("           3.View Project By Id            ");
            Console.WriteLine("           4.Delete Project By Id            ");
            Console.WriteLine("           5.Return To Main Menu            ");
            Console.ResetColor();
            Console.WriteLine(" ");
            Console.WriteLine("************************************************************************************");

            
            Console.WriteLine("Enter your Option");

            selectOption = int.Parse(Console.ReadLine() ?? string.Empty);
            ProjectRepo projectRepo = new ProjectRepo();
            switch(selectOption)
            {
                case 1 :
                           projectRepo.AddProjectAndEmployee();           
                            break;
                case 2 :
                           projectRepo.ViewProjects();             
                            break;
                case 3 :
                          projectRepo.ViewProjectsById();
                            break;
                case 4 :
                          projectRepo.ProjectDelete();
                            break;

                case 5 :
                            return;
            
                default :
                            Console.ForegroundColor =ConsoleColor.Red;
                            Console.WriteLine("------Invalid Option-----");
                            Console.ResetColor();
                            Console.WriteLine("Enter Appropiate Option");
                            break;
           }

        }while(selectOption != 5);
    }



}
}

