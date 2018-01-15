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
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        { }

        public void GoToManagementOverviewPage()
        {
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
        }
        public void GoToProjectManagementPage()
        {
            if (!IsElementPresent(By.XPath("//button[@type='submit']")))
            {
                GoToManagementOverviewPage();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                   .Until(d => d.FindElements(By.XPath("//a[contains(text(),'Управление проектами')]")).Count > 0);
                driver.FindElement(By.XPath("//a[contains(text(),'Управление проектами')]")).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                   .Until(d => d.FindElements(By.XPath("//button[@type='submit']")).Count > 0);
            }
        }
    }
}
