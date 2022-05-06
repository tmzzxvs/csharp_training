using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
        {
        public ContactData(string firstname)
            {
                Firstname = firstname;
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
            return Firstname == other.Firstname
                 && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return " Firstname = " + Firstname + "\n" + "Lastname=" + Lastname;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname)!=0 ? Firstname.CompareTo(other.Firstname) : Lastname.CompareTo(other.Lastname);
        }
        public string Firstname {get; set;}
        public string Middlename {get; set;} 
        public string Lastname {get; set;}
        public string id {get; set;}

    }
}
