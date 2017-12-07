using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;

        public string allContactData;



        public ContactData(string firstname)
        {
            FirstName = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;

        }



        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (FirstName != other.FirstName)
            {
                return false;
            }

            return LastName == other.LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }


            if (FirstName != other.FirstName)
            {
                return FirstName.CompareTo(other.FirstName);
            }

            return LastName.CompareTo(other.LastName);
        }



        public override string ToString()
        {
            return "firstname=" + FirstName + " " + "lastname=" + LastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }


        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else

                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }




        //public string AllContactData
        //{

        //    get
        //    {
        //        if (allContactData != null)
        //        {
        //            return allContactData;
        //        }
        //        else

        //        {
        //            return (FirstName + " " + LastName + "\r\n" + Address + "\r\n" + "\r\n" + "H: " + HomePhone + "\r\n" + "M: " + MobilePhone + "\r\n" + "W: " + WorkPhone);
        //        }
        //    }
        //    set
        //    {
        //        allContactData = value;
        //    }
        //}


        public string AllContactData
        {
            get
            {
                string InfoContacts = "";

                if (FirstName != null)
                {
                    InfoContacts += FirstName + " ";
                }
                if (LastName != null )
                {
                    InfoContacts += LastName + "\r\n";
                }
                if (Address != null)
                {
                    InfoContacts += Address + "\r\n\r\n";
                }
                if (!String.IsNullOrEmpty(HomePhone))
                {
                    InfoContacts += "H: " + HomePhone + "\r\n";
                }
                if (!String.IsNullOrEmpty(MobilePhone))
                {
                    InfoContacts += "M: " + MobilePhone + "\r\n";
                }
                if (!String.IsNullOrEmpty(WorkPhone))
                {
                    InfoContacts += "W: " + WorkPhone + "\r\n";
                }
                            
                string InfoContactsCleanUp = InfoContacts.Trim();
                return InfoContactsCleanUp;
            }
        }


            public string CleanUp(string phone)
            {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]", "" )+ "\r\n";
            }


    }
}
