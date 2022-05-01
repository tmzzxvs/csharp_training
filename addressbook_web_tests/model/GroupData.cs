﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>
    {
        private string name;
        private string header = null;
        private string footer = null;

        public GroupData(string name)
            {
                this.name = name;
            }
        public bool Equals(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        public string Name 
            { 
                get { return name; }
                set { name = value; }
            }

        public string Header 
            {
                get { return header; } 
                set { header = value; }
            }

        public string Footer
            {
                get { return footer; }
                set { footer = value; }
            }
    }   
}
