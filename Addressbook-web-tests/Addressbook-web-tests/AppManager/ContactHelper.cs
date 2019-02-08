﻿using System;
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

        public ContactHelper RemoveContact(int v)
        {

                SelectContact(v);
                RemoveContact();
                AcceptAlert();
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
                InitContactModification();
                FillContactForm(newData);
                SubmitContactModification();
                return this;
        }
  
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//tr[@name='entry'][1]//img[@title='Edit']")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            OpenContactForm();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            //Submit Contact Creation
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            //Submit Contact Modification
            driver.FindElement(By.Name("update")).Click();
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
            Type(By.Name("fax"), contact.Fax);
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + rowNumber + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
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
