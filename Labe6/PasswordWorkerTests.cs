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
    }
}
