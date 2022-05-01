using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
        {
        private string firstname;
        private string middlename = null;
        private string lastname = null;

        public ContactData(string firstname)
            {
                this.firstname = firstname;
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
            return Firstname == other.firstname;
       //     return Lastname == other.lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
       //     return Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "Firstname=" + Firstname;
      //      return "Lastname=" + Lastname;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname);
        //    return Lastname.CompareTo(other.Lastname);
        }
        public string Firstname
            { 
                get { return firstname; }
                set { firstname = value; }
            }
        public string Middlename
            {
                get { return middlename; }
                set { middlename = value; }
            }
        public string Lastname
            {
                get { return lastname; }
                set { lastname = value; }
            }
        }
}
