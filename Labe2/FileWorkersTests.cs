using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using lab_1.Models;
using lab_1.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labe6
{
    [TestClass]
    public class FileWorkersTests
    {
        [TestMethod]
        public void FileReaderEncryptedTest_Successful()
        {
            List<Profile> expected = new List<Profile>()
            {
                new Profile()
                {
                    FullName = "qwqw",
                    Login = "Lolq",
                    Password = "DRduHmAxke4=",
                    SecretWord = "aaaa"
                },
                new Profile()
                {
                    FullName = "qwertyuiop",
                    Login = "JopaDrish",
                    Password = "SRLgVbLwlwOxlnOv45BrnA==",
                    SecretWord = "12345678"
                }
            };
            ProfilesReader<Profile> reader = new ProfilesReader<Profile>
            {
                Path = $"{Directory.GetCurrentDirectory()}//profiles_test_encrypted.json"
            };
            var actual = reader.GetProfiles();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FileReaderEncryptedTest_Exception()
        {
            ProfilesReader<Profile> reader = new ProfilesReader<Profile>
            {
                Path = $"{Directory.GetCurrentDirectory()}//exception.json"
            };
            Assert.ThrowsException<FileNotFoundException>(() => reader.GetProfiles());
        }

        [TestMethod]
        public void FileReaderDecryptedTest_Successful()
        {
            List<Profile> expected = new List<Profile>()
            {
                new Profile()
                {
                    FullName = "qwqw",
                    Login = "Lolq",
                    Password = "PkT82MT",
                    SecretWord = "aaaa"
                },
                new Profile()
                {
                    FullName = "qwertyuiop",
                    Login = "JopaDrish",
                    Password = "2C31pBkg6",
                    SecretWord = "12345678"
                }
            };
            ProfilesReader<Profile> reader = new ProfilesReader<Profile>
            {
                Path = $"{Directory.GetCurrentDirectory()}//profiles_test_encrypted.json"
            };
            var actual = reader.GetProfiles(true);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FileWriterAddProfile_Success()
        {
            
        }
    }
}
