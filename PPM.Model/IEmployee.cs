using System;
using System.Numerics;

namespace PPM.Model
{
    
public interface IEmployee
{
    public  void AddEmployee();
    public  void ViewEmployees();
    public  List<EmployeeProperties> ViewEmployeesById();
    public void EmployeeDelete();

}

public interface IEmployeeDomain
{
    public  void AddEmployees(EmployeeProperties empobj);
     public  void  DeleteEmployee(int EmployeeId);
}
}