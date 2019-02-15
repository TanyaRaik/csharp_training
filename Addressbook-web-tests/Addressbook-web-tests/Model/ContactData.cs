﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstName)
        {
                FirstName = firstName;
        }

        public string SNotice { get; set; }
        

        public string SHome { get; set; }
        

        public string SAddress { get; set; }
        

        public string Group { get; set; }
        

        public string AYear { get; set; }
       

        public string AMonth { get; set; }
        

        public string ADay { get; set; }
        

        public string BYear { get; set; }
        

        public string BMonth { get; set; }

        
        public string BDay { get; set; }
        

        public string Homepage { get; set; }
        

        public string Email3 { get; set; }
        

        public string Email2 { get; set; }
        

        public string Email1 { get; set; }
        

        public string Fax { get; set; }
        

        public string Work { get; set; }
        

        public string Mobile { get; set; }
        

        public string Home { get; set; }
        

        public string Address { get; set; }
        

        public string Company { get; set; }
        

        public string Title { get; set; }
        

        public string Nickname { get; set; }
        

        public string FirstName { get; set; }
        

        public string MiddleName { get; set; }
        

        public string LastName { get; set; }


        public string Id { get; set; }


        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return LastName == other.LastName
                &&FirstName == other.FirstName;
        }

        public override int GetHashCode()
        {
            string[] name = new string[] { LastName, FirstName };
            return name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + LastName + FirstName;
        }

        public int CompareTo(ContactData other)
        {
                if (object.ReferenceEquals(other, null))
            {
                return LastName.CompareTo(other.LastName);
            }

            return FirstName.CompareTo(other.FirstName);
        }
    }
}
