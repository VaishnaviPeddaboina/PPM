using PPM.Model;
using PPM.Dal;

public class Role : IEntityOperation<RoleProperties>
{
  public static List<RoleProperties> roleList = new List<RoleProperties>();
  public void AddEntity(RoleProperties roleobj)
  {
    //    roleList.Add(roleobj);
    RoleDal roleDal = new RoleDal();
    roleDal.AddRole(roleobj);
  }

  public List<RoleProperties> ListAll()
  {
    RoleDal roleDal = new RoleDal();
    var roleList = roleDal.ViewRoleDal();
    return roleList;
  }
  public List<RoleProperties> ListById(int id)
  {
    RoleDal roleDal = new RoleDal();
    var roleList = roleDal.ViewRoleByIdDal(id);
    return roleList;
  }
  public bool Delete(int RoleId)
  {
    RoleDal roleDal = new RoleDal();
    bool roleList = roleDal.DeleteRoleByIdDal(RoleId);
    return roleList;
  }


}