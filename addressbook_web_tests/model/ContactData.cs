using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Xml.Serialization;

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
        [JsonIgnore]
        public string Id { get; set; }
        public string FirstName {get; set;}
        public string MiddleName {get; set;} 
        public string LastName {get; set;}
        [JsonIgnore]
        public string NickName { get; set; }
        [JsonIgnore]
        public string Address {get; set;}
        [JsonIgnore]
        public string HomePhone {get; set;}
        [JsonIgnore]
        public string MobilePhone {get; set;}
        [JsonIgnore]
        public string WorkPhone {get; set;}
        [JsonIgnore]
        public string FaxPhone { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        [JsonIgnore]
        public string Email2 { get; set; }
        [JsonIgnore]
        public string Email3 { get; set; }

        [JsonIgnore, XmlIgnore]        
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
            set { allPhones = value; }       
        }
        [JsonIgnore, XmlIgnore]
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

        [JsonIgnore, XmlIgnore]
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
            set { allData = value; }
        }
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
            string emails = "\r\n";
            if (email == null || email == "")
            {
                emails += $"";
            }
            else
            {
                emails += $"\r\n{email}";
            }
            if (email2 == null || email2 == "")
            {
                emails += $"";
            }
            else
            {
                emails += $"\r\n{email2}";
            }
            if (email3 == null || email3 == "")
            {
                emails += $"";
            }
            else
            {
                emails += $"\r\n{email3}";
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
