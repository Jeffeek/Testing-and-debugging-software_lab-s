using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIP_lab_3.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Labe7
{
    [TestClass]
    public class NonParallelEncrypt
    {
        private List<TrisemusAlgorithm> GetTrisemusAlgorithmsList(int count)
        {
            List<TrisemusAlgorithm> testTrisemusAlgorithms = new List<TrisemusAlgorithm>();
            int countOfColumns = 6;
            bool isEnglish = false;
            string message = "привет!";
            string key = "пока";
            for (int i = 0; i < count; i++)
            {
                testTrisemusAlgorithms.Add(new TrisemusAlgorithm(message, key, countOfColumns, isEnglish));
            }

            return testTrisemusAlgorithms;
        }

        private List<Action> GetTrisemusAlgorithmsAsAction(int count)
        {
            var list = GetTrisemusAlgorithmsList(count);
            List<Action> q = new List<Action>();
            for (int i = 0; i < 100; i++)
            {
                q.Add(() => list[i].Encrypt());
            }
            return q;
        }

        private bool DoActions(List<Action> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Invoke();
            }

            return true;
        }

        [TestMethod]
        public void EncryptIn_1000_threads_asNonParallel()
        {
            var list = GetTrisemusAlgorithmsAsAction(1000);
            DoActions(list);
        }

        [TestMethod]
        public void EncryptIn_10000_threads_asNonParallel()
        {
            var list = GetTrisemusAlgorithmsAsAction(10000);
            DoActions(list);
        }

        [TestMethod]
        public void EncryptIn_100000_threads_asNonParallel()
        {
            var list = GetTrisemusAlgorithmsAsAction(100000);
            DoActions(list);
        }
    }
}
