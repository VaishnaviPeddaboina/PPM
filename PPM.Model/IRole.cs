using System;
using System.Numerics;

namespace PPM.Model
{
    
public interface IRole
{
   public  void AddRole();
   public List<RoleProperties> ViewRole();
   public  List<RoleProperties> ViewRoleById();
   public  void DeleteRole();
}

public interface IRoleDomain
{
     public void AddRole(RoleProperties roleobj);
     public void DeleteRole(int RoleId);
}
}