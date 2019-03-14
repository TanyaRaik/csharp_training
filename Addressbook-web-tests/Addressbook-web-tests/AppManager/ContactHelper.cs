using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenMainPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                AllEmails  = allEmails,
                AllPhones = allPhones,

            };
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenMainPage();
            CleanGroupFilter();
            SelectOneContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void DeleteContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenMainPage();
            SelectGroupInFilter(group.Id);
            SelectContact(contact.Id);
            SubmitDeletingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                            .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void SelectGroupInFilter(string value)
        {
            driver.FindElement(By.XPath("//select[@name='group']/option[@value='" + value + "']")).Click();
        }

        public void SubmitDeletingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }
        

        public void CleanGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void SelectOneContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenMainPage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            return new ContactData()
            {
                FirstName = firstName,
                LastName = lastName,
                Nickname = nickname,
                MiddleName = middlename,
                Company = company,
                Title = title,
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Fax = fax,
               Email1 = email,
               Email2 = email2,
               Email3 = email3,
               Homepage = homepage,
            };
        }

        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenMainPage();
            OpenDetailsMode(index);
            return driver.FindElement(By.Id("content")).Text;
        }

        private ContactHelper OpenDetailsMode(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].Click();
            return this;
        }

        public ContactHelper RemoveContact(int v)
        {

                SelectContact(v);
                RemoveContact();
                AcceptAlert();
            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            } while (driver.FindElements(By.XPath("//tr[@name='entry']")).Count == 0 && attempt < 60);
            return this;
        }

        public ContactHelper RemoveContact(ContactData contact)
        {

            SelectContact(contact.Id);
            RemoveContact();
            AcceptAlert();
            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            } while (driver.FindElements(By.XPath("//tr[@name='entry']")).Count == 0 && attempt < 60);
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
                InitContactModification(0);
                FillContactForm(newData);
                SubmitContactModification();
                return this;
        }

        public ContactHelper Modify(ContactData oldData, ContactData newData)
        {
            InitContactModification(oldData.Id);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public void ViewContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper InitContactModification(string id)
        {
            {
                driver.FindElement(By.XPath("//input[@id = '" + id + "']/ancestor::tr//td[8]//img[@title = 'Edit']")).Click();

                return this;
            }
        }
        public ContactHelper Create(ContactData contact)
        {
            OpenContactForm();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public int GetContactCount()
        {
            manager.Navigator.OpenMainPage();
            return driver.FindElements(By.Name("entry")).Count;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            
            if (contactCache == null) 
            {
                contactCache = new List<ContactData>();

                manager.Navigator.OpenMainPage();
                ICollection<IWebElement> contactStrings = driver.FindElements(By.Name("entry"));


                foreach (IWebElement element in contactStrings)
                {
                    var cells = element.FindElements(By.TagName("td"));

                    var item = new ContactData
                    {
                        Id = cells[0].FindElement(By.TagName("input")).GetAttribute("Id"),
                        FirstName = cells[2].Text,
                        LastName = cells[1].Text
                    };
                    contactCache.Add(item); 
                }

            }

            return new List<ContactData>(contactCache);
        }


        public ContactHelper SubmitContactCreation()
        {
            //Submit Contact Creation
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            //Submit Contact Modification
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            //FillContactForm
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("address2"), contact.SAddress);
            Type(By.Name("phone2"), contact.SHome);
            Type(By.Name("notes"), contact.SNotice);

            return this;
        }

        public ContactHelper OpenContactForm()
        {
            //Open Contact Form
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectContact(int rowNumber)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (rowNumber+1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '" + id + "'])")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public bool IsContactExists()
        {
            return IsElementPresent(By.XPath("//tr[@name='entry'][1]//img[@title='Edit']"));
        }
    }
}
