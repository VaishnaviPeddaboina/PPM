

using System;
using System.IO;
using System.Xml.Serialization;


namespace PPM.Model
{
    public class ProjectProperties
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }

        [XmlIgnore] // Ignore the DateOnly properties during serialization
        public DateOnly StartDate { get; set; }

        [XmlIgnore]
        public DateOnly EndDate { get; set; }

        [XmlElement("Startdate")]
        public string StartdateString
        {
            get { return StartDate.ToString(); }
            set { StartDate = DateOnly.Parse(value); }
        }

        [XmlElement("Enddate")]
        public string EnddateString
        {
            get { return EndDate.ToString(); }
            set { EndDate = DateOnly.Parse(value); }
        }

        public override string ToString()
        {
            string str = string.Format("{0},{1},{2},{3}", ProjectId, ProjectName, StartDate, EndDate);
            return str;
        }
    }

}