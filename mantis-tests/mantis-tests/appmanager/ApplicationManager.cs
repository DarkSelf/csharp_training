using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected ProjectHelper projectHelper;

        public APIHelper APIHelper { get; set; }

        protected ManagementMenuHelper navigator;

        public FtpHelper Ftp { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();



        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/mantisbt-2.10.0/";
            //Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            loginHelper = new LoginHelper(this);
            navigator = new ManagementMenuHelper(this);
            projectHelper = new ProjectHelper(this);
            APIHelper = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;

        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public ManagementMenuHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public ProjectHelper Projects
        {
            get
            {
                return projectHelper;
            }
        }


        public APIHelper Api
        {
            get
            {
                return APIHelper;
            }
        }
    }
}

