using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]

    class ProjectRemovalTests : AuthTestBase
    {


        [Test]

        public void ProjectRemovalTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData projectData = new ProjectData()
            {
                projectName = "ProjectForRemove"
            };

            app.Api.CreateProjectIfProjectListEmpty(account, projectData);

            List<ProjectData> oldProjects = app.Api.GetAllProjects(account);



            app.Projects.Remove(0);

            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectCount());

            List<ProjectData> newProjects = app.Api.GetAllProjects(account);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}
