using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_tests_white
{ 
        
    public class TestBase
    { 
        public ApplicationManager app;

        [TestFixtureSetUp]

        public void InitApplication()
        {
            app = new ApplicationManager();
        }

        [TestFixtureTearDown]

        public void stopApplicationManager()
        {
            app.Stop();
        }
    }
}
