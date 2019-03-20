﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("");
            app.Ftp.Upload("", null);

        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            app.Registration.Register(account);
        }

        [TearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("");
        }
    }
}