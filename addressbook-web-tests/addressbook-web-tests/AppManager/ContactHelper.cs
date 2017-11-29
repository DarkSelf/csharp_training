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
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Remove(int p)
        {
            SelectContact(p);
            RemoveContact();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.FindElement(By.XPath("./td[3]")).Text, element.FindElement(By.XPath("./td[2]")).Text));
            }
            return contacts;
        }

        public ContactHelper CreateContactIfContactListEmpty()
        {
            manager.Navigator.GoToHomePage();

            if (!IsContactPresent())
            {
                ContactData contact = new ContactData("asder");
                contact.Lastname = "qwerty";
                Create(contact);
            }
            return this;
        }

        public bool IsContactPresent()
        {
            return IsElementPresent((By.Name("entry")));
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper GoToContactCreationPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
            InitContactModification();
            FillContactForms(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {

                GoToContactCreationPage();
                FillContactForms(contact);
                SubmitContactCreation();
                GoToHomePage();
                return this;
        }

        public ContactHelper FillContactForms(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        public ContactHelper GoToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

    }
}
