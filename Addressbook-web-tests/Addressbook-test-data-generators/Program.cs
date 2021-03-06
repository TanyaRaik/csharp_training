﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]); 
            StreamWriter writer = new StreamWriter(args[1]); 
            string format = args[2];
            string creation = args[3];

            if (creation == "groups") 
            {
                List<GroupData> groups = new List<GroupData>();

                AddListGroups(groups, count);

                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    Console.WriteLine("Unrecognized format " + format);
                }
            }

            else if (creation == "contacts") 
            {
                List<ContactData> contacts = new List<ContactData>();

                AddListContact(contacts, count);

                if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else
                {
                    Console.WriteLine("Unrecognized format " + format);
                }
            }

            else 
            {
                Console.WriteLine("Unrecognized item " + creation);
            }

            writer.Close();
        }



        static void AddListGroups(List<GroupData> groups, int count)
        {
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
        }

        static void AddListContact(List<ContactData> contacts, int count)
        {
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    MiddleName = TestBase.GenerateRandomString(20),
                    Nickname = TestBase.GenerateRandomString(20),
                    Title = TestBase.GenerateRandomString(20),
                    Company = TestBase.GenerateRandomString(20),
                    Address = TestBase.GenerateRandomString(20),
                    Home = TestBase.GenerateRandomString(20),
                    Mobile = TestBase.GenerateRandomString(20),
                    Work = TestBase.GenerateRandomString(20),
                    Fax = TestBase.GenerateRandomString(20),
                    Email1 = TestBase.GenerateRandomString(20),
                    Email2 = TestBase.GenerateRandomString(20),
                    Email3 = TestBase.GenerateRandomString(20),
                    Homepage = TestBase.GenerateRandomString(20),
                });
            }
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }



        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
