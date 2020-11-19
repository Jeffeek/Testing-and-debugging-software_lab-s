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
    public class ParallelSystemTestsDecrypt
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
                q.Add(() => list[i].Decrypt());
            }
            return q;
        }

        [TestMethod]
        public void DecryptIn_10_threads()
        {
            var list = GetTrisemusAlgorithmsList(10);
            bool expected = true;
            bool actual = Parallel.ForEach(list, x => x.Decrypt()).IsCompleted;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptIn_20_threads()
        {
            var list = GetTrisemusAlgorithmsList(20);
            bool expected = true;
            bool actual = Parallel.ForEach(list, x => x.Decrypt()).IsCompleted;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptIn_50_threads()
        {
            var list = GetTrisemusAlgorithmsList(50);
            bool expected = true;
            bool actual = Parallel.ForEach(list, x => x.Decrypt()).IsCompleted;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptIn_100_threads()
        {
            var list = GetTrisemusAlgorithmsList(100);
            bool expected = true;
            bool actual = Parallel.ForEach(list, x => x.Decrypt()).IsCompleted;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptIn_1000_threads()
        {
            var list = GetTrisemusAlgorithmsList(1000);
            bool expected = true;
            bool actual = Parallel.ForEach(list, x => x.Decrypt()).IsCompleted;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptIn_10000_threads()
        {
            var list = GetTrisemusAlgorithmsList(10000);
            bool expected = true;
            bool actual = Parallel.ForEach(list, x => x.Decrypt()).IsCompleted;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptIn_100000_threads()
        {
            var list = GetTrisemusAlgorithmsList(100000);
            bool expected = true;
            bool actual = Parallel.ForEach(list, x => x.Decrypt()).IsCompleted;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptIn_1000_threads_asParallel()
        {
            var list = GetTrisemusAlgorithmsAsAction(1000);
            list.AsParallel().Select(x =>
            {
                x.Invoke();
                return x;
            });
        }

        [TestMethod]
        public void DecryptIn_10000_threads_asParallel()
        {
            var list = GetTrisemusAlgorithmsAsAction(10000);
            list.AsParallel().Select(x =>
            {
                x.Invoke();
                return x;
            });
        }

        [TestMethod]
        public void DecryptIn_100000_threads_asParallel()
        {
            var list = GetTrisemusAlgorithmsAsAction(100000);
            list.AsParallel().Select(x =>
            {
                x.Invoke();
                return x;
            });
        }
    }
}
