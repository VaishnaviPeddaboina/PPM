using PPM.Model;
using System.Numerics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using PPM.Dal;

public class Employee : IEntityOperation<EmployeeProperties>
 {
public static List<EmployeeProperties> empList = new List<EmployeeProperties>();
    public  void AddEntity(EmployeeProperties empobj)
    {
        //  empList.Add(empobj); 
       EmployeeDal employeeDal = new EmployeeDal();
       employeeDal.AddEmployee(empobj);
    }

    public List<EmployeeProperties> ListAll()
    {
       EmployeeDal employeeDal = new EmployeeDal();
         var empList= employeeDal.ViewEmployeeDal();
         return empList;
    }
    public List<EmployeeProperties> ListById(int id)
    {
           EmployeeDal employeeDal = new EmployeeDal();
         var empList= employeeDal.ViewEmployeeByIdDal(id);
         return empList;
        
    }
    public  bool  Delete(int EmployeeId)
    {
        EmployeeDal employeeDal = new EmployeeDal();
         bool empList= employeeDal.DeleteEmployeeByIdDal(EmployeeId);
         return empList;
    }   
}
