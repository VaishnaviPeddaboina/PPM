
using System;
namespace PPM.Model
{
  public  class RoleProperties
{
    public int RoleId {get ; set;}
    public string ?RoleName {get; set;}
    public override string ToString()
    {
        string str = string.Format("{0},{1}", RoleId, RoleName);
        return str;
    }
}
}
