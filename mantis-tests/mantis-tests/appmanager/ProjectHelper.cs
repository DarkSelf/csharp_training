using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        { }

        public List<ProjectData> GetProjectsList()
        {

            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToProjectManagementPage();
            ICollection<IWebElement> elements = driver.FindElement(By.ClassName("table"))
                .FindElement(By.TagName("tbody"))
                .FindElements(By.TagName("tr"));

            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.FindElement(By.XPath(".//td[1]")).Text));
            }

            return projects;
        }

        internal ProjectHelper Remove(int p)
        {
            manager.Navigator.GoToProjectManagementPage();
            SelectProject(p);
            InitProjectRemoving();
            SubmitProjectRemoving();
            return this;
        }

        private ProjectHelper SubmitProjectRemoving()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
              .Until(d => d.FindElements(By.XPath("//input[@value='Удалить проект']")).Count > 0);
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            return this;
        }

        private ProjectHelper InitProjectRemoving()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
              .Until(d => d.FindElements(By.XPath("//input[@value='Удалить проект']")).Count > 0);
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            return this;
        }

        private ProjectHelper SelectProject(int index)
        {
            driver.FindElement(By.TagName("tbody")).FindElements(By.XPath(".//a[@href]"))[index].Click();
            return this;
        }

        public ProjectHelper Create(ProjectData project)
        {
            manager.Navigator.GoToProjectManagementPage();
            InitProjectCreation();
            FillProjectForms(project);
            SubmitProjectCreation();
            ReturnToProjectsPage();
            return this;
        }

        public int GetProjectCount()
        {
            return driver.FindElement(By.ClassName("table"))
                .FindElement(By.TagName("tbody"))
                .FindElements(By.TagName("tr")).Count;
        }

        public ProjectHelper ReturnToProjectsPage()
        {
            driver.FindElement(By.LinkText("Продолжить")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.XPath("//a[contains(text(),'Управление проектами')]")).Count > 0);
            return this;
        }

        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            return this;
        }

        public ProjectHelper FillProjectForms(ProjectData project)
        {
            Type(By.Name("name"), project.projectName);
            return this;
        }

        public ProjectHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.Name("name")).Count > 0);
            return this;
        }
    }
}
