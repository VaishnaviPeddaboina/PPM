using System;
using System.Numerics;

namespace PPM.Model
{
  
public interface IProject
{
        public void AddProjectAndEmployee();
        public  List<ProjectProperties> ViewProjects();
        public  List<ProjectProperties> ViewProjectsById();
        public  void ProjectDelete();
}
  
public interface IProjectDomain
{
    public void AddProject(ProjectProperties obj);
    public void DeleteProject(int ProjectId);
}
}