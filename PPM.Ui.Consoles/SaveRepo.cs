using System.IO;
using System.Xml.Serialization;
using PPM.Model;
using PPM.Domain;

namespace PPM.Ui.Consoles
{
    public class SaveRepo
    {
       public static void SavingMethod()
       {  
           Save.SaveProject();
           System.Console.WriteLine("saved");
       }
    }
   
}