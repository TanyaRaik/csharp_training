using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddProjectTests : Auth_TestBase
    {
        [Test]
        public void TestAddProject()
        {
            List<ProjectData> oldList = app.Project.GetProjects();

            ProjectData newProject = new ProjectData()
            {
                Name = "project",
            };

            oldList = app.Project.GetProjects();
            app.Project.AddProject(newProject);
            List<ProjectData> newList = app.Project.GetProjects();

            oldList.Add(newProject);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
