using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;

        public string allContactData;

        public ContactData()
        {
        }

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
            return "firstname=" + FirstName + " " + "lastname=" + LastName + " " + "address=" + Address;
        }

        [Column(Name = "firstname")]

        public string FirstName { get; set; }

        [Column(Name = "lastname")]

        public string LastName { get; set; }

        [Column(Name = "address")]

        public string Address { get; set; }

        [Column(Name = "home")]

        public string HomePhone { get; set; }

        [Column(Name = "mobile")]

        public string MobilePhone { get; set; }

        [Column(Name = "work")]

        public string WorkPhone { get; set; }

        [Column(Name = "email")]

        public string Email { get; set; }

        [Column(Name = "email2")]

        public string Email2 { get; set; }

        [Column(Name = "email3")]

        public string Email3 { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]

        public string Id { get; set; }

        [Column(Name = "deprecated")]

        public string Deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000 - 00 - 00 00:00:00") select c).ToList();
            }
        }

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

        public string AllContactData
        {
            get
            {
                string InfoContacts = "";

                if (!String.IsNullOrEmpty(FirstName))
                {
                    InfoContacts += FirstName += " ";
                }

                if (!String.IsNullOrEmpty(LastName))
                {
                    InfoContacts += LastName + "\r\n";
                }
                if (!String.IsNullOrEmpty(Address))
                {
                    InfoContacts += Address + "\r\n";
                }

                if (FirstName != null || LastName != null || Address != null)
                {
                    InfoContacts += "\r\n";
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

                if (HomePhone != null || MobilePhone != null || WorkPhone != null)
                {
                    InfoContacts += "\r\n";
                }


                if (!String.IsNullOrEmpty(Email))
                {
                    InfoContacts += Email + "\r\n";
                }
                if (!String.IsNullOrEmpty(Email2))
                {
                    InfoContacts += Email2 + "\r\n";
                }
                if (!String.IsNullOrEmpty(Email3))
                {
                    InfoContacts += Email3 + "\r\n";
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
