﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {        
        public GroupData(string name)
            {
                Name = name;
            }
        public GroupData()
        {
            
        }
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "Name=" + Name + "\nHeader= " + Header + "\nFooter= " + Footer; 
        }
        public int CompareTo(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
        public string Name {get; set;}
        public string Header {get; set;}
        public string Footer {get; set;}
        public string Id {get; set;}

    }   
}
