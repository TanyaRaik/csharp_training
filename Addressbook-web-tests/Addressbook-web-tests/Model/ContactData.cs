using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
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
    }
}
