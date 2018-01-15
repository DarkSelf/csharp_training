using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace mantis_tests
{

    [TestFixture]

    public class ProjectCreationTests : AuthTestBase
    {
        public static IEnumerable<ProjectData> RandomProjectDataProvider()
        {
            List<ProjectData> projects = new List<ProjectData>();
            for (int i = 0; i < 1; i++)
            {
                projects.Add(new ProjectData()
                {
                    projectName = (GenerateRandomString(30))
                });
            }
            return projects;
        }


        [Test, TestCaseSource("RandomProjectDataProvider")]

        public void ProjectCreationTest(ProjectData project)
        {
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();


            app.Projects.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectCount());

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
            
        }

    }
}
