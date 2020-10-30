using CIP_lab_1.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labe6
{
    [TestClass]
    public class PasswordWorkerTests
    {
        [TestMethod]
        public void PasswordGenerateLengthTest_from7to10()
        {
            var passwordWorker = RandomPasswordTripleDES.Get();
            string pass = passwordWorker.GeneratePassword();
            Assert.IsTrue(pass.Length >= 7 && pass.Length <= 10);
        }

        [TestMethod]
        public void PasswordEncryptTest()
        {
            var passwordWorker = RandomPasswordTripleDES.Get();
            string passRaw = "2C31pBkg6";
            string logRaw = "JopaDrish";
            string expected = "SRLgVbLwlwOxlnOv45BrnA==";
            string actual = passwordWorker.Encrypt(passRaw, logRaw);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PasswordDecryptTest()
        {
            var passwordWorker = RandomPasswordTripleDES.Get();
            string passRaw = "SRLgVbLwlwOxlnOv45BrnA==";
            string logRaw = "JopaDrish";
            string expected = "2C31pBkg6";
            string actual = passwordWorker.Decrypt(passRaw, logRaw);
            Assert.AreEqual(actual, expected);
        }
    }
}
