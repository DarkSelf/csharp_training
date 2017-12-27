using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITTLE;
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            WINTITTLE = ApplicationManager.WINTITTLE;
            this.aux = manager.Aux;
        }
    }
}