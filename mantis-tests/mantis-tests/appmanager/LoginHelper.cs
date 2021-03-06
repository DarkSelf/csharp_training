﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        { }


        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Id("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.Id("password")).Count > 0);
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//div[@id='navbar-container']/div[2]/ul/li[3]/a/i[2]")).Click();
                driver.FindElement(By.LinkText("выход")).Click();
            }
        }


        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("navbar"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUsername() == account.Name;
        }

        public string GetLoggedUsername()
        {
            string text = driver.FindElement(By.ClassName("user-info")).Text;
            return text;
        }
    }
}
