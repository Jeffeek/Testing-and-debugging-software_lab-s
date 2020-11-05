using System.IO;
using System.Linq;
using CIP_lab_1.Models;
using CIP_lab_1.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labe6
{
    [TestClass]
    public class GeneralIntegrationFileWorkerTests
    {
        [TestMethod]
        public void FileReaderTest()
        {
            var fileWorker = new FileWorker<Profile>($"{Directory.GetCurrentDirectory()}//profiles.json");
            var profiles = fileWorker.Reader.GetProfiles();
            Assert.IsTrue(profiles.Count > 0);
        }

        [TestMethod]
        public void FileWriterTest()
        {
            var fileWorker = new FileWorker<Profile>($"{Directory.GetCurrentDirectory()}//profiles.json");
            int count = fileWorker.Reader.GetProfiles().Count;
            var profile = new Profile()
            {
                FullName = "Alesha",
                Login = "Popovich",
                Password = "thisIsNotValidPass",
                SecretWord = "NotSecret"
            };
            fileWorker.Writer.AddNewProfile(profile);
            var profiles = fileWorker.Reader.GetProfiles();
            int newCount = profiles.Count;
            Assert.IsTrue(newCount == count + 1);
            profiles.Remove(profile);
            fileWorker.Writer.RewriteAll(profiles);
        }
    }
}
