using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using PPM.Model;



namespace PPM.Domain
{
    public class Save
    {
        public static void SaveProject()
        {
             XmlSerializer roleserializer = new XmlSerializer(typeof(List<RoleProperties>));
            using(FileStream stream = new FileStream(@"C:\Users\VPeddaboina\Documents\Day09\PPMXml\Role.xml",FileMode.Create , FileAccess.Write))
            {
                roleserializer.Serialize(stream , Role.roleList);
            }
            XmlSerializer projectserializer = new XmlSerializer(typeof(List<ProjectProperties>));
    
            using(FileStream stream = new FileStream(@"C:\Users\VPeddaboina\Documents\Day09\PPMXml\Project.xml" , FileMode.Create , FileAccess.Write))
            {
                projectserializer.Serialize(stream , Project.ProjectList);
            }
            XmlSerializer employeeserializer = new XmlSerializer(typeof(List<EmployeeProperties>));

            using(FileStream stream = new FileStream(@"C:\Users\VPeddaboina\Documents\Day09\PPMXml\Employee.xml",FileMode.Create , FileAccess.Write))
            {
                employeeserializer.Serialize(stream , Employee.empList);
            }
           
 
        }
    }

}