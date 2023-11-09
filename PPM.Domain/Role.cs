using PPM.Model;

public class Role : IEntityOperation<RoleProperties>
{
    public static  List<RoleProperties> roleList = new List<RoleProperties>();
      public void AddEntity(RoleProperties roleobj)
    {
       roleList.Add(roleobj);
    }

    public List<RoleProperties> ListAll()
    {
      return roleList;
    }
    public RoleProperties ListById(int id)
    {
      return roleList.Find(r => r.RoleId == id)!;
    }
    public void Delete(int RoleId)
    {
       int remove = Role.roleList.FindIndex(r => r.RoleId == RoleId );

            if (remove >= 0)
            {
                roleList.RemoveAt(remove);
            }
    }
    
    
}