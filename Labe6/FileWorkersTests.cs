using System.Collections.Generic;
using System.IO;
using System.Linq;
using CIP_lab_1.Models;
using CIP_lab_1.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

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
            ProfilesWriter<Profile> writer = new ProfilesWriter<Profile>()
            {
                Path = $"{Directory.GetCurrentDirectory()}//profiles_test.json"
            };
            var profile = new Profile()
            {
                FullName = "George",
                Login = "LOGIN",
                Password = "2C31pBkg6",
                SecretWord = "Secret"
            };
            writer.AddNewProfile(profile);
            using (var fs = new StreamReader($"{Directory.GetCurrentDirectory()}//profiles_test.json"))
            {
                var readed = JsonConvert.DeserializeObject<List<Profile>>(fs.ReadToEnd());
                Assert.IsTrue(readed.Last().Equals(profile));
            }
        }

        [TestMethod]
        public void FileWriterRewriteAll_Success()
        {
            ProfilesWriter<Profile> writer = new ProfilesWriter<Profile>()
            {
                Path = $"{Directory.GetCurrentDirectory()}//profiles_test_rewrite.json"
            };
            var items = new List<Profile>()
            {
                new Profile()
                {
                    FullName = "George",
                    Login = "LOGIN",
                    Password = "2C31pBkg6",
                    SecretWord = "Secret"
                },
                new Profile()
                {
                    FullName = "George2",
                    Login = "LOGIN2",
                    Password = "2C31pBkg1",
                    SecretWord = "Secret2"
                }
            };
            writer.RewriteAll(items);
            using (var fs = new StreamReader($"{Directory.GetCurrentDirectory()}//profiles_test_rewrite.json"))
            {
                var readed = JsonConvert.DeserializeObject<List<Profile>>(fs.ReadToEnd());
                CollectionAssert.AreEqual(readed, items);
            }
        }
    }
}
