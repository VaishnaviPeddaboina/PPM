using System;
using System.Numerics;

namespace PPM.Model
{
  
public interface IProject
{
        public void AddProjectAndEmployee();
        public  void ViewProjects();
        public  void ViewProjectsById();
        public  void ProjectDelete();
}
  
public interface IProjectDomain
{
    public void AddProject(ProjectProperties obj);
    public void DeleteProject(int ProjectId);
}
}