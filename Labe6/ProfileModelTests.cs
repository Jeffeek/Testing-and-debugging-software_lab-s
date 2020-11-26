using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CIP_lab_1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labe6
{
    [TestClass]
    public class ProfileModelTests
    {
        [TestMethod]
        public void Generate1000000Profiles_perfomance()
        {
            var list = new List<Profile>();
            for (int i = 0; i < 1000000; i++)
            {
                var profile = new Profile()
                {
                    FullName = Guid.NewGuid().ToString(), 
                    Login = Guid.NewGuid().ToString(), 
                    Password = Guid.NewGuid().ToString(), 
                    SecretWord = Guid.NewGuid().ToString()
                };
                list.Add(profile);
            }
            Assert.IsTrue(list.Count == 1000000);
        }

        [TestMethod]
        public void ProfilesEquals()
        {
            var list = new List<Profile>();
            string testName = "Bob";
            string testLogin = "NotAlogin";
            string testPass = "validPass";
            string testSW = "testing";
            for (int i = 0; i < 10000; i++)
            {
                var profile = new Profile()
                {
                    FullName = testName,
                    Login = testLogin,
                    Password = testPass,
                    SecretWord = testSW
                };
                list.Add(profile);
            }

            for (int i = 0; i < 10000; i++)
            {
                var profileToEqual = list[i];
                for (int j = 0; j < 10000; j++)
                {
                    Assert.AreEqual(profileToEqual, list[j]);
                }
            }
        }
    }
}
