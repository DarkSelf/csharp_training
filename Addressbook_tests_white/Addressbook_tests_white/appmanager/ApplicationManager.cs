using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Addressbook_tests_white
{
    public class ApplicationManager
    {
        public static string WINTITTLE = "Free Address Book";


        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            Application app = Application.Launch(@"C:\Csharp_training\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITTLE);

            groupHelper = new GroupHelper(this);
        }

        public Window MainWindow { get; private set; }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

   

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
    }
}
