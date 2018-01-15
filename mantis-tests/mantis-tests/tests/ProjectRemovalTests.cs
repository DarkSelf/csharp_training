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
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            app.Projects.Remove(0);

            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectCount());

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}
