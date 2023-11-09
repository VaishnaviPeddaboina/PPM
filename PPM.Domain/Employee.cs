using PPM.Model;
using System.Numerics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

public class Employee : IEntityOperation<EmployeeProperties>
 {
public static List<EmployeeProperties> empList = new List<EmployeeProperties>();
    public  void AddEntity(EmployeeProperties empobj)
    {
         empList.Add(empobj); 
    }

    public List<EmployeeProperties> ListAll()
    {
        return empList;
    }
    public EmployeeProperties ListById(int id)
    {
        return empList.Find(e => e.EmployeeId == id)!;
    }
    public  void  Delete(int EmployeeId)
    {
      int remove = Employee.empList.FindIndex(r => r.EmployeeId == EmployeeId );
            if (remove >= 0)
            {
                empList.RemoveAt(remove);
            }
    }   
}
