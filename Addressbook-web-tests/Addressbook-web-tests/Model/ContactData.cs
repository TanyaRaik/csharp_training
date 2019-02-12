using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string middleName = "";
        private string lastName = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email1 = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bDay = "";
        private string bMonth = "";
        private string bYear = "";
        private string aDay = "";
        private string aMonth = "";
        private string aYear = "";
        private string group = "";
        private string sAddress = "";
        private string sHome = "";
        private string sNotice = "";

        public ContactData(string firstName)
        {
            this.firstName = firstName;
        }

        public string SNotice
        {
            get
            {
                return sNotice;
            }
            set
            {
                sNotice = value;
            }
        }

        public string SHome
        {
            get
            {
                return sHome;
            }
            set
            {
                sHome = value;
            }
        }

        public string SAddress
        {
            get
            {
                return sAddress;
            }
            set
            {
                sAddress = value;
            }
        }

        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }

        public string AYear
        {
            get
            {
                return aYear;
            }
            set
            {
                aYear = value;
            }
        }

        public string AMonth
        {
            get
            {
                return aMonth;
            }
            set
            {
                aMonth = value;
            }
        }

        public string ADay
        {
            get
            {
                return aDay;
            }
            set
            {
                aDay = value;
            }
        }

        public string BYear
        {
            get
            {
                return bYear;
            }
            set
            {
                bYear = value;
            }
        }

        public string BMonth
        {
            get
            {
                return bMonth;
            }
            set
            {
                bMonth = value;
            }
        }

        public string BDay
        {
            get
            {
                return bDay;
            }
            set
            {
                bDay = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }

        public string Email1
        {
            get
            {
                return email1;
            }
            set
            {
                email1 = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }

        public string Work
        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }

        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

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
            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "firstName=" + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
        }
    }
}
