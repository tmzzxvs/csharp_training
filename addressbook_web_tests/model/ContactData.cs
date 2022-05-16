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
            return " Firstname= " + FirstName + "\nLastname= " + LastName + "\nMiddleName= " + MiddleName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName)!=0 ? FirstName.CompareTo(other.FirstName) : LastName.CompareTo(other.LastName);        }
        private string CleanUp(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            return Regex.Replace(value, "[ ()-]", "") + "\r\n";
        }
        public string Id { get; set; }
        public string FirstName {get; set;}
        public string MiddleName {get; set;} 
        public string LastName {get; set;}
        public string NickName { get; set; }
        public string Address {get; set;}
        public string HomePhone {get; set;}
        public string MobilePhone {get; set;}
        public string WorkPhone {get; set;}
        public string FaxPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhones
        {
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
            set { allPhones = value; }        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set { allEmails = value; }
        }
        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    return
                        DetailFIOFields(FirstName) +
                        DetailFIOFields(MiddleName) +
                        DetailFIOFields(LastName).Trim() +
                        DetailFields(NickName) +
                        DetailFields(Address) +
                        DetailPhonesFields(HomePhone, MobilePhone, WorkPhone, FaxPhone) +
                        DetailEmailsFields(Email, Email2, Email3);
                }
            }
            set { allData = value; }        }
        private string DetailFIOFields(string value)
        {
            if (value == null || value == "")
            {
                return $"";
            }
            else
            {
                return $"{ value } ";
            }
        }
        private string DetailFields(string value)
        {
            if (value == null || value == "")
            {
                return $"".Trim();
            }
            else
            {
                return $"\r\n{ value }";
            }
        }
        private string DetailPhonesFields(string home, string mobile, string work, string fax)
        {
            string phones = "\r\n\r\n";
            if (home == null || home == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"H: { home }\r\n";
            }
            if (mobile == null || mobile == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"M: { mobile }\r\n";
            }
            if (work == null || work == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"W: { work }\r\n";
            }
            if (fax == null || fax == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"F: { fax }";
            }
            if ((home == null || home == "") && (mobile == null || mobile == "") && (work == null || work == "") && (fax == null || fax == ""))
            {
                return $"";
            }
            else
            {
                return phones;
            }
        }
        private string DetailEmailsFields(string email, string email2, string email3)
        {
            string emails = "\r\n\r\n";
            if (email == null || email == "")
            {
                emails += $"";
            }
            else
            {
                emails += $"{ email }\r\n";
            }
            if (email2 == null || email2 == "")
            {
                emails += $"";
            }
            else
            {
                emails += $"{ email2 }\r\n";
            }
            if (email3 == null || email3 == "")
            {
                emails += $"";
            }
            else
            {
                emails += $"{ email3 }";
            }
            if ((email == null || email == "") && (email2 == null || email2 == "") && (email3 == null || email3 == ""))
            {
                return $"";
            }
            else
            {
                return emails;
            }
        }
    }
}
