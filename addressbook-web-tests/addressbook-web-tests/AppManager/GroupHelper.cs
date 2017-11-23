using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
   public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {}

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForms(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper CreateGroupIsGroupListEmpty()
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsGroupPresent())
            {
                GroupData group = new GroupData("qwe");
                group.Header = "rty";
                group.Footer = "uio";
                Create(group);
            }
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            SelectGroup(p);
            InitGroupModification();
            FillGroupForms(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        private bool IsGroupPresent()
        {
            return IsElementPresent((By.ClassName("group")));
        }

        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForms(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

    }
}
