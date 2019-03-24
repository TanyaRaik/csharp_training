using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace mantis_tests
{
    [TestFixture]
    public class RemovalProjectTests : Auth_TestBase
    {
        [Test]
        public void TestRemovalProject()
        {
            List<ProjectData> oldList = app.Project.GetProjects();
            if (oldList.Count() < 1)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "project"
                };


                app.Project.AddProject(project);
            }


            ProjectData existingProject = oldList[0];

            oldList = app.Project.GetProjects();
            app.Project.Remove(existingProject);

            List<ProjectData> newList = app.Project.GetProjects();

            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}