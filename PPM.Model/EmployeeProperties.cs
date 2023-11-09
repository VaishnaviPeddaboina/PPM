using System;
using System.Numerics;
using System.IO;
using System.Xml.Serialization;

namespace PPM.Model
{

public  class EmployeeProperties
{
    public int EmployeeId {get; set;}
    public string ?FirstName {get; set;}
    public string ?LastName {get ; set;}
    public string ?Email {get; set;}
    [XmlIgnore]
    public BigInteger MobileNum {get ; set;}

    [XmlElement("MobileNum")]
    public string StartdateString
    {
        get { return MobileNum.ToString(); }
        set { MobileNum = BigInteger.Parse(value); }
    }

    public string ?Address {get; set;}
    public int RoleId {get; set;}

    public override string ToString()
    {
        string str = string.Format("{0},{1},{2},{3},{4},{5},{6}", EmployeeId, FirstName,LastName,Email,MobileNum,Address,RoleId);
        return str;
    }
}
}

