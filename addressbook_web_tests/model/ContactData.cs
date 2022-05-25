using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Xml.Serialization;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name ="addressbook")]
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
        [JsonIgnore, Column(Name ="id"), PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "firstname")]
        public string FirstName {get; set;}
        [Column(Name = "middlename")]
        public string MiddleName {get; set;}
        [Column(Name = "lastname")]
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
                        DetailFullNameBlock(FirstName, MiddleName, LastName) +
                        DetailFields(DetailFullNameBlock(FirstName, MiddleName, LastName), NickName) +
                        DetailFields(NickName, Address) +
                        DetailPhonesBlock(HomePhone, MobilePhone, WorkPhone, FaxPhone) +
                        DetailEmailsBlock(Email, Email2, Email3);
                }
            }
            set { allData = value; }
        }
        private string DetailFields(string beforefield, string value)
        {

            if (value == null || value == "")
            {
                return $"";
            }
            else
            {
                if (beforefield == null || beforefield == "")
                {
                    return $"{value}";
                }
                else
                {
                    return $"\r\n{value}";
                }

            }
        }
        private string DetailFullNameBlock(string firstname, string middlename, string lastname)
        {
            string fullname = $"";

            if (firstname == null || firstname == "")
            {
                fullname += $"";
            }
            else
            {
                fullname += $"{firstname}";
            }

            if (middlename == null || middlename == "")
            {
                fullname += $"";
            }
            else
            {
                if (firstname == null || firstname == "")
                {
                    fullname += $"{middlename}";
                }
                else
                {
                    fullname += $" {middlename}";
                }
            }

            if (lastname == null || lastname == "")
            {
                fullname += $"";
            }
            else
            {
                if ((firstname == null || firstname == "") && (middlename == null || middlename == ""))
                {
                    fullname += $"{lastname}";
                }
                else
                {
                    fullname += $" {lastname}";
                }
            }
            return fullname;
        }
        private string DetailPhonesBlock(string home, string mobile, string work, string fax)
        {
            string phones = "\r\n";
            if (home == null || home == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"\r\nH: {home}";
            }
            if (mobile == null || mobile == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"\r\nM: {mobile}";
            }
            if (work == null || work == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"\r\nW: {work}";
            }
            if (fax == null || fax == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"\r\nF: {fax}";
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
        private string DetailEmailsBlock(string email, string email2, string email3)
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
