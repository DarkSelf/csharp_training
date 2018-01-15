using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public ProjectData project;

        public APIHelper(ApplicationManager manager) : base(manager)
        { }

        public List<ProjectData> GetAllProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            List<ProjectData> allProjectsList = new List<ProjectData>();

            ICollection<Mantis.ProjectData> elements = client.mc_projects_get_user_accessible(account.Name, account.Password);

            foreach (Mantis.ProjectData element in elements)
            {
                allProjectsList.Add(new ProjectData(element.name));
            }

            return allProjectsList;

        }

        public APIHelper CreateProjectIfProjectListEmpty(AccountData account, ProjectData projectData)
        {
            manager.Navigator.GoToProjectManagementPage();


            if (!IsProjectPresent())
            {
                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.ProjectData project = new Mantis.ProjectData();
                project.name = projectData.projectName;
                client.mc_project_add(account.Name, account.Password, project);
                // Обновление страницы, чтобы увидеть добавленный с помощью API проект
                driver.FindElement(By.XPath("//a[contains(text(),'Управление проектами')]")).Click();
                return this;
            }

            return null;
        }


        public bool IsProjectPresent()
        {
            return IsElementPresent((By.CssSelector("tbody tr a")));                   
        }
    }
}
