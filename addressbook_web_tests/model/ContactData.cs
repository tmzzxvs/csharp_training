using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
        {
        private string allPhones;
        private string allEmails;
        private string allData;
        public ContactData(string firstname)
            {
                FirstName = firstname;
            }
        public ContactData()
        {         
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
            return FirstName == other.FirstName
                 && LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }
        public override string ToString()
        {
            return " Firstname = " + FirstName + "\n" + "Lastname=" + LastName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName)!=0 ? FirstName.CompareTo(other.FirstName) : LastName.CompareTo(other.LastName);
        }
        public string FirstName {get; set;}
        public string MiddleName {get; set;} 
        public string LastName {get; set;}
        public string Address {get; set;}
        public string HomePhone {get; set;}
        public string MobilePhone {get; set;}
        public string WorkPhone {get; set;}
        public string Id {get; set;}
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return CleanUp(allData).Trim();
                }
                else
                {
                    return (CleanUp(FirstName) + CleanUp(MiddleName) + CleanUp(LastName) + CleanUp(Address)
                         + CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)
                         + CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set { allData = value; }
        }

        public string AllPhones
        {
            get 
            {
                if (allPhones != null)
                {
                    return CleanUp(allPhones).Trim();
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set { allPhones = value; }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return CleanUp(allEmails).Trim();
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set { allEmails = value; }
        }

        private string CleanUp(string values)
        {
            if (values == null || values == "")
            {
                return "";
            }
            return Regex.Replace(values, "[\\^H:$\\^M:$\\^W:$ \\r\\n()-]", "");
        }
    }
}
