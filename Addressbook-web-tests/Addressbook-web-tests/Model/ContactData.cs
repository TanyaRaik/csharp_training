using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string info;

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
                FirstName = firstName;
                LastName = lastName;
        }

        [Column(Name = "notes")]
        public string SNotice { get; set; }

        [Column(Name = "phone2")]
        public string SHome { get; set; }

        [Column(Name = "address2")]
        public string SAddress { get; set; }

        [Column(Name = "ayear")]
        public string AYear { get; set; }

        [Column(Name = "amonth")]
        public string AMonth { get; set; }

        [Column(Name = "aday")]
        public string ADay { get; set; }

        [Column(Name = "byear")]
        public string BYear { get; set; }

        [Column(Name = "bmonth")]
        public string BMonth { get; set; }

        [Column(Name = "bday")]
        public string BDay { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email")]
        public string Email1 { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "home")]
        public string Home { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }


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

            return (FirstName == other.FirstName) && (LastName == other.LastName);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return LastName + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }

            return LastName.CompareTo(other.LastName);
        }

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
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

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
                    return (CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }

            }
            set
            {
                allEmails = value;
            }
        }

        public string Info
        {
            get
            {
                if (info != null)
                {
                    return Info;
                }
                else
                {
                    info = "";

                    if (FirstName != "")
                    { info = info + FirstName; }

                    if (MiddleName != "")
                    {
                        if (info == "")
                        {
                            info = MiddleName;
                        }
                        else
                        {
                            info = info + " " + MiddleName;
                        }
                    }

                    if (LastName != "")
                    {
                        if (info == "")
                        {
                            info = LastName;
                        }
                        else
                        {
                            info = info + " " + LastName;
                        }
                    }

                    if (info != "")
                    {
                        if (info == "")
                        {
                            info = Nickname;
                        }
                        else
                        {
                            info = info + "\r\n" + Nickname;
                        }
                    }

                    if (Title != "")
                    {
                        if (info == "")
                        {
                            info = Title;
                        }
                        else
                        {
                            info = info + "\r\n" + Title;
                        }
                    }

                    if (Company != "") 
                    {
                        if (info == "")
                        {
                            info = Company;
                        }
                        else
                        {
                            info = info + "\r\n" + Company;
                        }
                    }


                    if (Address != "")
                    {
                        if (info == "")
                        {
                            info = Address;
                        }
                        else
                        {
                            info = info + "\r\n" + Address;
                        }
                    }

                    if ((info != "") && (Home != "" || Mobile != "" || Work != "" || Fax != ""))
                    {
                        info = info + "\r\n";
                    }

                    if (Home != "") 
                    {
                        if (info == "")
                        {
                            info = "H: " + Home;
                        }
                        else
                        {
                            info = info + "\r\nH: " + Home;
                        }
                    }

                    if (Mobile != "")
                    {
                        if (info == "")
                        {
                            info = "M: " + Mobile;
                        }
                        else
                        {
                            info = info + "\r\nM: " + Mobile;
                        }
                    }

                    if (Work != "")
                    {
                        if (info == "")
                        {
                            info = "W: " + Work;
                        }
                        else
                        {
                            info = info + "\r\nW: " + Work;
                        }
                    }

                    if (Fax != "")
                    {
                        if (info == "")
                        {
                            info = "F: " + Fax;
                        }
                        else
                        {
                            info = info + "\r\nF: " + Fax;
                        }
                    }

                    if ((info != "") && (Email1 != "" || Email2 != "" || Email3 != "" || Homepage != ""))
                    {
                        info = info + "\r\n";
                    }

                    if (Email1 != "") 
                    {
                        if (info == "")
                        {
                            info = Email1;
                        }
                        else
                        {
                            info = info + "\r\n" + Email1;
                        }
                    }

                    if (Email2 != "")
                    {
                        if (info == "")
                        {
                            info = Email2;
                        }
                        else
                        {
                            info = info + "\r\n" + Email2;
                        }
                    }

                    if (Email3 != "")
                    {
                        if (info == "")
                        {
                            info = Email3;
                        }
                        else
                        {
                            info = info + "\r\n" + Email3;
                        }
                    }

                    if (Homepage != "") 
                    {
                        if (info == "")
                        {
                            info = "Homepage:\r\n" + Homepage;
                        }
                        else
                        {
                            info = info + "\r\nHomepage:\r\n" + Homepage;
                        }
                    }

                    return info;
                }
            }
            set
            {
                Info = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public static List<ContactData> GetAllContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }
    }
}
